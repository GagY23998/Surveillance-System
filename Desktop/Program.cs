using AppCore.Requests;
using Emgu.CV;
using Emgu.CV.Structure;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static VideoCapture camEnter = new VideoCapture(1);
        public static VideoCapture camExit = new VideoCapture(2);
        public static SerialPort serialPort = new SerialPort("COM3",9600);
        private static APIService _archiveService = new APIService("archive");
        public static FaceRecognitionDB faceRecognition = new FaceRecognitionDB();
        private static CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_alt.xml");
        private static APIService _tokenService = new APIService("token");
        private static bool isBusyEnter = false;
        private static bool isBusyLeave = false;
        const int minNeighbours = 5;
        const double scaleSize = 1.05;
        static bool timeout = true;
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        [STAThread]
        static void Main()
        {

            camEnter.ImageGrabbed += CamEnter_ImageGrabbed;
            camExit.ImageGrabbed += CamExit_ImageGrabbed;

            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;
            serialPort.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
            camEnter.Start();
            camExit.Start();
            timer.Start();



            Application.Run(new frmLogin());
         

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (!timeout) timeout = true;
        }

        public static async void CamEnter_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                if (!isBusyEnter)
                {
                    isBusyEnter = true;
                    Mat matImage = camEnter.QueryFrame();
                  
                    Image<Gray, byte> grayImage = matImage.ToImage<Gray, byte>();
                    Image<Bgr, byte> bgrImage = matImage.ToImage<Bgr, byte>();
                    grayImage._EqualizeHist();
                    Rectangle[] rectangles = classifier.DetectMultiScale(grayImage, scaleSize,minNeighbours);
                    Image<Gray, byte> image = null;
                    if (rectangles.Count() > 0)
                    {
                         image = matImage.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        image._EqualizeHist();
                        //get result
                        var result =await faceRecognition.Predict(image, StateType.Entered,bgrImage);
                        if(result.Key != null && serialPort.IsOpen)
                        {
                            byte myByte = Convert.ToByte('O');
                            serialPort.Write(new byte[] { myByte },0,1);
                        }
                        // if result didn't return user, check if 
                        else if(result.Value != int.MaxValue)
                        {

                            var firstTest = classifier.DetectMultiScale(grayImage, 1.2, 3);
                            var thirdTest = classifier.DetectMultiScale(grayImage, scaleSize, 7);
                            //condition to make sure that the processed image is not false positive
                            //and even if the region is slightly shifted to any direction, then it 
                            //must be the same region that all of the pictures are pointing at
                            //this way i'm trying to eliminate false positives beacuse,while scaling window size 
                            //false positive can be recognized in many parts of the picture, hence the reason for the checkup
                            bool condition = firstTest[0] == rectangles[0] && rectangles[0] == thirdTest[0]
                                || ((rectangles[0].X - firstTest[0].X <= 10 && rectangles[0].Y - firstTest[0].Y <= 10 || (firstTest[0].Y - rectangles[0].Y <= 10 && firstTest[0].X - rectangles[0].X <= 10))
                                && (((thirdTest[0].X - rectangles[0].X <= 10 && thirdTest[0].Y - rectangles[0].Y <= 10) || (rectangles[0].X - thirdTest[0].X <= 10) && rectangles[0].Y - thirdTest[0].Y <= 10)));
                            

                            if (timeout && (result.Value > 4000 && result.Value < 5000) && condition) 
                            {
                                using (var ms = new MemoryStream())
                                {
                                    Bitmap bitmap = bgrImage.ToBitmap();
                                    bitmap.Save(ms, ImageFormat.Png);
                                    byte[] myArray = ms.ToArray();
                                    string bytePicture = Convert.ToBase64String(myArray);
                                    await _archiveService.Insert<LogDTO>(new LogInsertRequest
                                    {
                                        EnteredDate = DateTime.Now,
                                        LeftDate = DateTime.Now,
                                        Picture = bytePicture,
                                        UserId = null,
                                        Entered = false,
                                        Left = false
                                    });
                                }
                                timeout = false;
                            }
                        }
                    }
                    isBusyEnter = false;
                }
            }
            catch (Exception err)
            {
                //do nothin
                var user = await _tokenService.Insert<AppCore.Requests.UserDTO>(new AppCore.Requests.UserInsertRequest { UserName = "admin", Password = "admin" });
                if (user != null)
                {
                    APIService.Token = "Bearer " + user.Token;

                }
                isBusyEnter = false;
            }
        }
        public static async void CamExit_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                if (!isBusyLeave)
                {
                    isBusyLeave = true;
                    Mat matImage = camExit.QueryFrame();
                    
                    Image<Gray, byte> grayImage = matImage.ToImage<Gray, byte>();
                    Image<Bgr, byte> bgrImage = matImage.ToImage<Bgr, byte>();
                    grayImage._EqualizeHist();
                    Rectangle[] rectangles = classifier.DetectMultiScale(grayImage, scaleSize,minNeighbours);
                    if (rectangles.Count() > 0)
                    {
                        var image = matImage.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        image._EqualizeHist();
                        var result =  await faceRecognition.Predict(image, StateType.Left,bgrImage);
                        
                        if (result.Key != null && serialPort.IsOpen)
                        {
                            byte myByte = Convert.ToByte('O');
                            serialPort.Write(new byte[] { myByte }, 0, 1);
                        }
                    }
                    isBusyLeave = false;
                }
            }
            catch (Exception err)
            {
                var user = await _tokenService.Insert<AppCore.Requests.UserDTO>(new AppCore.Requests.UserInsertRequest { UserName = "admin", Password = "admin" });
                if (user != null)
                {
                    APIService.Token = "Bearer " + user.Token;

                }
                isBusyLeave = false;
            }
        }
    }
}

using Emgu.CV;
using Emgu.CV.Structure;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
        private static FaceRecognitionDB faceRecognition = new FaceRecognitionDB();
        private static CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_default.xml");
        private static APIService _tokenService = new APIService("token");
        private static bool isBusyEnter = false;
        private static bool isBusyLeave = false;
        [STAThread]
        static void Main()
        {

            camEnter.ImageGrabbed += CamEnter_ImageGrabbed;
            camExit.ImageGrabbed += CamExit_ImageGrabbed;

            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;
  //          serialPort.Open();
            camEnter.Start();
            camExit.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());


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
                    grayImage._EqualizeHist();
                    Rectangle[] rectangles = classifier.DetectMultiScale(grayImage, 1.3, 5);
                    if (rectangles.Count() > 0)
                    {
                        var image = matImage.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        image._EqualizeHist();
                        var result =await faceRecognition.Predict(image, StateType.Entered);
                        if(result != null && serialPort.IsOpen)
                        {
                            byte myByte = Convert.ToByte('O');
                            serialPort.Write(new byte[] { myByte },0,1);
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
                    grayImage._EqualizeHist();
                    Rectangle[] rectangles = classifier.DetectMultiScale(grayImage, 1.3, 5);
                    if (rectangles.Count() > 0)
                    {
                        var image = matImage.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        image._EqualizeHist();
                        var result =  await faceRecognition.Predict(image, StateType.Left);
                        
                        if (result != null && serialPort.IsOpen)
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

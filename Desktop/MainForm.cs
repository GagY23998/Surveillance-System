using Desktop.Logs;
using Desktop.Users;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using AppCore.Requests;
using System.Threading;

namespace Desktop
{
    public partial class MainForm : Form
    {
        private List<Button> deletedButtons;
        private SerialPort serial;
        private FaceRecognitionDB faceRecognition;
        private CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_default.xml");
        //public static VideoCapture camEnter;
        //public static VideoCapture camExit;
        //public static bool Entered = false;
        //public static bool Left = false;

        public MainForm()
        {
            InitializeComponent();
            //serial = new SerialPort("COM3", 9600);
            //serial.DtrEnable = true;
            //serial.RtsEnable = true;
            //deletedButtons = new List<Button>();
            //faceRecognition = new FaceRecognitionDB();
            //camEnter = new VideoCapture(1);
            //camExit = new VideoCapture(2);
            //camEnter.ImageGrabbed += CamEnter_ImageGrabbed;
            //camExit.ImageGrabbed += CamExit_ImageGrabbed;
            //serial.Open();
        }

        //private async void CamExit_ImageGrabbed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!Left)
        //        {
        //            Left = true;
        //            Mat m =camExit.QueryFrame();
        //            Image<Gray, byte> grayImage = m.ToImage<Gray, byte>();
        //            grayImage._EqualizeHist();
                    
        //            Rectangle[] rectangles = classifier.DetectMultiScale(grayImage,1.3,5);

        //            if (rectangles.Count() > 0)
        //            {
        //                Image<Gray, byte> image = m.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
        //                image._EqualizeHist();
        //                var result =await faceRecognition.Predict(image,StateType.Left);
        //                if (result != null && serial.IsOpen)
        //                {
        //                    byte myByte = Convert.ToByte('O');
        //                    serial.Write(new byte[] { myByte }, 0, 1);
        //                }
        //            }
        //            Left = false;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        //do nothin

        //    }

        //}

        //private async void CamEnter_ImageGrabbed(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!Entered)
        //        {
        //            Entered = true;
        //            Mat m = camEnter.QueryFrame();
        //            Image<Gray, byte> grayImage = m.ToImage<Gray, byte>();
        //            grayImage._EqualizeHist();
        //            Rectangle[] rectangles = classifier.DetectMultiScale(grayImage,1.3,5);
        //            if (rectangles.Count() > 0)
        //            {
        //                Image<Gray, byte> image = m.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
        //                image._EqualizeHist();
        //                var res = await faceRecognition.Predict(image,StateType.Entered);
        //                if (res != null && serial.IsOpen)
        //                {
        //                    byte myByte = Convert.ToByte('O');
        //                    serial.Write(new byte[] { myByte }, 0, 1);
        //                }
        //            }
        //            Entered = false;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        //do nothin
                
        //    }
          
        //}

      

        private void btn_Users_Click(object sender, EventArgs e)
        {
          
            frmUsersMenu frm = new frmUsersMenu()
            {
                AutoScroll = false,
                TopLevel = false,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterParent

            };
            mainPanel.Controls.Add(frm);
            frm.Show();
        }

      
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_Logs_Click(object sender, EventArgs e)
        {

            frmLogs frm = new frmLogs()
            {
                AutoScroll = false,
                TopLevel = false,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterParent

            };
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(frm);
            frm.Show();
        }

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    camEnter.Start();
        //    camExit.Start();
        //}
    }
}

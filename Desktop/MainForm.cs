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

namespace Desktop
{
    public partial class MainForm : Form
    {
        private List<Button> deletedButtons;
        private SerialPort serial;
        private FaceRecognitionDB faceRecognition;
        private CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_default.xml");
        VideoCapture camEnter;
        VideoCapture camExit;
        public MainForm()
        {
            InitializeComponent();
            deletedButtons = new List<Button>();
            faceRecognition = new FaceRecognitionDB();
            camEnter = new VideoCapture(1);
            camExit = new VideoCapture(2);
            camEnter.ImageGrabbed += CamEnter_ImageGrabbed;
            camExit.ImageGrabbed += CamExit_ImageGrabbed;
        }

        private async void CamExit_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                camEnter.Retrieve(m);
                Rectangle[] rectangles = classifier.DetectMultiScale(m, 1.1, 3);
                if (rectangles.Count() > 0)
                {
                    Image<Gray, byte> image = m.ToImage<Gray, byte>().Resize(240, 180, Emgu.CV.CvEnum.Inter.Cubic);
                    await faceRecognition.Predict(image,StateType.Left);
                }
            }
            catch (Exception err)
            {
                //do nothin

            }

        }

        private async void CamEnter_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                camEnter.Retrieve(m);
                Rectangle[] rectangles = classifier.DetectMultiScale(m, 1.1, 3);
                if (rectangles.Count() > 0)
                {
                    Image<Gray, byte> image = m.ToImage<Gray, byte>().Resize(240, 180, Emgu.CV.CvEnum.Inter.Cubic);
                    await faceRecognition.Predict(image,StateType.Entered); 
                }
            }
            catch (Exception err)
            {
                //do nothin
                
            }
          
        }

      

        private void btn_Users_Click(object sender, EventArgs e)
        {
            var buttons = sidePanel.Controls.OfType<Button>().Where(_ => _.Text != "Exit" && _.Text !="Menu");
            foreach (var control in buttons)
            {
                deletedButtons.Add(control);
                sidePanel.Controls.Remove(control);
            }
            //List<Button> newButtons = new List<Button>
            //{
            //    new Button{Name ="btnAddUser",Text="Add User"},
            //    new Button{Name ="btnUpdateUser",Text="Update User"},
            //    new Button{Name ="btnRemoveUser",Text="Remove User"}
            //};

            //for(int i =0;i<newButtons.Count;i++)
            //{
            //    if (i == 0)
            //    {
            //        newButtons[i].Location = new Point(0,sidePanel.Controls[1].Location.Y+53);
            //    }
            //    else{
            //        newButtons[i].Location = new Point(0, newButtons[i - 1].Location.Y+53);
            //    }
            //    newButtons[i].Size = new Size(182, 59);
            //    newButtons[i].BackColor = Color.FromArgb(79, 83, 83);
            //    newButtons[i].Font = new Font("Raleway Medium", 18.25f);
            //    newButtons[i].ForeColor = Color.WhiteSmoke;
            //    sidePanel.Controls.Add(newButtons[i]);
            //}
            var backButton = new Button
            {
                Name = "btnBack",
                Text = "Back",
                Size = new Size(182, 59),
                BackColor = Color.FromArgb(79, 83, 83),
                Font = new Font("Raleway Medium", 18.25f),
                ForeColor = Color.WhiteSmoke
            };

            //  backButton.Location = new Point(0, newButtons[newButtons.Count - 1].Location.Y + 53);
            backButton.Location = new Point(0, sidePanel.Controls[sidePanel.Controls.Count - 1].Location.Y + 53);
            btnExit.Location = new Point(0, backButton.Location.Y + 53);
            
            sidePanel.Controls.Add(backButton);
        
            backButton.Click += BackButton_Click;

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

        private void BackButton_Click(object sender, EventArgs e)
        {
            var buttons = sidePanel.Controls.OfType<Button>().ToList();

            foreach (var item in buttons)
            {
                if (item.Text == "Exit" || item.Text == "Menu")
                    continue;
                sidePanel.Controls.Remove(item);
            }
            int cnt = sidePanel.Controls.Count;
            sidePanel.Controls.AddRange(deletedButtons.ToArray());

            for (int i = cnt; i < sidePanel.Controls.Count; i++)
            {
                if(i == cnt)
                {
                    sidePanel.Controls[i].Location = new Point(0,sidePanel.Controls[1].Location.Y+53);
                }
                else
                {
                    sidePanel.Controls[i].Location = new Point(0, sidePanel.Controls[i - 1].Location.Y + 53);
                }

            }
            btnExit.Location = new Point(0, sidePanel.Controls[sidePanel.Controls.Count - 1].Location.Y + 53);
            mainPanel.Controls.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_Logs_Click(object sender, EventArgs e)
        {
            var buttons = sidePanel.Controls.OfType<Button>().Where(_ => _.Text != "Exit" && _.Text != "Menu");
            foreach (var control in buttons)
            {
                deletedButtons.Add(control);
                sidePanel.Controls.Remove(control);
            }
            List<Button> newButtons = new List<Button>
            {
                new Button{Name ="btnAddLogs",Text="Add Log"},
                new Button{Name ="btnUpdateLogs",Text="Update Log"},
                new Button{Name ="btnRemoveLogs",Text="Remove Log"}
            };

            for (int i = 0; i < newButtons.Count; i++)
            {
                if (i == 0)
                {
                    newButtons[i].Location = new Point(0, sidePanel.Controls[1].Location.Y + 53);
                }
                else
                {
                    newButtons[i].Location = new Point(0, newButtons[i - 1].Location.Y + 53);
                }
                newButtons[i].Size = new Size(182, 59);
                newButtons[i].BackColor = Color.FromArgb(79, 83, 83);
                newButtons[i].Font = new Font("Raleway Medium", 18.25f);
                newButtons[i].ForeColor = Color.WhiteSmoke;
                sidePanel.Controls.Add(newButtons[i]);
            }
            var backButton = new Button
            {
                Name = "btnBack",
                Text = "Back",
                Size = new Size(182, 59),
                BackColor = Color.FromArgb(79, 83, 83),
                Font = new Font("Raleway Medium", 18.25f),
                ForeColor = Color.WhiteSmoke
            };

            backButton.Location = new Point(0, newButtons[newButtons.Count - 1].Location.Y + 53);
            btnExit.Location = new Point(0, backButton.Location.Y + 53);

            sidePanel.Controls.Add(backButton);

            backButton.Click += BackButton_Click;

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            camEnter.Start();
        }
    }
}

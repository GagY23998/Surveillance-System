using AForge.Video.DirectShow;
using AppCore.Requests;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Users
{
    public partial class frmAddUser : Form
    {

        private APIService _userService = new APIService("user");
        private APIService _labelService = new APIService("label");
        int? _id = null;
        private CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_default.xml");
        private FaceRecognitionDB faceRecognition = new FaceRecognitionDB();
        public frmAddUser(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var txtBoxes = this.Controls.OfType<TextBox>();
            foreach (var item in txtBoxes)
            {
                item.Text = string.Empty;
            }
        }

        private async void btnUsers_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(_ => string.IsNullOrEmpty(_.Text)))
            {
                MessageBox.Show("Fields cannot be empty", "Info", MessageBoxButtons.OK);
                return;
            }
            if ((await _userService.Get<List<UserDTO>>(null)).Any(_ => _.FirstName == txtBox_FirstName.Text && _.LastName == txtBox_LastName.Text))
            {
                MessageBox.Show("User already exists", "Info", MessageBoxButtons.OK);
                return;
            }
            UserInsertRequest request = new UserInsertRequest
            {
                UserName = txtBox_UserName.Text,
                FirstName = txtBox_FirstName.Text,
                LastName = txtBox_LastName.Text,
                Password = txtBox_Password.Text,
                PasswordConfirmation = txtBox_Confirm.Text
            };
            UserDTO result = await _userService.Insert<UserDTO>(request);
            if (result == null)
            {
                MessageBox.Show("Couldn't add new user", "Info", MessageBoxButtons.OK);

            }
            _id = result.Id;
            MessageBox.Show("Successufully added new user", "Info", MessageBoxButtons.OK);

        }

        private async Task TakeImages(int cameraNumber)
        {
            VideoCapture videoCapture = new VideoCapture(cameraNumber);
            List<Image<Gray, byte>> images = new List<Image<Gray, byte>>();
            int counter = 0;
            while (images.Count <= 20)
            {

                Mat matImage = videoCapture.QueryFrame();

                Image<Gray, byte> grayImage = matImage.ToImage<Gray, byte>();
                grayImage._EqualizeHist();
                Rectangle[] rectangles = classifier.DetectMultiScale(grayImage, 1.3, 5);
                if (rectangles.Count() > 0)
                {
                    var result = matImage.ToImage<Gray, byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                    result._EqualizeHist();
                    imgBox_UserFace.Image = result;
                    images.Add(result);
                    counter++;

                }
                var showImage = images.LastOrDefault().Clone();
                imgBox_UserFace.Image = showImage.Resize(imgBox_UserFace.Size.Width, imgBox_UserFace.Size.Height, Emgu.CV.CvEnum.Inter.Cubic);
            }
                await faceRecognition.AddImagesToDb(images.ToArray(), _id.Value);
                faceRecognition.TrainImages();

        }

        private async void btnSetImage_Click(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                Program.camEnter.Stop();
                Program.camExit.Stop();
                await TakeImages(1);
                /*
                 List<Image<Gray, byte>> images = new List<Image<Gray, byte>>();
                 int counter = 0;
                 while (counter <= 20)
                 {

                     Mat matImage = videoCapture.QueryFrame();

                     Image<Gray, byte> grayImage=matImage.ToImage<Gray, byte>();
                     grayImage._EqualizeHist();
                     Rectangle[] rectangles = classifier.DetectMultiScale(grayImage,1.3,5);
                     if (rectangles.Count() > 0)
                     {
                         var result = matImage.ToImage<Gray,byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                         result._EqualizeHist();
                         imgBox_UserFace.Image = result;  
                         images.Add(result);
                         counter++;

                     }
                 }
                    await faceRecognition.AddImagesToDb(images.ToArray(), _id.Value);
                    var showImage = images.LastOrDefault().Clone();
                 */


               
                DialogResult boxResult = MessageBox.Show("Please move to exit camera", "Info", MessageBoxButtons.OK);
                
                if(boxResult == DialogResult.OK)
                {
                    await TakeImages(2);
                }
                MessageBox.Show("Images successufully added to the database", "Info", MessageBoxButtons.OK);

                Program.camEnter = new VideoCapture(1);
                Program.camExit = new VideoCapture(2);
                Program.camEnter.ImageGrabbed += Program.CamEnter_ImageGrabbed;
                Program.camExit.ImageGrabbed += Program.CamExit_ImageGrabbed;
                Program.camEnter.Start();
                Program.camExit.Start();
            }
            else
            {
                MessageBox.Show("Can't set image for unselected/nonexistent user", "OK", MessageBoxButtons.OK);
            }
        }

        private async void frmAddUser_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var user = await _userService.GetById<UserDTO>(_id.Value);
                if (user != null)
                {
                    txtBox_FirstName.Text = user.FirstName;
                    txtBox_LastName.Text = user.LastName;
                    txtBox_UserName.Text = user.UserName;
                }
            }
        }
    }
}

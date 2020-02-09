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
                MessageBox.Show("Couldn't add new user", "Info", MessageBoxButtons.OK);
            MessageBox.Show("Successufully added new user", "Info", MessageBoxButtons.OK);

        }

        private async void btnSetImage_Click(object sender, EventArgs e)
        {
            VideoCapture videoCapture = new VideoCapture(1);
            
            List<Image<Gray, byte>> images = new List<Image<Gray, byte>>();
            int counter = 0;
            while (counter != 50)
            {
                Mat matImage = videoCapture.QueryFrame();
                Image<Gray, byte> image = matImage.ToImage<Gray, byte>().Resize(240,180, Emgu.CV.CvEnum.Inter.Cubic);
                Rectangle[] rectangles = classifier.DetectMultiScale(image, 1.1, 3);
                
                if (rectangles.Count() > 0)
                {
                    images.Add(image);
            
                }
                counter++;
            }

            await faceRecognition.AddImagesToDb(images.ToArray(), _id.Value);
            imgBox_UserFace.Image = images.Last();
            MessageBox.Show("Done", "Info", MessageBoxButtons.OK);
            videoCapture.Dispose();
            faceRecognition.TrainImages();
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

using AForge.Video.DirectShow;
using AppCore.Requests;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private APIService _userRoleService = new APIService("userrole");
        private APIService _roleService = new APIService("role");
        const int minNeighbours = 3;
        const double scaleSize = 1.1;
        int? _id = null;
        private CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_alt.xml");
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
            
            
            RoleDTO role = (await _roleService.Get<List<RoleDTO>>(null)).FirstOrDefault(_ => _.Name == "User");



            UserInsertRequest request = new UserInsertRequest
            {
                UserName = txtBox_UserName.Text,
                FirstName = txtBox_FirstName.Text,
                LastName = txtBox_LastName.Text,
                Password = txtBox_Password.Text,
                PasswordConfirmation = txtBox_Confirm.Text,
                Roles =  new List<RoleDTO> { role }
            };
            try
            {

                UserDTO userResult = await _userService.Insert<UserDTO>(request);
                
                if (userResult == null)
                {
                    MessageBox.Show("Couldn't add new user", "Info", MessageBoxButtons.OK);

                }
                _id = userResult.Id;
                MessageBox.Show("Successufully added new user", "Info", MessageBoxButtons.OK);
            }catch(Exception exc)
            {
                frmLogin frm = new frmLogin();
                this.Hide();
                frm.Show();
            }

        }

        private async Task TakeImages(int cameraNumber)
        {
            VideoCapture videoCapture = new VideoCapture(cameraNumber);
            List<Image<Gray, byte>> images = new List<Image<Gray, byte>>();
            int counter = 0;
            while (images.Count<10)
            {

                Mat matImage = videoCapture.QueryFrame();

                Image<Gray, byte> grayImage = matImage.ToImage<Gray, byte>();
                grayImage._EqualizeHist();
                Rectangle[] rectangles = classifier.DetectMultiScale(grayImage,scaleSize, minNeighbours);
                if (rectangles.Count() > 0)
                {
                    var result = matImage.ToImage<Gray, byte>().Copy(rectangles[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                    result._EqualizeHist();
                    imgBox_UserFace.Image = result;
                    images.Add(result);
                    counter++;
                    
                }
            }
                await faceRecognition.AddImagesToDb(images.ToArray(), _id.Value);
                var showImage = images.FirstOrDefault().Clone();
                imgBox_UserFace.Image = showImage.Resize(imgBox_UserFace.Size.Width, imgBox_UserFace.Size.Height, Emgu.CV.CvEnum.Inter.Cubic);

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
                faceRecognition.TrainImages();

                Program.camEnter = new VideoCapture(1);
                Program.camExit = new VideoCapture(2);
                Program.camEnter.ImageGrabbed += Program.CamEnter_ImageGrabbed;
                Program.camExit.ImageGrabbed += Program.CamExit_ImageGrabbed;
                Program.faceRecognition = new FaceRecognitionDB();
                Program.camEnter.Start();
                Program.camExit.Start();


                var labels = await _labelService.Get<List<LabelDTO>>(new LabelSearchRequest { UserId = _id.Value });
                UserDTO user = await _userService.GetById<UserDTO>(_id.Value);
                string userString = user.FirstName + "-" + user.LastName;
                string pathToDirectory = Application.StartupPath + @"/../../Images/" + userString;


                Process.Start(pathToDirectory);


            }
            else
            {
                MessageBox.Show("Can't set image for unselected/non-existent user", "OK", MessageBoxButtons.OK);
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

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            var labels = await _labelService.Get<List<LabelDTO>>(new LabelSearchRequest { UserId = _id.Value});
            UserDTO user = await _userService.GetById<UserDTO>(_id.Value);
            foreach (var label in labels)
            {
                bool res = await _labelService.Delete(label.Id);
                if (!res) MessageBox.Show("Problem occured during removing images", "Info", MessageBoxButtons.OK);
            }
            string userString = user.FirstName + "-" + user.LastName;

            string pathToDirectory = Application.StartupPath + @"/../../Images/" + userString;

            if (Directory.Exists(pathToDirectory))
            {
                try
                {

                foreach( string file in Directory.GetFiles(pathToDirectory, "*.*"))
                {
                    File.Delete(file);
                }
                Directory.Delete(pathToDirectory);
                string trainingFiles = Path.GetFullPath(Application.StartupPath + @"\..\..\Images\");
                string[] trainImages = Directory.GetFiles(trainingFiles,"*.yml");
                    if (trainImages.Count() == 3)
                    {
                        foreach (var item in trainImages)
                        {
                            File.Delete(item);
                        }
                        var files = Directory.GetDirectories(trainingFiles);
                        if (files.Count() != 0)
                        {
                            faceRecognition.TrainImages();
                        }
                    }
                }
                catch (Exception)
                {

                }
                if (!Directory.Exists(pathToDirectory))
                {
                    MessageBox.Show("Successufully removed images", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("There's no data to be removed", "Info", MessageBoxButtons.OK);
            }
        }

        private async void btn_updateUser_Click(object sender, EventArgs e)
        {
            if (_id.HasValue && !string.IsNullOrEmpty(txtBox_Password.Text) && !string.IsNullOrEmpty(txtBox_Confirm.Text))
            {
                RoleDTO role = (await _roleService.Get<List<RoleDTO>>(null)).FirstOrDefault(_ => _.Name == "User");

                var updateRes = new UserInsertRequest
                {
                    UserName = txtBox_UserName.Text,
                    FirstName = txtBox_FirstName.Text,
                    LastName = txtBox_LastName.Text,
                    Password = txtBox_Password.Text,
                    PasswordConfirmation = txtBox_Confirm.Text,
                    Roles = new List<RoleDTO> { role }
                };
                var result = await _userService.Update<UserDTO>(_id.Value, updateRes);
                if (result != null)
                {
                    MessageBox.Show("User successfully changed", "Info", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("User could not be changed", "Info", MessageBoxButtons.OK);
                }

            }
        }
        }
    }

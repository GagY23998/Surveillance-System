using Emgu.CV.Face;
using Emgu;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Windows.Forms;
using Emgu.CV.Util;
using Serilog;
using AppCore.Requests;
using System.Drawing;
using System.Drawing.Imaging;

namespace Desktop
{
    public enum StateType
    {
        Entered =0,
        Left = 1
    }
    public class FaceRecognitionDB
    {
        const double threshold = double.PositiveInfinity;
        EigenFaceRecognizer faceRecognizer = new EigenFaceRecognizer(80, threshold);
        //      FisherFaceRecognizer fisherRecognizer = new FisherFaceRecognizer(80, 1000);
        //      LBPHFaceRecognizer LBPHFaceRecognizer = new LBPHFaceRecognizer(80, 1000);
        private CascadeClassifier classifier = new CascadeClassifier(@"../../Assets/haarcascade_frontalface_default.xml");
        APIService _labelService = new APIService("label");
        APIService _userService = new APIService("user");
        APIService _archiveService = new APIService("archive");
        public static bool isTrained = false;
        public FaceRecognitionDB()
        {
            try
            {
                faceRecognizer.Read(Application.StartupPath + @"/../../Images/faceRecognizer.yml");
                //fisherRecognizer.Read(Application.StartupPath + @"/../../Image/faceRecognizer.yml");

            }
            catch (Exception)
            {
            }
        }

        /*
         Functions:
         1. Add Images
         2. Save to Database
         3. Train
         4.Predict
         */
        public async Task<bool> AddImagesToDb(Image<Gray, byte>[] images, int id)
        {
            if (!images.All(_ => _.Size.Width == 100 && _.Size.Height == 100)) return false;

            images = images.Where(image => classifier.DetectMultiScale(image, 1.1, 3).Count() > 0).ToArray();

            var user = await _userService.GetById<UserDTO>(id);
            if (user == null) return false;

            string path = Application.StartupPath + @"/../../Images/" + user.FirstName + "-" + user.LastName + "/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            int totalLabels = 0;

            var labels= (await _labelService.Get<List<LabelDTO>>(null));
            if (labels.Count != 0)
            {
                totalLabels = labels.Max(_ => _.UserLabel);
            }


            foreach (var image in images)
            {
                string imagePath = path + string.Concat(user.FirstName, "-", user.LastName, "-", "image", "-", (totalLabels + 1).ToString(), ".jpg");
                AppCore.Requests.LabelInsertRequest label = new AppCore.Requests.LabelInsertRequest { UserLabel = totalLabels + 1, UserId = user.Id };

                await _labelService.Insert<LabelDTO>(label);

                image.Save(imagePath);
                ++totalLabels;
            }

            return true;

        }

        public async Task<UserDTO> Predict(Image<Gray, byte> image,StateType type)
        {
            try
            {

                if (classifier.DetectMultiScale(image, 1.1, 3).Count() > 0)
                {

                var res = faceRecognizer.Predict(image);
                //var res = fisherRecognizer.Predict(image); 

            if (res.Distance <3500)
            {
                var label = (await _labelService.Get<List<LabelDTO>>(new LabelSearchRequest { UserLabel = res.Label})).FirstOrDefault();
                var user = await _userService.GetById<UserDTO>(label.UserId);
                if (user != null)
                {
                    var logs= (await _archiveService.Get<List<LogDTO>>(new LogSearchRequest { Entered = true, UserId = user.Id, Left = false })).FirstOrDefault();
                    
                    if(type == StateType.Left)
                    {
                        if (logs != null)
                        {
                            var updateLog = new LogInsertRequest
                            {
                                UserId = logs.UserId,
                                EnteredDate = logs.EnteredDate,
                                LeftDate = DateTime.Now,
                                Entered = logs.Entered,
                                Left = true,
                                Picture = logs.Picture
                            };
                            var resUpdate = await _archiveService.Update<LogDTO>(logs.Id,updateLog);
                        
                                    if (resUpdate == null)
                                    {
                                        return null;
                                    }
                                    else
                                    {
                                        return user;
                                    }
                        }
                    }
                    else if (logs == null)
                    {
                            LogDTO result = null;
                            using(var ms = new MemoryStream())
                            {
                                    Bitmap bitmap = image.ToBitmap();
                                    bitmap.Save(ms, ImageFormat.Png);
                                    byte[] myArray = ms.ToArray();

                            result =await _archiveService.Insert<LogDTO>(new LogInsertRequest { EnteredDate = DateTime.Now,
                                                                                        Picture = myArray,
                                                                                        UserId = user.Id,
                                                                                        Entered=true,
                                                                                        Left =false});
                             
                            }
                            if (result != null) return user;
                    }
                }
                return null;
            }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        public void TrainImages()
        {

            string path = Application.StartupPath + @"/../../Images/";

            string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
            //   int[] labelsDb = _context.Labels.Select(_ => _.LabelNumber).ToArray();
            List<int> labelsDb = new List<int>();
            Mat[] matImages = new Mat[files.Length];



            for (int i = 0; i < files.Length; i++)
            {
                matImages[i] = new Image<Gray, byte>(files[i]).Mat;
                string[] strings = files[i].Split('-');
                string number = strings[strings.Length - 1].Split('.')[0];
                labelsDb.Add(int.Parse(number));
            }


            VectorOfMat images = new VectorOfMat(matImages);
            VectorOfInt labels = new VectorOfInt(labelsDb.ToArray());
            faceRecognizer.Train(images, labels);
            faceRecognizer.Write(Application.StartupPath + @"/../../Images/faceRecognizer.yml");
            //fisherRecognizer.Train(images, labels);
            //fisherRecognizer.Write(Application.StartupPath + @"/../../Images/faceRecognizer.yml");
            isTrained = true;

        }

        public async Task<bool> AddUser(string firstName, string lastName)
        {
            var users = await _userService.Get<List<UserDTO>>(null);

            if (users.Any(_ => _.FirstName == firstName && _.LastName == lastName)) return false;


            var user = new AppCore.Requests.UserInsertRequest
            {
                FirstName = firstName,
                LastName = lastName,
            };

            await _userService.Insert<UserDTO>(user);

            return true;
        }


    }
}
 
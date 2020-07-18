using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Logs
{
    public partial class frmLogDetails : Form
    {
        private int? _id = null;
        private readonly APIService _logService = new APIService("archive");
        private readonly APIService _userService = new APIService("user");
        private Form _previousForm = null;
        public frmLogDetails(Form previousForm,int? id = null)
        {
            _id = id;
            _previousForm = previousForm;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            _previousForm.Show();

        }

        private async void frmLogDetails_Load(object sender, EventArgs e)
        {
            LogDTO logDetail = await _logService.GetById<LogDTO>(_id.Value);


            if(logDetail.UserId.HasValue)
            {
                UserDTO user = await _userService.GetById<UserDTO>(logDetail.UserId);
                if (user != null)
                {
                    byte[] image = Convert.FromBase64String(logDetail.Picture);
                    using (var ms = new MemoryStream(image))
                    {
                        var bitmapImage = new Bitmap(ms);
                        bitmapImage = new Bitmap(bitmapImage, new Size(picBox_Image.Size.Width, picBox_Image.Size.Height));
                        picBox_Image.Image = bitmapImage;
                    }
                    txtBox_Visitor.Text = user.FirstName + " " + user.LastName;
                    mTxtBox_EnteredDate.Text = logDetail.EnteredDate.Value.ToString("dd.MM.yyyy HH:mm");
                    mTxtBox_LeftDate.Text = logDetail.EnteredDate.Value.ToString("dd.MM.yyyy HH:mm");
                }
                
            }
            else
            {
                label_EnteredDate.Text = "Visit: ";
                mTxtBox_EnteredDate.Text = logDetail.EnteredDate.Value.ToString("dd.MM.yyyy HH:mm");
                txtBox_Visitor.Text = "Unknown";
                mTxtBox_LeftDate.Visible = false;
                label_LeftDate.Visible = false;
            }

            var controls = this.Controls.OfType<TextBox>();
            foreach (var item in controls)
            {
                item.ReadOnly = true;
            }
            var mtxt = this.Controls.OfType<MaskedTextBox>();
            foreach (var item in mtxt)
            {
                item.ReadOnly = true;
            }

        }
    }
}

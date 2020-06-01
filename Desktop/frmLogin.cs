using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class frmLogin : Form
    {
        private readonly APIService service = new APIService("token"); 

        public frmLogin()
        {
            InitializeComponent();
            mTxtBox_Password.PasswordChar = '*';
        }

        private async void btn_SignIn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBox_UserName.Text) || string.IsNullOrEmpty(mTxtBox_Password.Text))
            {
                MessageBox.Show("Fields can't be empty", "Info", MessageBoxButtons.OK);
                return;
            }
            try
            {
                APIService.Username = txtBox_UserName.Text;
                APIService.Password = mTxtBox_Password.Text;
                var user =await service.Insert<UserDTO>(new UserInsertRequest { UserName = txtBox_UserName.Text,Password = mTxtBox_Password.Text});
                if (user != null && user.UserRoles.Any(_ => _.Role.Name == "Admin")) 
                {
                    APIService.Token = "Bearer " +user.Token;
                    MainForm frm = new MainForm();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Only admin can login", "Info", MessageBoxButtons.OK);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}

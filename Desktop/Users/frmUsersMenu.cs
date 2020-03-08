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

namespace Desktop.Users
{
    public partial class frmUsersMenu : Form
    {
        private readonly APIService _userService = new APIService("user");
        public frmUsersMenu()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(txtBox => string.IsNullOrEmpty(txtBox.Text))){
                MessageBox.Show("Fields can't be empty","Info",MessageBoxButtons.OK);
                return;
            }

            var users = await _userService.Get<List<UserDTO>>(new UserSearchRequest { FirstName = txtBox_FirstName.Text,LastName = txtBox_LastName.Text});

            if (!users.Any())
            {
                MessageBox.Show("User not found", "Info", MessageBoxButtons.OK);
                return;
            }
            dgv_Users.DataSource = new BindingSource(users, null);
            dgv_Users.Columns[0].Visible = false;
            dgv_Users.Columns[3].Visible = false;
            dgv_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser()
            {
                AutoScroll = false,
                TopLevel = false,
                WindowState = FormWindowState.Maximized
            };
            this.Parent.Controls.Add(frm);
            frm.Show();
            this.Parent.Controls.Remove(this);

        }

        private void dgv_Users_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var value = dgv_Users.SelectedRows[0].Cells[0].Value;
            frmAddUser frm = new frmAddUser(int.Parse(value.ToString()))
            {
                AutoScroll = false,
                TopLevel = false,
                WindowState = FormWindowState.Maximized
            };
            this.Parent.Controls.Add(frm);
            frm.Show();
            this.Parent.Controls.Remove(this);
        }
    }
}

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

namespace Desktop.Logs
{
    public partial class frmLogs : Form
    {

        private readonly APIService _logService = new APIService("archive");
        public frmLogs()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var txtBoxes = this.Controls.OfType<TextBoxBase>();
            foreach (var item in txtBoxes)
            {
                item.Text = string.Empty;
            }
            var chkBoxes = this.Controls.OfType<CheckBox>();
            foreach (var item in chkBoxes)
            {
                item.Checked = false;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var txtBoxes = this.Controls.OfType<TextBox>().ToArray();
            if (txtBoxes.Any(txt => string.IsNullOrEmpty(txt.Text))){
                MessageBox.Show("Fields can't be empty");
                return;
            }

            var req = new LogSearchRequest
            {
                FirstName = txtBox_FirstName.Text,
                LastName = txtBox_LastName.Text,
                FromDate = DateTime.Parse(mTxtBox_FromDate.Text),
                ToDate = DateTime.Parse(mTxtBox_ToDate.Text),
                Entered = chcBox_Entered.Checked,
                Left = chcBox_Left.Checked
            };
            var res = await _logService.Get<List<LogDTO>>(req);
            if (res != null)
            {
                dgv_Logs.DataSource = new BindingSource(res, null);
            }

        }
    }
}

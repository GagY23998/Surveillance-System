using AppCore.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
           // var txtBoxes = this.Controls.OfType<TextBox>().ToArray();
           //if (txtBoxes.All(txt => (txt.Name!="txtBox_FirstName" || txt.Name != "txtBox_LastName") && string.IsNullOrEmpty(txt.Text))){
           //     MessageBox.Show("Fields can't be empty");
           //     return;
           // }

            DateTime fromDateResult = default;
            DateTime toDateResult = default;
            DateTime.TryParseExact(mTxtBox_FromDate.Text, "dd.MM.yyyy", new CultureInfo("de-DE"), DateTimeStyles.None,out fromDateResult);
            DateTime.TryParseExact(mTxtBox_ToDate.Text, "dd.MM.yyyy", new CultureInfo("de-DE"), DateTimeStyles.None,out toDateResult);
            var req = new LogSearchRequest
            {
                FirstName = txtBox_FirstName.Text,
                LastName = txtBox_LastName.Text,
                FromDate = fromDateResult,
                ToDate = toDateResult,
                Entered = chcBox_Entered.Checked,
                Left = chcBox_Left.Checked
            };
            var res = await _logService.Get<List<LogDTO>>(req);
            if (res != null)
            {
                dgv_Logs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Logs.DataSource = new BindingSource(res, null);
                dgv_Logs.Columns[0].Visible = false;
                dgv_Logs.Columns[3].Visible = false;
                dgv_Logs.Columns[4].Visible = false;
                dgv_Logs.Columns[7].Visible = false;
            }

        }

        private void dgv_Logs_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var value = dgv_Logs.SelectedRows[0].Cells[0].Value;
                int index = int.Parse(value.ToString());

                if (index > 0)
                {
                    frmLogDetails frmLogDetails = new frmLogDetails(this, index)
                    {
                        WindowState = FormWindowState.Maximized,
                        AutoScroll = false,
                        TopLevel= false,
                        StartPosition = FormStartPosition.CenterParent
                    };
                    this.Parent.Controls.Add(frmLogDetails);
                    frmLogDetails.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

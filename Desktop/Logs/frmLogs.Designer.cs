namespace Desktop.Logs
{
    partial class frmLogs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_Logs = new System.Windows.Forms.DataGridView();
            this.txtBox_LastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_FirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTxtBox_FromDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mTxtBox_ToDate = new System.Windows.Forms.MaskedTextBox();
            this.chcBox_Entered = new System.Windows.Forms.CheckBox();
            this.chcBox_Left = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Logs
            // 
            this.dgv_Logs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Logs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Logs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Raleway Medium", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Logs.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Logs.Location = new System.Drawing.Point(52, 115);
            this.dgv_Logs.Name = "dgv_Logs";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Logs.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Logs.Size = new System.Drawing.Size(704, 299);
            this.dgv_Logs.TabIndex = 1;
            // 
            // txtBox_LastName
            // 
            this.txtBox_LastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtBox_LastName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_LastName.Location = new System.Drawing.Point(152, 46);
            this.txtBox_LastName.Name = "txtBox_LastName";
            this.txtBox_LastName.Size = new System.Drawing.Size(144, 24);
            this.txtBox_LastName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(49, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name:";
            // 
            // txtBox_FirstName
            // 
            this.txtBox_FirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtBox_FirstName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_FirstName.Location = new System.Drawing.Point(152, 16);
            this.txtBox_FirstName.Name = "txtBox_FirstName";
            this.txtBox_FirstName.Size = new System.Drawing.Size(144, 24);
            this.txtBox_FirstName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(49, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name:";
            // 
            // mTxtBox_FromDate
            // 
            this.mTxtBox_FromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.mTxtBox_FromDate.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.mTxtBox_FromDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mTxtBox_FromDate.Location = new System.Drawing.Point(373, 15);
            this.mTxtBox_FromDate.Mask = "00/00/0000";
            this.mTxtBox_FromDate.Name = "mTxtBox_FromDate";
            this.mTxtBox_FromDate.Size = new System.Drawing.Size(100, 25);
            this.mTxtBox_FromDate.TabIndex = 9;
            this.mTxtBox_FromDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(320, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(479, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "To:";
            // 
            // mTxtBox_ToDate
            // 
            this.mTxtBox_ToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.mTxtBox_ToDate.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.mTxtBox_ToDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mTxtBox_ToDate.Location = new System.Drawing.Point(512, 15);
            this.mTxtBox_ToDate.Mask = "00/00/0000";
            this.mTxtBox_ToDate.Name = "mTxtBox_ToDate";
            this.mTxtBox_ToDate.Size = new System.Drawing.Size(100, 25);
            this.mTxtBox_ToDate.TabIndex = 12;
            this.mTxtBox_ToDate.ValidatingType = typeof(System.DateTime);
            // 
            // chcBox_Entered
            // 
            this.chcBox_Entered.AutoSize = true;
            this.chcBox_Entered.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.chcBox_Entered.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chcBox_Entered.Location = new System.Drawing.Point(373, 48);
            this.chcBox_Entered.Name = "chcBox_Entered";
            this.chcBox_Entered.Size = new System.Drawing.Size(82, 22);
            this.chcBox_Entered.TabIndex = 13;
            this.chcBox_Entered.Text = "Entered";
            this.chcBox_Entered.UseVisualStyleBackColor = true;
            // 
            // chcBox_Left
            // 
            this.chcBox_Left.AutoSize = true;
            this.chcBox_Left.Font = new System.Drawing.Font("Raleway Medium", 11.25F);
            this.chcBox_Left.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chcBox_Left.Location = new System.Drawing.Point(512, 48);
            this.chcBox_Left.Name = "chcBox_Left";
            this.chcBox_Left.Size = new System.Drawing.Size(55, 22);
            this.chcBox_Left.TabIndex = 14;
            this.chcBox_Left.Text = "Left";
            this.chcBox_Left.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnSearch.Font = new System.Drawing.Font("Raleway Medium", 9.25F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(625, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 26);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Font = new System.Drawing.Font("Raleway Medium", 9.25F);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.btnReset.Location = new System.Drawing.Point(625, 47);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 26);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(163)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chcBox_Left);
            this.Controls.Add(this.chcBox_Entered);
            this.Controls.Add(this.mTxtBox_ToDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mTxtBox_FromDate);
            this.Controls.Add(this.txtBox_LastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBox_FirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Logs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogs";
            this.Text = "frmLogs";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Logs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Logs;
        private System.Windows.Forms.TextBox txtBox_LastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_FirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mTxtBox_FromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mTxtBox_ToDate;
        private System.Windows.Forms.CheckBox chcBox_Entered;
        private System.Windows.Forms.CheckBox chcBox_Left;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
    }
}
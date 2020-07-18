namespace Desktop.Logs
{
    partial class frmLogDetails
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
            this.mTxtBox_LeftDate = new System.Windows.Forms.MaskedTextBox();
            this.label_LeftDate = new System.Windows.Forms.Label();
            this.label_EnteredDate = new System.Windows.Forms.Label();
            this.mTxtBox_EnteredDate = new System.Windows.Forms.MaskedTextBox();
            this.txtBox_Visitor = new System.Windows.Forms.TextBox();
            this.label_Visitor = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.picBox_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // mTxtBox_LeftDate
            // 
            this.mTxtBox_LeftDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.mTxtBox_LeftDate.Culture = new System.Globalization.CultureInfo("de-DE");
            this.mTxtBox_LeftDate.Font = new System.Drawing.Font("Raleway Medium", 15F);
            this.mTxtBox_LeftDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mTxtBox_LeftDate.Location = new System.Drawing.Point(367, 261);
            this.mTxtBox_LeftDate.Mask = "00/00/0000 00:00";
            this.mTxtBox_LeftDate.Name = "mTxtBox_LeftDate";
            this.mTxtBox_LeftDate.Size = new System.Drawing.Size(175, 31);
            this.mTxtBox_LeftDate.TabIndex = 16;
            this.mTxtBox_LeftDate.ValidatingType = typeof(System.DateTime);
            // 
            // label_LeftDate
            // 
            this.label_LeftDate.AutoSize = true;
            this.label_LeftDate.Font = new System.Drawing.Font("Raleway Medium", 18F);
            this.label_LeftDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_LeftDate.Location = new System.Drawing.Point(252, 264);
            this.label_LeftDate.Name = "label_LeftDate";
            this.label_LeftDate.Size = new System.Drawing.Size(62, 29);
            this.label_LeftDate.TabIndex = 15;
            this.label_LeftDate.Text = "Left:";
            // 
            // label_EnteredDate
            // 
            this.label_EnteredDate.AutoSize = true;
            this.label_EnteredDate.Font = new System.Drawing.Font("Raleway Medium", 18F);
            this.label_EnteredDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_EnteredDate.Location = new System.Drawing.Point(252, 221);
            this.label_EnteredDate.Name = "label_EnteredDate";
            this.label_EnteredDate.Size = new System.Drawing.Size(107, 29);
            this.label_EnteredDate.TabIndex = 14;
            this.label_EnteredDate.Text = "Entered:";
            // 
            // mTxtBox_EnteredDate
            // 
            this.mTxtBox_EnteredDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.mTxtBox_EnteredDate.Culture = new System.Globalization.CultureInfo("de-DE");
            this.mTxtBox_EnteredDate.Font = new System.Drawing.Font("Raleway Medium", 15F);
            this.mTxtBox_EnteredDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mTxtBox_EnteredDate.Location = new System.Drawing.Point(367, 218);
            this.mTxtBox_EnteredDate.Mask = "00/00/0000 00:00";
            this.mTxtBox_EnteredDate.Name = "mTxtBox_EnteredDate";
            this.mTxtBox_EnteredDate.Size = new System.Drawing.Size(175, 31);
            this.mTxtBox_EnteredDate.TabIndex = 13;
            this.mTxtBox_EnteredDate.ValidatingType = typeof(System.DateTime);
            // 
            // txtBox_Visitor
            // 
            this.txtBox_Visitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_Visitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtBox_Visitor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_Visitor.Location = new System.Drawing.Point(367, 179);
            this.txtBox_Visitor.Name = "txtBox_Visitor";
            this.txtBox_Visitor.Size = new System.Drawing.Size(175, 30);
            this.txtBox_Visitor.TabIndex = 18;
            // 
            // label_Visitor
            // 
            this.label_Visitor.AutoSize = true;
            this.label_Visitor.Font = new System.Drawing.Font("Raleway Medium", 18F);
            this.label_Visitor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_Visitor.Location = new System.Drawing.Point(252, 183);
            this.label_Visitor.Name = "label_Visitor";
            this.label_Visitor.Size = new System.Drawing.Size(89, 29);
            this.label_Visitor.TabIndex = 17;
            this.label_Visitor.Text = "Visitor:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnBack.Font = new System.Drawing.Font("Raleway Medium", 18F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(325, 330);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 35);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picBox_Image
            // 
            this.picBox_Image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.picBox_Image.Location = new System.Drawing.Point(257, 12);
            this.picBox_Image.Name = "picBox_Image";
            this.picBox_Image.Size = new System.Drawing.Size(285, 141);
            this.picBox_Image.TabIndex = 20;
            this.picBox_Image.TabStop = false;
            // 
            // frmLogDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picBox_Image);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtBox_Visitor);
            this.Controls.Add(this.label_Visitor);
            this.Controls.Add(this.mTxtBox_LeftDate);
            this.Controls.Add(this.label_LeftDate);
            this.Controls.Add(this.label_EnteredDate);
            this.Controls.Add(this.mTxtBox_EnteredDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogDetails";
            this.Text = "LogDetails";
            this.Load += new System.EventHandler(this.frmLogDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mTxtBox_LeftDate;
        private System.Windows.Forms.Label label_LeftDate;
        private System.Windows.Forms.Label label_EnteredDate;
        private System.Windows.Forms.MaskedTextBox mTxtBox_EnteredDate;
        private System.Windows.Forms.TextBox txtBox_Visitor;
        private System.Windows.Forms.Label label_Visitor;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox picBox_Image;
    }
}
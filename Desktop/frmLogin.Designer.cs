namespace Desktop
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtBox_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTxtBox_Password = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SignIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_UserName
            // 
            this.txtBox_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.txtBox_UserName.Font = new System.Drawing.Font("Raleway Medium", 12.25F);
            this.txtBox_UserName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_UserName.Location = new System.Drawing.Point(197, 90);
            this.txtBox_UserName.Name = "txtBox_UserName";
            this.txtBox_UserName.Size = new System.Drawing.Size(133, 27);
            this.txtBox_UserName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Raleway Medium", 12.25F);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(61, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // mTxtBox_Password
            // 
            this.mTxtBox_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.mTxtBox_Password.Font = new System.Drawing.Font("Raleway Medium", 12.25F);
            this.mTxtBox_Password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.mTxtBox_Password.Location = new System.Drawing.Point(197, 178);
            this.mTxtBox_Password.Name = "mTxtBox_Password";
            this.mTxtBox_Password.Size = new System.Drawing.Size(133, 27);
            this.mTxtBox_Password.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Raleway Medium", 12.25F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(61, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // btn_SignIn
            // 
            this.btn_SignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btn_SignIn.Font = new System.Drawing.Font("Raleway Medium", 14.25F);
            this.btn_SignIn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_SignIn.Location = new System.Drawing.Point(149, 286);
            this.btn_SignIn.Name = "btn_SignIn";
            this.btn_SignIn.Size = new System.Drawing.Size(96, 31);
            this.btn_SignIn.TabIndex = 4;
            this.btn_SignIn.Text = "Log In";
            this.btn_SignIn.UseVisualStyleBackColor = false;
            this.btn_SignIn.Click += new System.EventHandler(this.btn_SignIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = global::Desktop.Properties.Resources.wrong;
            this.pictureBox1.Location = new System.Drawing.Point(347, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.ClientSize = new System.Drawing.Size(412, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_SignIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mTxtBox_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mTxtBox_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_SignIn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
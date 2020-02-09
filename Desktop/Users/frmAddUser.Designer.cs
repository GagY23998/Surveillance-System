namespace Desktop.Users
{
    partial class frmAddUser
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
            this.components = new System.ComponentModel.Container();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_FirstName = new System.Windows.Forms.TextBox();
            this.txtBox_LastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imgBox_UserFace = new Emgu.CV.UI.ImageBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetImage = new System.Windows.Forms.Button();
            this.txtBox_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBox_Confirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_UserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_UserFace)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnUsers.Font = new System.Drawing.Font("Raleway Medium", 18F);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(202, 455);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(155, 37);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Add User";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnReset.Font = new System.Drawing.Font("Raleway Medium", 18F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(435, 455);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(155, 37);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(197, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Name:";
            // 
            // txtBox_FirstName
            // 
            this.txtBox_FirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_FirstName.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.txtBox_FirstName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_FirstName.Location = new System.Drawing.Point(388, 233);
            this.txtBox_FirstName.Name = "txtBox_FirstName";
            this.txtBox_FirstName.Size = new System.Drawing.Size(202, 36);
            this.txtBox_FirstName.TabIndex = 4;
            // 
            // txtBox_LastName
            // 
            this.txtBox_LastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_LastName.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.txtBox_LastName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_LastName.Location = new System.Drawing.Point(388, 288);
            this.txtBox_LastName.Name = "txtBox_LastName";
            this.txtBox_LastName.Size = new System.Drawing.Size(202, 36);
            this.txtBox_LastName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(197, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last Name:";
            // 
            // imgBox_UserFace
            // 
            this.imgBox_UserFace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.imgBox_UserFace.Location = new System.Drawing.Point(388, 32);
            this.imgBox_UserFace.Name = "imgBox_UserFace";
            this.imgBox_UserFace.Size = new System.Drawing.Size(202, 108);
            this.imgBox_UserFace.TabIndex = 2;
            this.imgBox_UserFace.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(197, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image:";
            // 
            // btnSetImage
            // 
            this.btnSetImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnSetImage.Font = new System.Drawing.Font("Raleway Medium", 12F);
            this.btnSetImage.ForeColor = System.Drawing.Color.White;
            this.btnSetImage.Location = new System.Drawing.Point(202, 110);
            this.btnSetImage.Name = "btnSetImage";
            this.btnSetImage.Size = new System.Drawing.Size(142, 30);
            this.btnSetImage.TabIndex = 8;
            this.btnSetImage.Text = "Set Image";
            this.btnSetImage.UseVisualStyleBackColor = false;
            this.btnSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
            // 
            // txtBox_Password
            // 
            this.txtBox_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_Password.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.txtBox_Password.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_Password.Location = new System.Drawing.Point(388, 342);
            this.txtBox_Password.Name = "txtBox_Password";
            this.txtBox_Password.PasswordChar = '*';
            this.txtBox_Password.Size = new System.Drawing.Size(202, 36);
            this.txtBox_Password.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(197, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password:";
            // 
            // txtBox_Confirm
            // 
            this.txtBox_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_Confirm.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.txtBox_Confirm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_Confirm.Location = new System.Drawing.Point(388, 394);
            this.txtBox_Confirm.Name = "txtBox_Confirm";
            this.txtBox_Confirm.PasswordChar = '*';
            this.txtBox_Confirm.Size = new System.Drawing.Size(202, 36);
            this.txtBox_Confirm.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(197, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Confirm:";
            // 
            // txtBox_UserName
            // 
            this.txtBox_UserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.txtBox_UserName.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.txtBox_UserName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBox_UserName.Location = new System.Drawing.Point(388, 182);
            this.txtBox_UserName.Name = "txtBox_UserName";
            this.txtBox_UserName.Size = new System.Drawing.Size(202, 36);
            this.txtBox_UserName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Raleway Medium", 18.25F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(197, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "User Name:";
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(163)))), ((int)(((byte)(148)))));
            this.ClientSize = new System.Drawing.Size(800, 581);
            this.Controls.Add(this.txtBox_UserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBox_Confirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBox_Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSetImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imgBox_UserFace);
            this.Controls.Add(this.txtBox_LastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBox_FirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUser";
            this.Text = "frm_UserMenu";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox_UserFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_FirstName;
        private System.Windows.Forms.TextBox txtBox_LastName;
        private System.Windows.Forms.Label label2;
        private Emgu.CV.UI.ImageBox imgBox_UserFace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetImage;
        private System.Windows.Forms.TextBox txtBox_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBox_Confirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBox_UserName;
        private System.Windows.Forms.Label label6;
    }
}
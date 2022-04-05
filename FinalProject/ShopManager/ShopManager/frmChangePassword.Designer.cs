namespace ShopManager
{
    partial class frmChangePassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.tbRePass = new System.Windows.Forms.TextBox();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.tbOldPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.tbRePass);
            this.panel1.Controls.Add(this.tbNewPass);
            this.panel1.Controls.Add(this.tbOldPass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(44, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 377);
            this.panel1.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(469, 330);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(134, 34);
            this.btSave.TabIndex = 10;
            this.btSave.Text = "Lưu thay đổi";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tbRePass
            // 
            this.tbRePass.Location = new System.Drawing.Point(222, 220);
            this.tbRePass.Name = "tbRePass";
            this.tbRePass.Size = new System.Drawing.Size(381, 31);
            this.tbRePass.TabIndex = 8;
            this.tbRePass.UseSystemPasswordChar = true;
            // 
            // tbNewPass
            // 
            this.tbNewPass.Location = new System.Drawing.Point(222, 161);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.Size = new System.Drawing.Size(381, 31);
            this.tbNewPass.TabIndex = 7;
            this.tbNewPass.UseSystemPasswordChar = true;
            // 
            // tbOldPass
            // 
            this.tbOldPass.Location = new System.Drawing.Point(222, 104);
            this.tbOldPass.Name = "tbOldPass";
            this.tbOldPass.Size = new System.Drawing.Size(381, 31);
            this.tbOldPass.TabIndex = 6;
            this.tbOldPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhập lại mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // frmEditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmEditProfile";
            this.Text = "frmEditProfile";
            this.Load += new System.EventHandler(this.frmEditProfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbRePass;
        private System.Windows.Forms.TextBox tbNewPass;
        private System.Windows.Forms.TextBox tbOldPass;
    }
}
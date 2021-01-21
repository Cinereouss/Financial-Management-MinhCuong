namespace MinhCuong.View
{
    partial class frmDoiPass
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNLMK = new System.Windows.Forms.TextBox();
            this.textBoxMKMoi = new System.Windows.Forms.TextBox();
            this.textBoxMkCu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNLMK);
            this.groupBox1.Controls.Add(this.textBoxMKMoi);
            this.groupBox1.Controls.Add(this.textBoxMkCu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // textBoxNLMK
            // 
            this.textBoxNLMK.Location = new System.Drawing.Point(123, 77);
            this.textBoxNLMK.Name = "textBoxNLMK";
            this.textBoxNLMK.PasswordChar = '*';
            this.textBoxNLMK.Size = new System.Drawing.Size(158, 21);
            this.textBoxNLMK.TabIndex = 5;
            // 
            // textBoxMKMoi
            // 
            this.textBoxMKMoi.Location = new System.Drawing.Point(123, 49);
            this.textBoxMKMoi.Name = "textBoxMKMoi";
            this.textBoxMKMoi.PasswordChar = '*';
            this.textBoxMKMoi.Size = new System.Drawing.Size(158, 21);
            this.textBoxMKMoi.TabIndex = 4;
            // 
            // textBoxMkCu
            // 
            this.textBoxMkCu.Location = new System.Drawing.Point(123, 22);
            this.textBoxMkCu.Name = "textBoxMkCu";
            this.textBoxMkCu.PasswordChar = '*';
            this.textBoxMkCu.Size = new System.Drawing.Size(158, 21);
            this.textBoxMkCu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập lại mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(77, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDoiPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 163);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDoiPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNLMK;
        private System.Windows.Forms.TextBox textBoxMKMoi;
        private System.Windows.Forms.TextBox textBoxMkCu;
        private System.Windows.Forms.Button button1;
    }
}
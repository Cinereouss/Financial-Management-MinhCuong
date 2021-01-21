namespace MinhCuong.View
{
    partial class frmTaoTK
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
            this.txtTk = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtNLMK = new System.Windows.Forms.TextBox();
            this.cbbChucVu = new System.Windows.Forms.ComboBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTk
            // 
            this.txtTk.Location = new System.Drawing.Point(104, 12);
            this.txtTk.Name = "txtTk";
            this.txtTk.Size = new System.Drawing.Size(121, 21);
            this.txtTk.TabIndex = 0;
            this.txtTk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(104, 39);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(121, 21);
            this.txtMK.TabIndex = 1;
            this.txtMK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNLMK
            // 
            this.txtNLMK.Location = new System.Drawing.Point(104, 66);
            this.txtNLMK.Name = "txtNLMK";
            this.txtNLMK.PasswordChar = '*';
            this.txtNLMK.Size = new System.Drawing.Size(121, 21);
            this.txtNLMK.TabIndex = 2;
            this.txtNLMK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbbChucVu
            // 
            this.cbbChucVu.FormattingEnabled = true;
            this.cbbChucVu.Location = new System.Drawing.Point(104, 93);
            this.cbbChucVu.Name = "cbbChucVu";
            this.cbbChucVu.Size = new System.Drawing.Size(121, 21);
            this.cbbChucVu.TabIndex = 3;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(67, 120);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(110, 23);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tên tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mật khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nhập lại mật khẩu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Chức vụ:";
            // 
            // frmTaoTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 154);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.cbbChucVu);
            this.Controls.Add(this.txtNLMK);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTk);
            this.Name = "frmTaoTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo tài khoản mới";
            this.Load += new System.EventHandler(this.frmTaoTK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTk;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtNLMK;
        private System.Windows.Forms.ComboBox cbbChucVu;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
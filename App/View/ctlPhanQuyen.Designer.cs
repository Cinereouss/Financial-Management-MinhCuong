namespace MinhCuong.View
{
    partial class ctlPhanQuyen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlPhanQuyen));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnTaoTK = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewAccont = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnTaoTK,
            this.barButtonItem2,
            this.btnViewAccont});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1016, 141);
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Caption = "Tạo thêm tài khoản";
            this.btnTaoTK.Id = 1;
            this.btnTaoTK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoTK.ImageOptions.Image")));
            this.btnTaoTK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaoTK.ImageOptions.LargeImage")));
            this.btnTaoTK.LargeWidth = 80;
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTK_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Phân quyền";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.LargeWidth = 80;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnViewAccont
            // 
            this.btnViewAccont.Caption = "Xem toàn bộ tài khoản";
            this.btnViewAccont.Id = 3;
            this.btnViewAccont.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewAccont.ImageOptions.Image")));
            this.btnViewAccont.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnViewAccont.ImageOptions.LargeImage")));
            this.btnViewAccont.LargeWidth = 80;
            this.btnViewAccont.Name = "btnViewAccont";
            this.btnViewAccont.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewAccont_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản lý quyền và hệ thống tài khoản";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTaoTK);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnViewAccont);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Quản lý quyền và tài khoản";
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 141);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.Size = new System.Drawing.Size(1016, 344);
            this.xtraTabControl.TabIndex = 1;
            // 
            // ctlPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ctlPhanQuyen";
            this.Size = new System.Drawing.Size(1016, 485);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnTaoTK;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnViewAccont;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
    }
}

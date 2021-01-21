using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MinhCuong.View;
using MinhCuong.Class;

namespace MinhCuong
{

    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        AddTab addTab = new AddTab();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();

            this.Enabled = true;
            txtUser.Caption = "Tài khoản đăng nhập: " + Program.userName;
            txtPostion.Caption = "Chức vụ: " + Program.position;
            ctlPhanQuyen ctl = new ctlPhanQuyen(tabMain);
            ctl.Dock = DockStyle.Fill;
            if (Program.position == "Admin")
            {         
                ctl.AddPhanQuyen(this);
            }
            else
            {
                ctl.AddPhanQuyen(this);
                ribbonControl1.SelectedPage = ribbonControl1.MergedPages[0];
                this.ribbonControl1.UnMergeRibbon();
                ctl.Dispose();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn thực sự muốn thoát?! ", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void barButtonItemDX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Enabled = false;
            frmMain_Load(sender, e);
            
        }

        private void barButtonItemDoiMk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiPass frm = new frmDoiPass();
            frm.Show();
        }

        private void barButtonItemThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Thông tin người dùng\n" +
                "Username: " + Program.userName +
                "\nChức vụ: " + Program.position +
                "\nThời gian đăng nhập: ", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void xtraTabControlMain_ControlAdded(object sender, ControlEventArgs e)
        {
            tabMain.SelectedTabPageIndex = tabMain.TabPages.Count - 1;
        }

        private void xtraTabControlMain_CloseButtonClick(object sender, EventArgs e)
        {
            int index = tabMain.SelectedTabPageIndex;
            tabMain.TabPages.RemoveAt(index);
            if (index >= 1)
                tabMain.SelectedTabPageIndex = index - 1;
        }

        private void btnKhachVayCamDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlPhieuCam clt = new ctlPhieuCam();
            addTab.AddTabControl(tabMain, clt, "Phiếu cầm đồ");
        }
        private void btnHangTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlKhoHang ctl = new ctlKhoHang();
            addTab.AddTabControl(tabMain, ctl, "Quản lý kho");
        }

        private void btnGiaHan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlGiaHan ctl = new ctlGiaHan();
            addTab.AddTabControl(tabMain, ctl, "Gia hạn và trả lãi");
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlThuChi ctl = new ctlThuChi();
            addTab.AddTabControl(tabMain, ctl, "Quản lý thu chi");
        }

        private void btnMuonXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlMuaMuonXe ctl = new ctlMuaMuonXe();
            addTab.AddTabControl(tabMain, ctl, "Mua và cho mượn xe");
        }

        private void btnTLLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlThietLapLai ctl = new ctlThietLapLai();
            addTab.AddTabControl(tabMain, ctl, "Thiết lập lãi");
        }

        private void ctlThietLapNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlNhomHang ctl = new ctlNhomHang();
            addTab.AddTabControl(tabMain, ctl, "Thiết lập nhóm hàng hóa");
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoPhieuVay ctl = new ctlBaoCaoPhieuVay();
            addTab.AddTabControl(tabMain, ctl, "Báo cáo phiếu vay");
        }

        private void btnPhieuVay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlPhieuVay ctl = new ctlPhieuVay();
            addTab.AddTabControl(tabMain, ctl, "Phiếu vay tiền");
        }

        private void btnMuaBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlMuaBan ctl = new ctlMuaBan();
            addTab.AddTabControl(tabMain, ctl, "Mua bán hàng trong kho");
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoPhieuCam ctl = new ctlBaoCaoPhieuCam();
            addTab.AddTabControl(tabMain, ctl, "Báo cáo phiếu cầm");
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoThuChi ctl = new ctlBaoCaoThuChi();
            addTab.AddTabControl(tabMain, ctl, "Báo cáo phiếu thu chi");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoDoanhThu ctl = new ctlBaoCaoDoanhThu();
            addTab.AddTabControl(tabMain, ctl, "Báo cáo doanh thu");
        }

        private void tabMain_Click(object sender, EventArgs e)
        {

        }
    }
}

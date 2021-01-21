using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhCuong.Class
{
    class AddTab
    {
        private void AddingTabControl(XtraTabControl xtraTabParent, string xtraItem, UserControl userControl)
        {
            XtraTabPage xtraTabPage = new XtraTabPage();
            xtraTabPage.Text = xtraItem;
            xtraTabPage.Dock = DockStyle.Fill;
            xtraTabPage.Controls.Add(userControl);
            xtraTabParent.TabPages.Add(xtraTabPage);
            userControl.Dock = DockStyle.Fill;
        }

        public void AddTabControl(XtraTabControl xtraTabParent, UserControl userControl, string itemTabName)
        {
            bool isExists = false;
            foreach (XtraTabPage tabItem in xtraTabParent.TabPages)
            {
                if (tabItem.Text == itemTabName)
                {
                    isExists = true;
                    xtraTabParent.SelectedTabPage = tabItem;
                }
            }
            if (isExists == false)
            {
                AddingTabControl(xtraTabParent, itemTabName, userControl);
            }
        }
    }
}

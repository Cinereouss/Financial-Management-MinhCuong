using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using MinhCuong.View; 

namespace MinhCuong
{
    static class Program
    {
        //Khai báo tổng quan.
        public static string strConnection = "Server = localhost; Database = minhcuong; Port = 3306; User ID = root; Password =; Character Set=utf8";
        public static string userName;
        public static string passWord;
        public static bool isAuthented = false;
        public static string position;
        public static string strPermission;
        public static string themeSystem = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new frmMain());
        }
    }
}

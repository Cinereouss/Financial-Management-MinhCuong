using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhCuong.Class;

namespace MinhCuong.Class
{
    class UserDao : BaseDao
    {

        public UserDao(string connectionString):base(Program.strConnection)
        {
            connection = new MySqlConnection(connectionString);
        }

        public int CheckLogin(string usernName, string passWord = "")
        {
            string[] cols = { "*" };
            string[] conditions = { "TenTaiKhoan = @TenTaiKhoan" };

            MySqlParameter[] parameters = { new MySqlParameter("TenTaiKhoan", usernName), };
            var dataTable = Select("view_user", cols, conditions, parameters);
            try
            {
                DataRow row = dataTable.Rows[0];
                if (row["MatKhau"].ToString() == passWord)
                {
                    GetInformationUser(usernName, passWord, row["Ten"].ToString(), row["QuyenHan"].ToString());
                    return 1;
                } 
                else
                    return -1;
            }
            catch
            {
                return 0;
            }
        }

        protected void GetInformationUser(string userName, string passWord, string positionUser, string permissionString)
        {
            Program.isAuthented = true;
            Program.userName = userName;
            Program.passWord = passWord;
            Program.position = positionUser;
            Program.strPermission = permissionString;
        }

        public void DeleteInformationUser()
        {
            Program.isAuthented = false;
            Program.userName = "";
            Program.passWord = "";
            Program.position = "";
            Program.strPermission = "";
        }

        public virtual DataTable GetAll(string table)
        {
            string[] cols = { "*" };
            string[] conditions = { };

            MySqlParameter[] parameters = { };
            return Select(table, cols, conditions, parameters);
        }

        public int UpdatePassword(string newPassword)
        {
            string[] cols = { "MatKhau = @MatKhau" };
            string[] conditions = { "TenTaiKhoan = @TenTaiKhoan" };

            MySqlParameter[] parameters = { new MySqlParameter("MatKhau", newPassword), new MySqlParameter("TenTaiKhoan", Program.userName) };
            return Update("taikhoan", cols, conditions, parameters);
        }

        public int CreateUser(string newUser, string newPassword, string position)
        {
            string[] cols = { "TenTaiKhoan", "MatKhau", "ChucVuId" };
            string[] conditions = { "@TenTaiKhoan", "@MatKhau", "@ChucVuId" };

            MySqlParameter[] parameters = { new MySqlParameter("TenTaiKhoan", newUser), new MySqlParameter("MatKhau", newPassword), new MySqlParameter("ChucVuId", position) };
            return Insert("taikhoan", cols, conditions, parameters);
        }
    }
}

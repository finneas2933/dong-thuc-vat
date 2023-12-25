using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DongThucVat
{
    class Connect
    {
        public static SqlConnection ConnectDB()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                //string connString = @"Data Source=DESKTOP-I2TNFJD\SQLEXPRESS;Initial Catalog=CSDLDongThucVat;Persist Security Info=True;User ID=sa;Password=123";
                SqlConnection conn = new SqlConnection(connectionString);
                return conn;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Lỗi kết nối tới cơ sở dữ liệu: " + ex.Message);
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DongThucVat
{
    class Connect
    {
        public static SqlConnection ConnectDB()
        {
            string connString = @"Data Source=DESKTOP-I2TNFJD\SQLEXPRESS;Initial Catalog=CSDLDongThucVat;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}

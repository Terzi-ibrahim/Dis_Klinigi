using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dis_Klinigi
{
    internal class SqlKomutlari
    {


        private static string connectionString = "Server=pcName;Database=Dis_Poliklinik_Otomasyon;Trusted_Connection=True;";

       
        public static SqlConnection SqlBaglanti()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }








    }
}

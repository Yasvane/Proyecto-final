using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class ConexBD
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Data Source=." +
                            ";Initial Catalog=PruebaUSER" +
                            "; Integrated Security = True");

            cn.Open();
            return cn;
        }
    }
}

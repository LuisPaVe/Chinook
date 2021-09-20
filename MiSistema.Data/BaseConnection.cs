using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSistema.Data
{
    public class BaseConnection
    {
        public IDbConnection GetConnection()
        {
            string strconnection = ConfigurationManager.ConnectionStrings["dbChinook"].ConnectionString;
            return new SqlConnection(strconnection);

        }
    }
}

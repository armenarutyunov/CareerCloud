using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO
    {
        //protected readonly string _connString;
        //We created instance of SqlConnection type -connection which consist ll the information about connection with the DB
        //The particular DB have been described in Config File inside of "AppConfig" file (belongs to one of the assemblies)
        protected  readonly SqlConnection _connection;
        protected int ff = 1;
        public BaseADO()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }
            
    }
}

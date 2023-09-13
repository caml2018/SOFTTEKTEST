using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.infrastructure.Odbc.Context
{
    public class OdbcContext : IOdbcContext
    {
        //private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        //,string connectionString

        public OdbcContext(IConfiguration configuration )
        {
            //_connectionString = connectionString;
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            var cs = _configuration.GetConnectionString("storage");
            var conn = new SqlConnection(cs);
            conn.Open();
            return conn;
        }
    }
}

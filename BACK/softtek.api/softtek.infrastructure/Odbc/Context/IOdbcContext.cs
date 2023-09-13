using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.infrastructure.Odbc.Context
{
    public interface IOdbcContext
    {
        IDbConnection CreateConnection();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Csharp
{
    internal class DbConfig
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = @"localhost\SQLEXPRESS",
                InitialCatalog = "Chinook",
                IntegratedSecurity = true
            };

            return builder.ConnectionString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Configuration;

public static class Configuration
{
    public static string ConnectionString { get; set; }

    static Configuration()
    {
        ConnectionString = @"Data Source=DESKTOP-J6I42F2\SQLEXPRESS;Initial Catalog=User;User ID=SA;Password=123456;TrustServerCertificate=True;";
    }
}

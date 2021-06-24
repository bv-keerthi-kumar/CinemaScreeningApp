using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CinemaScreening.Infra.Data.Helper
{
    public static class ConnectionHelper 
    {
        public const string ConnectionString = @"Data Source=LP-BLR-009\SQLEXPRESS;Initial Catalog=CinemaScreening;Trusted_Connection=True;";        

        public static IConfiguration Configuration { get; }

        //public static string ConnectionString => Configuration.GetConnectionString("CinemaScreeningDB");
    }
}

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace dbUpMigrations
{
    class MainClass
    {
        public static int Main(string[] args)
        {
            var isDevelopment = true;

            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);

            if (isDevelopment) {
                configBuilder.AddUserSecrets<MainClass>();
            }
            var Configuration = configBuilder.Build();

            var sqlConnectionString = new SqlConnectionStringBuilder(
               Configuration.GetConnectionString("DemoApplication"))
            {
                UserID = Configuration["Database:DemoApplication:User_ID"],
                Password = Configuration["Database:DemoApplication:User_Password"]
            }.ConnectionString;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(sqlConnectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}

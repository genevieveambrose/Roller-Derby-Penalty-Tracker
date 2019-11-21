using Microsoft.Extensions.Configuration;
using PenaltyTracker.DAL;
using System;
using System.IO;

namespace PenaltyTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DerbyTracker");

            ISkaterDAO skaterDAO = new SkaterSqlDAO(connectionString);
            IPenatlyDAO penatlyDAO = new PenaltySqlDAO(connectionString);

            MainMenu menu = new MainMenu(skaterDAO, penatlyDAO);
            menu.RunMainMenu();
            Console.ReadLine();
        }
    }
}

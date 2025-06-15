using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using BoxingDatabase;
namespace BoxingDatabase
{
    class Program
    {
        static StorageManager storageManager;
        static ConsoleView view;

        static void Main(string[] args)
        {
            
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\farja\\OneDrive - Avondale College\\FarjadBoxingDatabase\\BoxingApp\\DB\\BoxingDatabase.mdf\";Integrated Security=True;Connect Timeout=30";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();

            string choice = view.DisplayMenu();
            switch (choice)
            {
                case "1":
                    List<Region> regions = storageManager.GetAllRegions();
                    view.DisplayRegions(regions); // Fixed by replacing 'consoleView' with 'view'
                    break;
                case "2":
                    // Update region
                    break;
                case "3":
                    InsertNewRegion();
                    break;
                case "4":
                    // Delete region
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        void UpdateRegionName()
        {
            Console.WriteLine("Enter the ID of the region you want to update:");
            int regionId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new name for the region:");
            string newName = Console.ReadLine();
            storageManager.UpdateRegionName(regionId, newName);
        }

        private static void InsertNewRegion()
        {
            Console.WriteLine("Enter the name of the new region:");
            string regionName = Console.ReadLine();
            storageManager.InsertRegion(regionName);
        }

        void DeleteRegionByName()
        {
            Console.WriteLine("Enter the name of the region you want to delete:");
            string regionName = Console.ReadLine();
            storageManager.DeleteRegionByName(regionName);
        }
    }
}

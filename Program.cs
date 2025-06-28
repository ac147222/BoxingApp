using BoxingApp;
using System;
using System.Collections.Generic;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
StorageManager storageManager = new StorageManager(connectionString);

while (true)
{
    Console.Clear();
    Console.WriteLine("\nRegion Menu:");
    Console.WriteLine("1. View Regions");
    Console.WriteLine("2. Insert Region");
    Console.WriteLine("3. Update Region");
    Console.WriteLine("4. Delete Region");
    Console.WriteLine("5. Exit Boxing App");
    Console.Write("Select an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            List<Region> regions = storageManager.GetAllRegions();
            foreach (var r in regions)
                Console.WriteLine($"{r.RegionID}: {r.RegionName}");
            Console.WriteLine("\nPress Enter to return to the Region Menu...");
            Console.ReadLine();
            break;
        case "2":
            Console.Clear();
            Console.Write("Enter new region name: ");
            string name = Console.ReadLine();
            storageManager.InsertRegion(name);
            Console.WriteLine("\nPress Enter to return to the Region Menu...");
            Console.ReadLine();
            break;
        case "3":
            Console.Clear();
            Console.Write("Enter region ID to update: ");
            int rid;
            while (!int.TryParse(Console.ReadLine(), out rid))
            {
                Console.Write("Please enter a valid integer for region ID: ");
            }
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            storageManager.UpdateRegionName(rid, newName);
            Console.WriteLine("\nPress Enter to return to the Region Menu...");
            Console.ReadLine();
            break;
        case "4":
            Console.Clear();
            Console.Write("Enter region name to delete: ");
            string delName = Console.ReadLine();
            storageManager.DeleteRegionByName(delName);
            Console.WriteLine("\nPress any key to return to the Region Menu...");
            Console.ReadLine();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid option. Press Enter to try again.");
            Console.ReadLine();
            break;
    }
}
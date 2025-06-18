using BoxingApp;
using System;
using System.Collections.Generic;

StorageManager storageManager = null;
User loggedInUser = null;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
storageManager = new StorageManager(connectionString);



static void AdminMenu(StorageManager storageManager)
{
    while (true)
    {
        Console.WriteLine("\nAdmin Menu:\n1. View Regions\n2. Insert Region\n3. Update Region\n4. Delete Region\n5. Exit");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                List<Region> regions = storageManager.GetAllRegions();
                foreach (var r in regions)
                    Console.WriteLine($"{r.Region_ID}: {r.Region_Name}");
                break;
            case "2":
                Console.Write("Enter new region name: ");
                string name = Console.ReadLine();
                storageManager.InsertRegion(name);
                break;
            case "3":
                Console.Write("Enter region ID to update: ");
                int rid = int.Parse(Console.ReadLine());
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                storageManager.UpdateRegionName(rid, newName);
                break;
            case "4":
                Console.Write("Enter region name to delete: ");
                string delName = Console.ReadLine();
                storageManager.DeleteRegionByName(delName);
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}

static void UserMenu(StorageManager storageManager)
{
    while (true)
    {
        Console.WriteLine("\nUser Menu:\n1. View Regions\n2. Exit");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                List<Region> regions = storageManager.GetAllRegions();
                foreach (var r in regions)
                    Console.WriteLine($"{r.Region_ID}: {r.Region_Name}");
                break;
            case "2":
                return;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}
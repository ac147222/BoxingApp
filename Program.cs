using BoxingApp;
using System;
using System.Collections.Generic;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
StorageManager storageManager = new StorageManager(connectionString);

bool loop = true;
do
{
    
    Console.WriteLine("\nRegion Menu:\n1. View Regions\n2. Insert Region\n3. Update Region\n4. Delete Region\n5. Exit");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            List<Region> regions = storageManager.GetAllRegions();
            foreach (var r in regions)
                Console.WriteLine($"{r.Region_ID}: {r.Region_Name}");
            loop =false;
            break;
        case "2":
            Console.Write("Enter new region name: ");
            string name = Console.ReadLine();
            storageManager.InsertRegion(name);
            loop = false;
            break;
        case "3":
            Console.Write("Enter region ID to update: ");
            int rid = int.Parse(Console.ReadLine());
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            storageManager.UpdateRegionName(rid, newName);
            loop = false;
            break;
        case "4":
            Console.Write("Enter region name to delete: ");
            string delName = Console.ReadLine();
            storageManager.DeleteRegionByName(delName);
            loop = false;
            break;
        case "5":
            loop = false;
            return;
        default:
            Console.WriteLine("Invalid option.");
            loop = true;    
            break;
    }
} while (loop);

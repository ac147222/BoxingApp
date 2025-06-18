using BoxingApp;
using System;
using System.Collections.Generic;

StorageManager storageManager = null;
User loggedInUser = null;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
storageManager = new StorageManager(connectionString);

Console.WriteLine("1. Log In\n2. Sign Up");
string option = Console.ReadLine();

if (option == "2")
{
    SignUp(storageManager);
}

Console.Write("Username: ");
string username = Console.ReadLine();
Console.Write("6-digit PIN: ");
string pin = Console.ReadLine();

loggedInUser = storageManager.AuthenticateUser(username, pin);

if (loggedInUser == null)
{
    Console.WriteLine("Invalid login.");
    return;
}

if (loggedInUser.Role == "admin")
{
    AdminMenu(storageManager);
}
else
{
    UserMenu(storageManager);
}

static void SignUp(StorageManager storageManager)
{
    Console.WriteLine("=== Sign Up ===");
    string username, pin, role;

    Console.Write("Username: ");
    username = Console.ReadLine();

    do
    {
        Console.Write("6-digit PIN: ");
        pin = Console.ReadLine();
        if (!PinValidator.IsValidPin(pin))
        {
            Console.WriteLine("PIN must be exactly 6 digits.");
        }
    } while (!PinValidator.IsValidPin(pin));

    do
    {
        Console.Write("Role (admin/user): ");
        role = Console.ReadLine();
        if (role != "admin" && role != "user")
        {
            Console.WriteLine("Role must be either 'admin' or 'user'.");
        }
    } while (role != "admin" && role != "user");

    bool success = storageManager.RegisterUser(username, pin, role);
    if (success)
        Console.WriteLine("Sign up successful! You can now log in.");
    else
        Console.WriteLine("Sign up failed. Username may already exist.");
}

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
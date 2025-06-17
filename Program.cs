using BoxingApp;
using System;
using System.Collections.Generic;

class Program
{
    static StorageManager storageManager;
    static User loggedInUser;

    static void Main(string[] args)
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        storageManager = new StorageManager(connectionString);

        Console.WriteLine("1. Log In\n2. Sign Up");
        string option = Console.ReadLine();

        if (option == "2")
        {
            SignUp();
        }

        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        loggedInUser = storageManager.AuthenticateUser(username, password);

        if (loggedInUser == null)
        {
            Console.WriteLine("Invalid login.");
            return;
        }

        if (loggedInUser.Role == "Admin")
        {
            AdminMenu();
        }
        else
        {
            UserMenu();
        }
    }

    static void SignUp()
    {
        Console.WriteLine("=== Sign Up ===");
        string username, password, email, fullName;

        Console.Write("Username: ");
        username = Console.ReadLine();

        do
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
            if (!PasswordValidater.IsValidPassword(password))
            {
                Console.WriteLine("Password must be at least 8 characters, have a number, a letter, and a symbol.");
            }
        } while (!PasswordValidater.IsValidPassword(password));

        Console.Write("Email: ");
        email = Console.ReadLine();

        Console.Write("Full Name: ");
        fullName = Console.ReadLine();

        bool success = storageManager.RegisterUser(username, password, email, fullName);
        if (success)
            Console.WriteLine("Sign up successful! You can now log in.");
        else
            Console.WriteLine("Sign up failed. Username may already exist.");
    }

    static void AdminMenu()
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

    static void UserMenu()
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
}
using BoxingApp;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BoxingApp
{
    class Program
    {
        static StorageManager storageManager;
        static User currentUser = null;

        static void Main(string[] args)
        {
            
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            storageManager = new StorageManager(conn);

            while (true)
            {
                Console.Clear();
                if (currentUser == null)
                {
                    Console.WriteLine("=== Boxing App ===");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("0. Exit");
                    Console.Write("Select an option: ");
                    switch (Console.ReadLine())
                    {
                        case "1": Login(); break;
                        case "2": Register(); break;
                        case "0":
                            conn.Close();
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Press Enter to continue.");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    if (currentUser.IsAdmin)
                        ShowAdminMenu();
                    else
                        ShowUserMenu();
                }
            }
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = storageManager.AuthenticateUser(username, password);
            if (user != null)
            {
                currentUser = user;
                Console.WriteLine("Login successful! Press Enter to continue.");
            }
            else
            {
                Console.WriteLine("Invalid credentials. Press Enter to return to menu.");
            }
            Console.ReadLine();
        }

        static void Register()
        {
            Console.Clear();
            Console.WriteLine("=== Register ===");
            Console.Write("Choose a username: ");
            string username = Console.ReadLine();
            Console.Write("Choose a password: ");
            string password = Console.ReadLine();

            bool success = storageManager.RegisterUser(username, password);
            if (success)
            {
                Console.WriteLine("Registration successful! You can now log in. Press Enter.");
            }
            else
            {
                Console.WriteLine("Username already exists. Press Enter and try again.");
            }
            Console.ReadLine();
        }

        static void ShowAdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Regions");
                Console.WriteLine("2. Add Region");
                Console.WriteLine("3. Update Region");
                Console.WriteLine("4. Delete Region");
                Console.WriteLine("5. Logout");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewRegions(); break;
                    case "2": AddRegion(); break;
                    case "3": UpdateRegion(); break;
                    case "4": DeleteRegion(); break;
                    case "5":
                        currentUser = null;
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowUserMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {currentUser.Username} (VIEW ONLY)");
                Console.WriteLine("1. View Regions");
                Console.WriteLine("2. View Weightclasses");
                Console.WriteLine("3. Logout");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewRegions(); break;
                    case "2": ViewWeightclasses(); break;
                    case "3":
                        currentUser = null;
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void ViewWeightclasses()
        {
            Console.Clear();
            var weightclassesList = storageManager.GetAllWeightclasses();
            Console.WriteLine("Weightclasses:");
            foreach (var weightclass in weightclassesList)
            {
                Console.WriteLine($"{weightclass.WeightclassesID}: {weightclass.WeightclassesName}");
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }

        static void ViewRegions()
        {
            Console.Clear();
            var regions = storageManager.GetAllRegions();
            Console.WriteLine("Regions:");
            foreach (var region in regions)
            {
                Console.WriteLine($"{region.RegionID}: {region.RegionName}");
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }

        static void AddRegion()
        {
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to add regions.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Add Region ===");
            Console.Write("Enter region name: ");
            string name = Console.ReadLine();
            storageManager.AddRegion(name);
            Console.WriteLine("Region added! Press Enter.");
            Console.ReadLine();
        }

        static void UpdateRegion()
        {
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to update regions.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Update Region ===");
            var regions = storageManager.GetAllRegions();
            foreach (var region in regions)
            {
                Console.WriteLine($"{region.RegionID}: {region.RegionName}");
            }
            Console.Write("Enter region ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new region name: ");
            string newName = Console.ReadLine();
            storageManager.UpdateRegion(id, newName);
            Console.WriteLine("Region updated! Press Enter.");
            Console.ReadLine();
        }

        static void DeleteRegion()
        {
            
            Console.Clear();
            Console.WriteLine("=== Delete Region ===");
            var regions = storageManager.GetAllRegions();
            foreach (var region in regions)
            {
                Console.WriteLine($"{region.RegionID}: {region.RegionName}");
            }
            Console.Write("Enter region ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.DeleteRegion(id);
            Console.WriteLine("Region deleted! Press Enter.");
            Console.ReadLine();
        }
    }
}
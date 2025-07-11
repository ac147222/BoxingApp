using System;
using System.Collections.Generic;
using System.Text;
using BoxingApp;
using BoxingDatabase;

namespace BoxingDatabase
{
    public class ConsoleView
    {
        
        public static void DisplayWelcomeMenu()
        {
            Console.WriteLine("=== Boxing App ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            
        }

        public static void ShowInvalidChoice()
        {
            Console.WriteLine("Invalid choice. Press Enter to continue.");
            Console.ReadLine();
        }

        public static void DisplayAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Admin Menu ===");
            Console.WriteLine("1. Manage Regions");
            Console.WriteLine("2. Manage Weightclasses");
            Console.WriteLine("3. Manage Gyms");
            Console.WriteLine("4. Manage Matches");
            Console.WriteLine("5. Manage Match Outcome Types");
            Console.WriteLine("6. Manage Fighters");
            Console.WriteLine("7. Manage Match Outcomes");
            Console.WriteLine("8. Manage Fighter and Gym records");
            Console.WriteLine("9. Reports Menu");
            Console.WriteLine("10. Log Out");
            Console.Write("Select an option: ");
        }

        
        public static void DisplayUserMenu()
        {
            Console.Clear();
            Console.WriteLine("=== User Menu ===");
            Console.WriteLine("1. View Regions");
            Console.WriteLine("2. View Weightclasses");
            Console.WriteLine("3. View Gyms");
            Console.WriteLine("4. View Matches");
            Console.WriteLine("5. View Match Outcome Types");
            Console.WriteLine("6. View Fighters");
            Console.WriteLine("7. View Match Outcomes");
            Console.WriteLine("8 View Fighters and Gym records");
            Console.WriteLine("9 Reports Menu");
            Console.WriteLine("10. Log Out");
            Console.Write("Select an option: ");
        }
        public static void DisplayReportsMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Reports Menu ===");
            Console.WriteLine("1. Fighter Report (Sorted by First Name)");
            Console.WriteLine("2. Fighter Report (Sorted by Wins");
            Console.WriteLine("3. Fighter and Gym Report");
            Console.WriteLine("4. Fighter and Weightclass Report ");
            Console.WriteLine("5. Gyms By Region Report");
            Console.WriteLine("6. Match Outcome and Details Report");
            Console.WriteLine("7. Fighter Records Report");
            Console.WriteLine("8. Number of Fighter per Gym Report (Descending)");
            Console.WriteLine("9. Gym Fight Stats Report (Sorted by Gyms with over 10 Fights Descending");
            Console.WriteLine("10. Match Count Per Year Report (Ascending)");
            Console.WriteLine("11. Average Age by Weightclass Report (Sorted in Ascending order");
            Console.WriteLine("12. Number of Matches per Fighter in 2025 (Descending");
            Console.WriteLine("13. Fighters and their Match Outcomes Report");
            Console.WriteLine("14. Back to User Menu");
            Console.Write("Select an option: ");
        }
        public static void DisplayRegionMenu()
        {

            Console.Clear();
            Console.WriteLine($"Welcome to the Regions Menu");
            Console.WriteLine("=== Region Management ===");
            Console.WriteLine("1. View Regions");
            Console.WriteLine("2. Add Region");
            Console.WriteLine("3. Update Region");
            Console.WriteLine("4. Delete Region");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

        public static void DisplayWeightclassMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Weightclasses Menu");
            Console.WriteLine("=== Weightclass Management ===");
            Console.WriteLine("1. View Weightclasses");
            Console.WriteLine("2. Add Weightclass");
            Console.WriteLine("3. Update Weightclass");
            Console.WriteLine("4. Delete Weightclass");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

        public static void DisplayGymMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Gyms Menu");
            Console.WriteLine("=== Gym Management ===");
            Console.WriteLine("1. View Gyms");
            Console.WriteLine("2. Add Gym");
            Console.WriteLine("3. Update Gym");
            Console.WriteLine("4. Delete Gym");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

        public static void DisplayMatchMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Matches Menu");
            Console.WriteLine("=== Match Management ===");
            Console.WriteLine("1. View Matches");
            Console.WriteLine("2. Add Match");
            Console.WriteLine("3. Update Match");
            Console.WriteLine("4. Delete Match");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }   

       public static void DisplayOutcomeTypeMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Match Outcome Types Menu");
            Console.WriteLine("=== Match Outcome Type Management ===");
            Console.WriteLine("1. View Match Outcome Types");
            Console.WriteLine("2. Add Match Outcome Type");
            Console.WriteLine("3. Update Match Outcome Type");
            Console.WriteLine("4. Delete Match Outcome Type");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

        public static void DisplayFighterMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Fighters Menu");
            Console.WriteLine("=== Fighter Management ===");
            Console.WriteLine("1. View Fighters");
            Console.WriteLine("2. Add Fighter");
            Console.WriteLine("3. Update Fighter");
            Console.WriteLine("4. Delete Fighter");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

        public static void DisplayMatchOutcomeMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Match Outcomes Menu");
            Console.WriteLine("=== Match Outcome Management ===");
            Console.WriteLine("1. View Match Outcomes");
            Console.WriteLine("2. Add Match Outcome");
            Console.WriteLine("3. Update Match Outcome");
            Console.WriteLine("4. Delete Match Outcome");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

        public static void DisplayFighterGymMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Fighter and Gym Records Menu");
            Console.WriteLine("=== Fighter and Gym Record Management ===");
            Console.WriteLine("1. View Fighter and Gym Records");
            Console.WriteLine("2. Add Fighter and Gym Record");
            Console.WriteLine("3. Update Fighter and Gym Record");
            Console.WriteLine("4. Delete Fighter and Gym Record");
            Console.WriteLine("5. Back to Admin Menu");
            Console.Write("Select an option: ");
        }

      

        


       
       

       


       
       
    }
}



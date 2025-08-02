using BoxingApp;
using BoxingDatabase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using static StorageManager;


// file contains all program logic
namespace BoxingApp
{
    class Program
    {
        static StorageManager storageManager;
        static User currentUser = null;

        static void Main(string[] args)
        {
            //connection string to connect to SQL database

           // string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";​
           
            string mdfPath = Path.Combine(AppContext.BaseDirectory, "BoxingDatabase.mdf");
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={mdfPath};Integrated Security=True;Connect Timeout=30;";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            storageManager = new StorageManager(conn);

            //welcome menu logic
            // Loop until the user logs in or registers, or chooses to exit
            while (true)
            {
                Console.Clear();
                if (currentUser == null)
                {
                    ConsoleView.DisplayWelcomeMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle login and registration options
                        case "1": Login(); break;
                        case "2": Register(); break;
                        case "0":
                            conn.Close();
                            return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                            
                    }
                }
                else
                {
                    if (currentUser != null && currentUser.IsAdmin)
                    {
                        ShowAdminMenu();
                    }
                    else if (currentUser != null)
                    {
                        ShowUserMenu();
                    }
                }
            }

            

            static void Login()
            {
                // Loop until the user successfully logs in or chooses to return to the main menu
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Login:");

                    // Use InputValidator for username and password
                    string username = StorageManager.InputValidator.ReadInput("Username: ");
                    string password = StorageManager.InputValidator.ReadInput("Password: ");

                    // Authenticate user using the AuthenticateUser method from StorageManager
                    var user = storageManager.AuthenticateUser(username, password);
                    if (user != null)
                    {
                        currentUser = user;
                        Console.WriteLine("Login successful. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        // If authentication fails, prompt the user to retry or return to the main menu
                        Console.Clear();
                        Console.WriteLine("Invalid credentials.");
                        Console.Write("Press R to retry or M to return to the main menu: ");
                        string choice = Console.ReadLine().Trim().ToUpper();

                        if (choice == "M")
                        {
                            break;
                        }
                    }
                }
            }
          
            //Register Logic
            static void Register()
            {
                // Loop until the user successfully registers or chooses to return to the main menu
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Register");

                    // Use InputValidator for username and password
                    string username = StorageManager.InputValidator.ReadInput("Choose a username: ");
                    string password = StorageManager.InputValidator.ReadInput("Choose a password: ");

                    // Attempt to register the user using the RegisterUser method from StorageManager
                    bool success = storageManager.RegisterUser(username, password);
                    if (success)
                    {
                        Console.WriteLine("Registration successful. You can now log in. Press Enter.");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Username already exists.");
                        Console.Write("Press R to retry or M to return to the main menu: ");
                        string choice = Console.ReadLine().Trim().ToUpper();

                        if (choice == "M")
                        {
                            break;
                        }
                    }
                }
            }


            // Menu containing all the functions regarding regions 
            static void RegionsMenu()
            {
                // Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    ConsoleView.DisplayRegionMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different region management options
                        case "1": ViewRegions(); break;
                        case "2": AddRegion(); break;
                        case "3": UpdateRegion(); break;
                        case "4": DeleteRegion(); break;
                        case "5": return;
                        // If the user chooses to return to the main menu, exit the loop
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }


                }
            }

            static void WeightclassesMenu()
            {
                while (true)
                {
                    // Display the weightclass management menu
                    ConsoleView.DisplayWeightclassMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different weightclass management options, with each option caling a specific method to handle the necessary function
                        case "1": ViewWeightclasses(); break;
                        case "2": AddWeightclasses(); break;
                        case "3": UpdateWeightclass(); break;
                        case "4": DeleteWeightclass(); break;
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void GymsMenu()
            {
                while (true)
                {
                    ConsoleView.DisplayGymMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different gym management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewGyms(); break;
                        case "2": AddGym(); break;
                        case "3": UpdateGym(); break;
                        case "4": DeleteGym(); break;
                        // If the user chooses to return to the main menu, exit the loop
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void MatchesMenu()
            {
                while (true)
                {
                    ConsoleView.DisplayMatchMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different match management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewMatches(); break;
                        case "2": AddMatch(); break;
                        case "3": UpdateMatch(); break;
                        case "4": DeleteMatch(); break;
                        // If the user chooses to return to the main menu, exit the loop
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void OutcomeTypeMenu()
            {
                while (true)
                {
                    // Display the outcome type management menu
                    ConsoleView.DisplayOutcomeTypeMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different outcome type management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewOutcomeTypes(); break;
                        case "2": AddOutcomeType(); break;
                        case "3": UpdateOutcomeType(); break;
                        case "4": DeleteOutcomeType(); break;
                        // If the user chooses to return to the main menu, exit the loop
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void FighterMenu()
            {
                // Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    ConsoleView.DisplayFighterMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different fighter management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewFighters(); break;
                        case "2": AddFighter(); break;
                        case "3": UpdateFighter(); break;
                        case "4": DeleteFighter(); break;
                        // If the user chooses to return to the main menu, exit the loop
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void MatchOutcomeMenu()
            {
                //  Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    // Display the match outcome management menu
                    ConsoleView.DisplayMatchOutcomeMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different match outcome management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewMatchOutcome(); break;
                        case "2": AddMatchOutcome(); break;
                        case "3": UpdateMatchOutcome(); break;
                        case "4": DeleteMatchOutcome(); break;
                        // If the user chooses to return to the main menu, exit the loop
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void FighterAndGymMenu()
            {
                // Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    // Display the fighter and gym management menu
                    ConsoleView.DisplayFighterGymMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different fighter and gym management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewFighterAndGym(); break;
                        case "2": AddFighterAndGym(); break;
                        case "3": UpdateFighterAndGym(); break;
                        case "4": DeleteFighterAndGym(); break;
                        // If the user chooses to return to the main menu, exit the loop
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void ShowAdminMenu()
            {
                // Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    // Display the admin management menu
                    ConsoleView.DisplayAdminMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different admin management options, with each option calling a specific method to handle the necessary function
                        case "1": RegionsMenu(); break;
                        case "2": WeightclassesMenu(); break;
                        case "3": GymsMenu(); break;
                        case "4": MatchesMenu(); break;
                        case "5": OutcomeTypeMenu(); break;
                        case "6": FighterMenu(); break;
                        case "7": MatchOutcomeMenu(); break;
                        case "8": FighterAndGymMenu(); break;
                        case "9": ReportsMenu(); break;
                        case "10":
                            // If the user chooses to log out, set currentUser to null and return to the main menu
                            currentUser = null;
                            return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void ShowUserMenu()
            {
                // Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    ConsoleView.DisplayUserMenu();

                    switch (Console.ReadLine())
                    {
                        //  Switch case to handle different user management options, with each option calling a specific method to handle the necessary function
                        case "1": ViewRegions(); break;
                        case "2": ViewWeightclasses(); break;
                        case "3": ViewGyms(); break;
                        case "4": ViewMatches(); break;
                        case "5": ViewOutcomeTypes(); break;
                        case "6": ViewFighters(); break;
                        case "7": ViewFighterAndGym(); break;
                        case "8": ViewMatchOutcome(); break;
                        case "9": ReportsMenu(); break;
                        case "10":
                            // If the user chooses to log out, set currentUser to null and return to the main menu
                            currentUser = null;
                            return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void ReportsMenu()
            {
                // Loop until the user chooses to return to the main menu or selects an option
                while (true)
                {
                    // Display the reports menu
                    ConsoleView.DisplayReportsMenu();
                    switch (Console.ReadLine())
                    {
                        // Switch case to handle different report options, with each option calling a method from StorageManager.cs to display the specific report
                        case "1": ShowFighterFirstNameReport(); break;
                        case "2": ShowFighterWinsReport(); break;
                        case "3": ShowFighterAndGymReport(); break;
                        case "4": ShowFighterWeightclassReport(); break;
                        case "5": ShowGymsByRegionReport(); break;
                        case "6": ShowMatchOutcomeDetailsReport(); break;
                        case "7": ShowFighterProfilesReport(); break;
                        case "8": ShowGymFighterCountsReport(); break;
                        case "9": ShowGymFightStatsReport(); break;
                        case "10": ShowMatchCountByYearReport(); break;
                        case "11": ShowAverageAgeByWeightclassReport(); break;
                        case "12": ShowFighterMatchCountsFor2025(); break;
                        case "13": ShowFighterMatchOutcomesReport(); break;
                        case "14": return;
                        default:
                            // If the user enters an invalid choice, display an error message and prompt to press Enter to continue
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void ShowFighterFirstNameReport()
            {
                // Display the fighter report sorted by first name by using the GetFightersSortedByFirstName method from StorageManager.cs
                Console.Clear();
                Console.WriteLine("=== Fighter Report (Sorted by First Name) ===");
                List<Fighter> fighters = storageManager.GetFightersSortedByFirstName();

                // Check if the fighters list is null or empty, and display a message accordingly
                if (fighters == null || fighters.Count == 0)
                {
                    Console.WriteLine("No fighters found.");
                }
                else
                {
                    Console.WriteLine("First Name\tLast Name");
                    foreach (var fighter in fighters)
                    {
                        Console.WriteLine($"{fighter.FirstName,-20}\t\t{fighter.LastName,-20}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterWinsReport()
            {
                // Display the fighter report sorted by wins by using the GetFightersSortedByWins method from StorageManager.cs
                Console.Clear();
                Console.WriteLine("=== Fighter Wins Report ===");

                List<Fighter> fighters = storageManager.GetFightersSortedByWins();

                // Check if the fighters list is null or empty, and display a message accordingly
                if (fighters == null || fighters.Count == 0)
                {
                    Console.WriteLine("No fighters found.");
                }
                else
                {
                    Console.WriteLine("First Name\tLast Name\tWins");
                    foreach (var fighter in fighters)
                    {
                        Console.WriteLine($"{fighter.FirstName}\t\t{fighter.LastName}\t\t{fighter.Wins}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterAndGymReport()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter and Gym Report ===");
                // Retrieve the list of fighters with their gym information using the GetFightersWithGyms method from StorageManager.cs
                var fighterGyms = storageManager.GetFightersWithGyms();
                // Check if the fighterGyms list is null or empty, and display a message accordingly
                if (fighterGyms == null || fighterGyms.Count == 0)
                {
                    Console.WriteLine("No fighters or gym info found.");
                }
                else
                {
                    Console.WriteLine("First Name\tLast Name\tGym Name");
                    foreach (var item in fighterGyms)
                    {
                        Console.WriteLine($"{item.FirstName}\t\t{item.LastName}\t\t{item.GymName}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterWeightclassReport()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter Weightclass Report ===");
                // Retrieve the list of fighters with their weightclass information
                var fighterList = storageManager.GetFightersWithWeightclasses();
                // Check if the fighterList is null or empty, and display a message accordingly
                if (fighterList == null || fighterList.Count == 0)
                {
                    Console.WriteLine("No fighter or weightclass data found.");
                }
                else
                {
                    Console.WriteLine("First Name\tLast Name\tWeightclass");
                    foreach (var fighter in fighterList)
                    {
                        Console.WriteLine($"{fighter.FirstName}\t\t{fighter.LastName}\t\t{fighter.Weightclass}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowGymsByRegionReport()
            {
                Console.Clear();
                Console.WriteLine("=== Gyms by Region Report ===");
                // Retrieve the list of region-gym pairs using the GetGymsByRegion method from StorageManager.cs
                var regionGymPairs = storageManager.GetGymsByRegion();
                // Check if the regionGymPairs list is null or empty, and display a message accordingly
                if (regionGymPairs == null || regionGymPairs.Count == 0)
                {
                    Console.WriteLine("No region-gym data found.");
                }
                else
                {
                    Console.WriteLine("Region\t\tGym");
                    foreach (var item in regionGymPairs)
                    {
                        Console.WriteLine($"{item.RegionName}\t\t{item.GymName}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowMatchOutcomeDetailsReport()
            {
                Console.Clear();
                Console.WriteLine("=== Match Outcome Details Report ===");
                // Retrieve the list of match outcome details using the GetMatchOutcomeDetails method from StorageManager.cs
                var matchDetails = storageManager.GetMatchOutcomeDetails();
                // Check if the matchDetails list is null or empty, and display a message accordingly
                if (matchDetails == null || matchDetails.Count == 0)
                {
                    Console.WriteLine("No match outcome details found.");
                }
                else
                {
                    Console.WriteLine("First Name\tLast Name\tMatch ID\tOutcome");
                    foreach (var item in matchDetails)
                    {
                        Console.WriteLine($"{item.FirstName}\t\t{item.LastName}\t\t{item.MatchID}\t\t{item.OutcomeDescription}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterProfilesReport()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter Profiles ===");
                //  Retrieve the list of fighter profiles using the GetFighterProfile method from StorageManager.cs
                var profiles = storageManager.GetFighterProfile();
                // Check if the profiles list is null or empty, and display a message accordingly
                if (profiles == null || profiles.Count == 0)
                {
                    Console.WriteLine("No fighter profiles found.");
                }
                else
                {
                    foreach (var item in profiles)
                    {
                        Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Weightclass} - {item.GymName}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowGymFighterCountsReport()
            {
                Console.Clear();
                Console.WriteLine("=== Gym Fighter Counts Report ===");
                // Retrieve the list of gym fighter counts using the GetGymFighterCounts method from StorageManager.cs
                var gymCounts = storageManager.GetGymFighterCounts();
                // Check if the gymCounts list is null or empty, and display a message accordingly
                if (gymCounts == null || gymCounts.Count == 0)
                {
                    Console.WriteLine("No gym fighter data found.");
                }
                else
                {
                    foreach (var item in gymCounts)
                    {
                        Console.WriteLine($"{item.GymName} - Fighters: {item.TotalFighters}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowGymFightStatsReport()
            {
                Console.Clear();
                Console.WriteLine("=== Gym Fight Stats Report ===");
                // Retrieve the list of gym fight stats using the GetGymFightStats method from StorageManager.cs
                var stats = storageManager.GetGymFightStats();
                // Check if the stats list is null or empty, and display a message accordingly
                if (stats == null || stats.Count == 0)
                {
                    Console.WriteLine("No gym stats found.");
                }
                else
                {
                    foreach (var item in stats)
                    {
                        Console.WriteLine($"{item.GymName} - Wins: {item.TotalWins}, Losses: {item.TotalLosses}, Draws: {item.TotalDraws}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowMatchCountByYearReport()
            {
                Console.Clear();
                Console.WriteLine("=== Match Count by Year Report ===");
                // Retrieve the list of match counts by year using the GetMatchCountByYear method from StorageManager.cs
                var matchStats = storageManager.GetMatchCountByYear();
                // Check if the matchStats list is null or empty, and display a message accordingly
                if (matchStats == null || matchStats.Count == 0)
                {
                    Console.WriteLine("No match data found for 2025.");
                }
                else
                {
                    foreach (var item in matchStats)
                    {
                        Console.WriteLine($"Year: {item.MatchYear} - Total Matches: {item.TotalMatches}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowAverageAgeByWeightclassReport()
            {
                Console.Clear();
                Console.WriteLine("=== Average Age by Weightclass Report ===");
                // Retrieve the list of average ages by weightclass using the GetAverageAgeByWeightclass method from StorageManager.cs
                var ageStats = storageManager.GetAverageAgeByWeightclass();
                // Check if the ageStats list is null or empty, and display a message accordingly
                if (ageStats == null || ageStats.Count == 0)
                {
                    Console.WriteLine("No age data found.");
                }
                else
                {
                    foreach (var item in ageStats)
                    {
                        Console.WriteLine($"{item.WeightClassName} - Average Age: {Math.Round(item.AverageAge, 1)}");
                    }
                }

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterMatchCountsFor2025()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter Match Counts for 2025 ===");
                // Retrieve the list of fighter match counts for 2025 using the GetFighterMatchCountsFor2025 method from StorageManager.cs
                var matchCounts = storageManager.GetFighterMatchCountsFor2025();
                // Check if the matchCounts list is null or empty, and display a message accordingly
                if (matchCounts == null || matchCounts.Count == 0)
                {
                    Console.WriteLine("No match data found for 2025.");
                }
                else
                {
                    foreach (var item in matchCounts)
                    {
                        Console.WriteLine($"{item.FighterFirstName} {item.FighterLastName} - Matches: {item.TotalMatches}");
                    }
                }
                // Prompt the user to press Enter to return to the previous menu
                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterMatchOutcomesReport()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter Match Outcomes Report ===");
                // Retrieve the list of fighter match outcomes using the GetFighterMatchOutcomes method from StorageManager.cs
                var outcomes = storageManager.GetFighterMatchOutcomes();
                // Check if the outcomes list is null or empty, and display a message accordingly
                if (outcomes == null || outcomes.Count == 0)
                {
                    Console.WriteLine("No match outcome data found.");
                }
                else
                {
                    foreach (var item in outcomes)
                    {
                        Console.WriteLine($"{item.FirstName} {item.LastName} - Match ID: {item.MatchID} - Outcome: {item.OutcomeDescription}");
                    }
                }
                // Prompt the user to press Enter to return to the previous menu
                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
        }

        // Methods and logic for managing weightclasses
        private static void ViewWeightclasses()
        {
            // Clears the console and retrieves all weightclasses from the storageManager method GetAllWeightclasses
            Console.Clear();
            var weightclassesList = storageManager.GetAllWeightclasses();
            Console.WriteLine("Weightclasses:");
            // Checks if the weightclassesList is null or empty, and displays a message accordingly
            if (weightclassesList == null || weightclassesList.Count == 0)
            {
                Console.WriteLine("No weightclasses found.");
            }
            else
            {
                Console.WriteLine("ID\tWeightclass");
                foreach (var weightclass in weightclassesList)
                {
                    Console.WriteLine($"{weightclass.WeightclassID}\t{weightclass.WeightclassName}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddWeightclasses()
        {
            // Loop until a valid and unique weightclass name is entered
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Add Weightclass ===");

                // Always get the latest list of weightclasses for display
                var weightclassesList = storageManager.GetAllWeightclasses();
                foreach (var weightclass in weightclassesList)
                {
                    Console.WriteLine($"{weightclass.WeightclassID}\t{weightclass.WeightclassName}");
                }

                // Use InputValidator for weightclass name input
                string name = InputValidator.ReadInput("Enter Weightclass name: ", 2, 30);

                // Check if the weightclass name is unique using the StorageManager method
                if (!storageManager.IsUniqueWeightclassName(name))
                {
                    Console.WriteLine("This weightclass already exists. Please enter a unique name.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                // If input is valid and unique, add the new weightclass and exit the loop
                storageManager.AddWeightclasses(name);
                Console.WriteLine("Weightclass added! Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void UpdateWeightclass()
        {
            var weightclassesList = storageManager.GetAllWeightclasses();
            while (true) // Loops until a valid weightclass ID is entered
            {
                Console.Clear();
                Console.WriteLine("Update Weightclasses");
                // Display all weightclasses for reference
                var weightclasses = storageManager.GetAllWeightclasses();
                foreach (var wc in weightclasses)
                {
                    Console.WriteLine($"{wc.WeightclassID}: {wc.WeightclassName}");
                }

                Console.Write("Enter Weightclass ID to update: ");
                string input = Console.ReadLine();
                // Checks if the input can be parsed to an integer and if the weightclass with that ID exists
                if (!int.TryParse(input, out int id) || !weightclasses.Any(w => w.WeightclassID == id))
                {
                    Console.Clear();
                    foreach (var weightclass in weightclassesList)
                    {
                        Console.WriteLine($"{weightclass.WeightclassID}\t{weightclass.WeightclassName}");
                    }
                    Console.WriteLine("Invalid or non-existent Weightclass ID. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Update Weightclasses");
                    foreach (var wc in weightclasses)
                    {
                        Console.WriteLine($"{wc.WeightclassID}: {wc.WeightclassName}");
                    }

                    // Use InputValidator for weightclass name input
                    string newName = InputValidator.ReadInput("Enter new weightclass name: ");

                    // Check if the new name already exists for a different weightclass (case-insensitive, trimmed)
                    if (weightclasses.Any(w => w.WeightclassID != id &&
                        string.Equals(w.WeightclassName?.Trim(), newName.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("This weightclass name already exists. Please enter a unique name.");
                        Console.WriteLine("Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                    }

                    // Update the weightclass using the storageManager method UpdateWeightclasses
                    storageManager.UpdateWeightclasses(id, newName);
                    Console.WriteLine("Weightclass updated. Press Enter.");
                    Console.ReadLine();
                    break;
                }
                break;
            }
        }
        static void DeleteWeightclass()
        {
            while (true)// Loops until a valid weightclass ID is entered
            {
                Console.Clear();
                Console.WriteLine("Delete Weightclass");
                // Retrieves all weightclasses from the storageManager method GetAllWeightclasses and displays them
                var weightclasses = storageManager.GetAllWeightclasses();
                foreach (var wc in weightclasses)
                {
                    Console.WriteLine($"{wc.WeightclassID}: {wc.WeightclassName}");
                }

                int id;
                while (true)
                {
                    // Retrieves all weightclasses from the storageManager method GetAllWeightclasses and displays them
                    var weightclass = storageManager.GetAllWeightclasses();
                    foreach (var wc in weightclasses)
                    {
                        Console.WriteLine($"{wc.WeightclassID}: {wc.WeightclassName}");
                    }

                    Console.Write("Enter Weightclass ID to delete: ");
                    string input = Console.ReadLine();

                    // Checks if the input can be parsed to an integer and if the weightclass with that ID exists
                    if (int.TryParse(input, out id) && weightclasses.Any(w => w.WeightclassID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Weightclass ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the weightclass using the storageManager method DeleteWeightclasses with the provided ID
                storageManager.DeleteWeightclasses(id);
                Console.WriteLine("Weightclass deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }

        // Methods and logic for managing matches
        private static void ViewMatches()
        {
            Console.Clear();
            // Retrieves all matches from the storageManager method GetAllMatches and displays them
            var MatchList = storageManager.GetAllMatches();
            Console.WriteLine("Matches:");
            // Checks if the MatchList is null or empty, and displays a message accordingly
            if (MatchList == null || MatchList.Count == 0)
            {
                Console.WriteLine("No Matches found.");
            }
            else
            {
                Console.WriteLine("ID\tFighter 1\tFighter 2\tDate");
                foreach (var match in MatchList)
                {
                    Console.WriteLine($"{match.MatchID}\t{match.Fighter1ID}\t\t{match.Fighter2ID}\t\t{match.MatchDate:yyyy-MM-dd}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddMatch()
        {
            Console.Clear();
            Console.WriteLine("=== Add Match ===");

            int fighter1ID = 0;
            while (true)// Loops until a valid fighter 1 ID is entered
            
                {
                // Retrieves all fighters from the storageManager method GetAllFighters and displays them
                var fighterList = storageManager.GetAllFighters();
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Fighter 1 ID: ");
                // Checks if the input can be parsed to an integer and if the fighter with that ID exists by calling the method DoesFighterExist from storageManager
                if (int.TryParse(Console.ReadLine(), out fighter1ID) && storageManager.DoesFighterExist(fighter1ID))
                    break;

                Console.WriteLine("Fighter 1 ID is invalid or does not exist.");
            }
            int fighter2ID = 0;
            while (true)
            {
                // Retrieves all fighters again to ensure the list is up-to-date after the fighter 1 ID is selected
                var fighterList = storageManager.GetAllFighters();
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Fighter 2 ID (must be different from Fighter 1): ");
                if (int.TryParse(Console.ReadLine(), out fighter2ID) &&
                    storageManager.DoesFighterExist(fighter2ID) &&
                    // Ensures that fighter2ID is not the same as fighter1ID
                    fighter2ID != fighter1ID)
                {
                    break;
                }
                Console.WriteLine("Fighter 2 ID is invalid, does not exist, or is the same as Fighter 1.");
            }
            DateTime matchDate;
            while (true)
            {
                Console.Write("Enter Match Date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out matchDate))
                    break;

                Console.WriteLine("Invalid date format.");
            }
            // Adds the match using the storageManager method AddMatch with the provided fighter1ID, fighter2ID, and matchDate
            storageManager.AddMatch(fighter1ID, fighter2ID, matchDate);
            Console.WriteLine("Match added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateMatch()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Match");
                // Retrieves all matches from the storageManager method GetAllMatches and displays them
                var matches = storageManager.GetAllMatches();
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
                }

                int matchID;
                while (true)// Loops until a valid match ID is entered
                {
                    Console.Write("Enter Match ID to update: ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to an integer and if the match with that ID exists
                    if (int.TryParse(input, out matchID) && matches.Any(m => m.MatchID == matchID))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Retrieves all matches again to ensure the list is up-to-date after the match ID is selected
                var matches1 = storageManager.GetAllMatches();
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
                }

                int fighter1ID;
                while (true)
                {
                    Console.Write("Enter new Fighter 1 ID: ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to an integer and if the fighter with that ID exists by calling the method DoesFighterExist from storageManager
                    if (int.TryParse(input, out fighter1ID) && storageManager.DoesFighterExist(fighter1ID))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Fighter 1 ID is invalid or does not exist. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Retrieves all matches again to ensure the list is up-to-date after the fighter 1 ID is selected
                var matches2 = storageManager.GetAllMatches();
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
                }

                int fighter2ID;
                while (true)
                {
                    Console.Write("Enter new Fighter 2 ID: ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to an integer and if the fighter with that ID exists by calling the method DoesFighterExist from storageManager, and also ensures that fighter2ID is not the same as fighter1ID
                    if (int.TryParse(input, out fighter2ID) &&
                        storageManager.DoesFighterExist(fighter2ID) &&
                        fighter2ID != fighter1ID)
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Fighter 2 ID is invalid, does not exist, or matches Fighter 1. Press Enter to try again.");
                    Console.ReadLine();
                }
                var matches3 = storageManager.GetAllMatches();
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
                }

                DateTime newMatchDate;
                while (true)
                {
                    Console.Write("Enter new Match Date (yyyy-MM-dd): ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to a DateTime object
                    if (DateTime.TryParse(input, out newMatchDate))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid date format. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Updates the match using the storageManager method UpdateMatch with the provided matchID, fighter1ID, fighter2ID, and newMatchDate
                storageManager.UpdateMatch(matchID, fighter1ID, fighter2ID, newMatchDate);
                Console.WriteLine("Match updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteMatch()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Match");
                // Retrieves all matches from the storageManager method GetAllMatches and displays them
                var matches = storageManager.GetAllMatches();
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
                }

                int matchID;
                while (true)
                {
                    Console.Write("Enter Match ID to delete: ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to an integer and if the match with that ID exists
                    if (int.TryParse(input, out matchID) && matches.Any(m => m.MatchID == matchID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the match using the storageManager method DeleteMatch with the provided matchID
                storageManager.DeleteMatch(matchID);
                Console.WriteLine("Match deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }

        // Methods and logic for managing Gyms
        private static void ViewGyms()
        {
            Console.Clear();
            var gymList = storageManager.GetAllGyms();
            Console.WriteLine("Gyms:");
            // Checks if the gymList is null or empty, and displays a message accordingly
            if (gymList == null || gymList.Count == 0)
            {
                Console.WriteLine("No gyms found.");
            }
            else
            {
                Console.WriteLine("ID\tGyms");
                foreach (var gyms in gymList)
                {
                    Console.WriteLine($"{gyms.GymID}\t{gyms.GymName}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddGym()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Add Gym ===");

                // Display all existing gyms for reference
                var gyms = storageManager.GetAllGyms();
                Console.WriteLine("Existing Gyms:");
                foreach (var gym in gyms)
                {
                    Console.WriteLine($"{gym.GymID}: {gym.GymName}");
                }

                // Use InputValidator for gym name input
                string name = InputValidator.ReadInput("Enter Gym name: ");

                // Check if the gym name already exists (case-insensitive, trimmed)
                if (gyms.Any(g => string.Equals(g.GymName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("This gym already exists. Please enter a unique name.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                // Display all regions for selection
                var regions = storageManager.GetAllRegions();
                foreach (var region in regions)
                {
                    Console.WriteLine($"{region.RegionID}: {region.RegionName}");
                }
                Console.Write("Enter Region ID: ");
                if (!int.TryParse(Console.ReadLine(), out int regionID))
                {
                    Console.WriteLine("Invalid input. Press Enter.");
                    Console.ReadLine();
                    continue;
                }
                if (!storageManager.DoesRegionExist(regionID))
                {
                    Console.WriteLine("Region ID not found in the system. Press Enter to return.");
                    Console.ReadLine();
                    continue;
                }

                // Add the gym using the storageManager method AddGym with the provided name and regionID
                storageManager.AddGym(name, regionID);
                Console.WriteLine("Gym added! Press Enter.");
                Console.ReadLine();
                break;
            }
        }
       static void UpdateGym()
{
    while (true) // This loop allows the user to update a gym by entering its ID
    {
        Console.Clear();
        Console.WriteLine("Update Gym");
        // Retrieve and display all gyms
        var gyms = storageManager.GetAllGyms();
        foreach (var gym in gyms)
        {
            Console.WriteLine($"{gym.GymID}: {gym.GymName}");
        }

        int id;
        while (true)
        {
            Console.Write("Enter Gym ID to update: ");
            string input = Console.ReadLine();
            // Checks if the input can be parsed to an integer and if the gym with that ID exists
            if (int.TryParse(input, out id) && gyms.Any(g => g.GymID == id))
            {
                break;
            }
            Console.Clear();
            Console.WriteLine("Invalid or non-existent Gym ID. Press Enter to try again.");
            Console.ReadLine();
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Update Gym");
            foreach (var gym in gyms)
            {
                Console.WriteLine($"{gym.GymID}: {gym.GymName}");
            }

            // Use InputValidator for gym name input
            string newName = InputValidator.ReadInput("Enter new Gym name: ");

            // Check if the new name already exists for a different gym (case-insensitive, trimmed)
            if (gyms.Any(g => g.GymID != id &&
                string.Equals(g.GymName?.Trim(), newName.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This gym name already exists. Please enter a unique name.");
                Console.WriteLine("Press Enter to try again.");
                Console.ReadLine();
                continue;
            }

            // Update the gym using the storageManager method UpdateGym with the provided ID and new name
            storageManager.UpdateGym(id, newName);
            Console.WriteLine("Gym updated. Press Enter.");
            Console.ReadLine();
            break;
        }
        break;
    }
}
        static void DeleteGym()
        {
            while (true)// This loop allows the user to delete a gym by entering its ID
            {
                
                Console.Clear();
                Console.WriteLine("Delete Gym");
                // Retrieves all gyms from the storageManager method GetAllGyms and displays them
                var gyms = storageManager.GetAllGyms();
                foreach (var gym in gyms)
                {
                    Console.WriteLine($"{gym.GymID}: {gym.GymName}");
                }
                
                var gyms1 = storageManager.GetAllGyms();
                foreach (var gym in gyms)
                {
                    Console.WriteLine($"{gym.GymID}: {gym.GymName}");
                }
                int id;
                while (true)
                {
                    Console.Write("Enter Gym ID to delete: ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to an integer and if the gym with that ID exists
                    if (int.TryParse(input, out id) && gyms.Any(g => g.GymID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the gym using the storageManager method DeleteGym with the provided ID
                storageManager.DeleteGym(id);
                Console.WriteLine("Gym deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }

        // Methods and logic for managing outcome types
        private static void ViewOutcomeTypes()
        {
            // This method retrieves all outcome types from the storageManager and displays them in a formatted table using the method GetAllOutcomeTypes
            Console.Clear();
            var outcomeTypesList = storageManager.GetAllOutcomeTypes();
            Console.WriteLine("Outcome Types:");
            // Checks if the outcomeTypesList is null or empty, and displays a message accordingly
            if (outcomeTypesList == null || outcomeTypesList.Count == 0)
            {
                Console.WriteLine("No outcomes found.");
            }
            else
            {
                Console.WriteLine("ID\tOutcome Type");
                foreach (var outcomeTypes in outcomeTypesList)
                {
                    Console.WriteLine($"{outcomeTypes.OutcomeID}\t{outcomeTypes.OutcomeDescription}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddOutcomeType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Add Outcome Type ===");

                // Always display the current list of outcome types for reference
                var outcomeTypesList = storageManager.GetAllOutcomeTypes();
                Console.WriteLine("Existing Outcome Types:");
                foreach (var outcomeType in outcomeTypesList)
                {
                    Console.WriteLine($"{outcomeType.OutcomeID}\t{outcomeType.OutcomeDescription}");
                }

                // Use InputValidator for outcome type description input
                string description = InputValidator.ReadInput("Enter Outcome Type description: ");

                // Check if the outcome type already exists (case-insensitive, trimmed)
                if (outcomeTypesList.Any(o => string.Equals(o.OutcomeDescription?.Trim(), description.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("This outcome type already exists. Please enter a unique description.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                // Add the outcome type using the storageManager method AddOutcomeType with the provided description
                storageManager.AddOutcomeType(description);
                Console.WriteLine("Outcome Type added! Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void UpdateOutcomeType()
        {
            while (true) // This loop allows the user to update an outcome type by entering its ID
            {
                Console.Clear();
                Console.WriteLine("Update Outcome Type");
                // Retrieve and display all outcome types
                var outcomeTypes = storageManager.GetAllOutcomeTypes();
                foreach (var outcomeType in outcomeTypes)
                {
                    Console.WriteLine($"{outcomeType.OutcomeID}: {outcomeType.OutcomeDescription}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Outcome Type ID to update: ");
                    string input = Console.ReadLine();
                    // Checks if the input can be parsed to an integer and if the outcome type with that ID exists
                    if (int.TryParse(input, out id) && outcomeTypes.Any(o => o.OutcomeID == id))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Outcome Type ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Update Outcome Type");
                    foreach (var outcomeType in outcomeTypes)
                    {
                        Console.WriteLine($"{outcomeType.OutcomeID}: {outcomeType.OutcomeDescription}");
                    }

                    // Use InputValidator for outcome type description input
                    string newDescription = InputValidator.ReadInput("Enter new Outcome Type description: ");

                    // Check if the new description already exists for a different outcome type (case-insensitive, trimmed)
                    if (outcomeTypes.Any(o => o.OutcomeID != id &&
                        string.Equals(o.OutcomeDescription?.Trim(), newDescription.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("This outcome type already exists. Please enter a unique description.");
                        Console.WriteLine("Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                    }

                    // Update the outcome type using the storageManager method UpdateOutcomeType with the provided ID and new description
                    storageManager.UpdateOutcomeType(id, newDescription);
                    Console.WriteLine("Outcome Type updated. Press Enter.");
                    Console.ReadLine();
                    break;
                }
                break;
            }
        }
        static void DeleteOutcomeType()
        {
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to delete outcome types.");
                Console.ReadLine();
                return;
            }

            while (true)// This loop allows the user to delete an outcome type by entering its ID
            {
                Console.Clear();
                Console.WriteLine("Delete Outcome Type");
                // Retrieves all outcome types from the storageManager method GetAllOutcomeTypes and displays them
                var outcomeTypes = storageManager.GetAllOutcomeTypes();
                foreach (var outcomeType in outcomeTypes)
                {
                    Console.WriteLine($"{outcomeType.OutcomeID}: {outcomeType.OutcomeDescription}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Outcome Type ID to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && outcomeTypes.Any(o => o.OutcomeID == id))
                        break;
                    // If the ID is invalid or does not exist, prompts the user to enter a valid ID
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Outcome Type ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the outcome type using the storageManager method DeleteOutcomeType
                storageManager.DeleteOutcomeType(id);
                Console.WriteLine("Outcome Type deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        // Methods and logic for managing fighters
        private static void ViewFighters()
        {
            // This method retrieves all fighters from the storageManager and displays them in a formatted table using them ethod GetAllFighters
            Console.Clear();
            var fighterList = storageManager.GetAllFighters();
            Console.WriteLine("Fighters:");
            // Checks if the fighterList is null or empty, and displays a message accordingly
            if (fighterList == null || fighterList.Count == 0)
            {
                Console.WriteLine("No fighters found.");
            }
            else
            {
                Console.WriteLine("ID\tFirstname\tLastname\tAge\tRegionID\tGymID\tWeightclassID\tWins\tLosses\tDraws");
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddFighter()
        {
            Console.Clear();
            Console.WriteLine("=== Add Fighter ===");

            // Use InputValidator for first name input
            string firstName = InputValidator.ReadInput("Enter Firstname: ");

            // Use InputValidator for last name input
            string lastName = InputValidator.ReadInput("Enter Lastname: ");

            int age = 0;
            while (true)
            {
                Console.Write("Enter Age (10–50): ");
                if (int.TryParse(Console.ReadLine(), out age) && age >= 10 && age <= 50)
                    break;
                Console.WriteLine("Invalid input. Age must be between 10 and 50.");
            }

            int regionID = 0;
            while (true)
            {
                var regions = storageManager.GetAllRegions();
                foreach (var region in regions)
                {
                    Console.WriteLine($"{region.RegionID}: {region.RegionName}");
                }
                Console.Write("Enter Region ID: ");
                if (int.TryParse(Console.ReadLine(), out regionID) && storageManager.DoesRegionExist(regionID))
                    break;
                Console.WriteLine("Region ID not found. Please enter a valid ID.");
            }

            int gymID = 0;
            while (true)
            {
                var gymList = storageManager.GetAllGyms();
                Console.WriteLine("ID\tGyms");
                foreach (var gyms in gymList)
                {
                    Console.WriteLine($"{gyms.GymID}\t{gyms.GymName}");
                }
                Console.Write("Enter Gym ID: ");
                if (int.TryParse(Console.ReadLine(), out gymID) && storageManager.DoesGymExist(gymID))
                    break;
                Console.WriteLine("Gym ID not found. Please enter a valid ID.");
            }

            int weightclassID = 0;
            while (true)
            {
                var weightclassesList = storageManager.GetAllWeightclasses();
                Console.WriteLine("ID\tWeightclass");
                foreach (var weightclass in weightclassesList)
                {
                    Console.WriteLine($"{weightclass.WeightclassID}\t{weightclass.WeightclassName}");
                }
                Console.Write("Enter Weightclass ID: ");
                if (int.TryParse(Console.ReadLine(), out weightclassID) && storageManager.DoesWeightclassExist(weightclassID))
                    break;
                Console.WriteLine("Weightclass ID not found. Please enter a valid ID.");
            }

            Console.Write("Enter Wins (default 0): ");
            int wins = 0;
            if (!int.TryParse(Console.ReadLine(), out wins) || wins < 0)
            {
                Console.WriteLine("Invalid input. Setting Wins to 0.");
                wins = 0;
            }
            Console.Write("Enter Losses (default 0): ");
            int losses = 0;
            if (!int.TryParse(Console.ReadLine(), out losses) || losses < 0)
            {
                Console.WriteLine("Invalid input. Setting Losses to 0.");
                losses = 0;
            }
            Console.Write("Enter Draws (default 0): ");
            int draws = 0;
            if (!int.TryParse(Console.ReadLine(), out draws) || draws < 0)
            {
                Console.WriteLine("Invalid input. Setting Draws to 0.");
                draws = 0;
            }

            storageManager.AddFighter(firstName, lastName, age, regionID, gymID, weightclassID, wins, losses, draws);
            Console.WriteLine("Fighter added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateFighter()
        {
            while (true)// runs a loop to update a fighter
            {
                Console.Clear();
                Console.WriteLine("Update Fighter");
                // Retrieves all fighters from the storageManager method GetAllFighters and displays them
                var fighters = storageManager.GetAllFighters();
                foreach (var fighter in fighters)
                {
                    Console.WriteLine($"{fighter.FighterID}: {fighter.FirstName} {fighter.LastName}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Fighter ID to update: ");
                    string input = Console.ReadLine();
                    // Prompts the user to enter a correct Fighter ID if the input is invalid or does not exist
                    if (int.TryParse(input, out id) && fighters.Any(f => f.FighterID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                // Use InputValidator for first name input
                string newFirstName = InputValidator.ReadInput("Enter new Firstname: ");

                // Use InputValidator for last name input
                string newLastName = InputValidator.ReadInput("Enter new Lastname: ");
                // Prompts the user to enter a new Age and validates it
                int newAge;
                while (true)
                {
                    Console.Write("Enter new Age (10–50): ");
                    string input = Console.ReadLine();
                    // Checks if the newAge is valid, if not prompts the user to enter a correct Age
                    if (int.TryParse(input, out newAge) && newAge >= 10 && newAge <= 50)
                        break;

                    Console.Clear();
                    Console.WriteLine("Age must be between 10 and 50. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Prompts the user to enter a new Region ID and validates it
                int newRegionID;
                while (true)
                {
                    Console.Write("Enter new Region ID: ");
                    string input = Console.ReadLine();
                    // Checks if the newRegionID is valid, if not prompts the user to enter a correct Region ID
                    if (int.TryParse(input, out newRegionID) && storageManager.DoesRegionExist(newRegionID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Region ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Prompts the user to enter a new Gym ID and validates it
                int newGymID;
                while (true)
                {
                    Console.Write("Enter new Gym ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newGymID) && storageManager.DoesGymExist(newGymID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Gym ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Prompts the user to enter a new Weightclass ID and validates it
                int newWeightclassID;
                while (true)
                {
                    Console.Write("Enter new Weightclass ID: ");
                    string input = Console.ReadLine();
                    // Checks if the newWeightclassID is valid, if not prompts the user to enter a correct Weightclass ID
                    if (int.TryParse(input, out newWeightclassID) && storageManager.DoesWeightclassExist(newWeightclassID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Weightclass ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Prompts the user to enter new Wins, Losses, and Draws, with default values set to 0 if the input is invalid or left empty
                Console.Write("Enter new Wins (default 0): ");
                if (!int.TryParse(Console.ReadLine(), out int newWins) || newWins < 0)
                {
                    Console.WriteLine("Invalid input. Setting Wins to 0.");
                    newWins = 0;
                }

                Console.Write("Enter new Losses (default 0): ");
                if (!int.TryParse(Console.ReadLine(), out int newLosses) || newLosses < 0)
                {
                    Console.WriteLine("Invalid input. Setting Losses to 0.");
                    newLosses = 0;
                }

                Console.Write("Enter new Draws (default 0): ");
                if (!int.TryParse(Console.ReadLine(), out int newDraws) || newDraws < 0)
                {
                    Console.WriteLine("Invalid input. Setting Draws to 0.");
                    newDraws = 0;
                }
                // Updates the fighter using the UpdateFighter method from the storageManager
                storageManager.UpdateFighter(id, newFirstName, newLastName, newAge, newRegionID, newGymID, newWeightclassID, newWins, newLosses, newDraws);
                Console.WriteLine("Fighter info updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteFighter()
        {
            while (true)// runs a loop to delete a fighter
            {
                Console.Clear();
                Console.WriteLine("Delete Fighter");
                // Retrieves all fighters from the storageManager method GetAllFighters and displays them
                var fighters = storageManager.GetAllFighters();
                foreach (var fighter in fighters)
                {
                    Console.WriteLine($"{fighter.FighterID}: {fighter.FirstName} {fighter.LastName}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Fighter ID to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && fighters.Any(f => f.FighterID == id))
                        break;
                    // Prompts the user to enter a correct Fighter ID if the input is invalid or does not exist
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the fighter using the DeleteFighter method from the storageManager
                storageManager.deleteFighter(id);
                Console.WriteLine("Fighter deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        // Methods and logic for managing Fighter and Gym records
        private static void ViewFighterAndGym()
        {
            // Displays all Fighter and Gym records
            Console.Clear();
            // Retrieves all Fighter and Gym records from the storageManager method GetAllFighterAndGyms
            var fighterAndGymList = storageManager.GetAllFighterAndGyms();
            Console.WriteLine("FighterAndGyms:");
            if (fighterAndGymList == null || fighterAndGymList.Count == 0)
            {
                Console.WriteLine("No fighters and gyms found.");
            }
            else
            {
                Console.WriteLine("ID\tFighterID\tGymID\tTotalWins\tTotalLosses\tTotalDraws"); // Displays the header for the Fighter and Gym records
                foreach (var fighterAndGym in fighterAndGymList)
                {
                    Console.WriteLine($"{fighterAndGym.FighterAndGymID}\t{fighterAndGym.FighterID}\t{fighterAndGym.GymID}\t{fighterAndGym.TotalWins}\t{fighterAndGym.TotalLosses}\t{fighterAndGym.TotalDraws}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddFighterAndGym()
        {
            Console.Clear();
            Console.WriteLine("=== Add Fighter and Gym ===");

            int fighterID = 0;
            while (true)// Prompts the user to enter a Fighter ID and validates it
            
                {
                // Retrieves all fighters from the storageManager method GetAllFighters and displays them
                var fighterList = storageManager.GetAllFighters();
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Fighter ID: ");
                    // Prompts the user to enter a Fighter ID and validates it
                if (int.TryParse(Console.ReadLine(), out fighterID) && storageManager.DoesFighterExist(fighterID))
                    break;
                Console.Clear();
                Console.WriteLine("Fighter ID not found. Please enter a valid ID.");
            }
            int gymID = 0;
            while (true)
            {
                // Retrieves all gyms from the storageManager method GetAllGyms and displays them
                var gymList = storageManager.GetAllGyms();
                foreach (var gyms in gymList)
                {
                    Console.WriteLine($"{gyms.GymID}\t{gyms.GymName}");
                }
                Console.Write("Enter Gym ID: ");
                if (int.TryParse(Console.ReadLine(), out gymID) && storageManager.DoesGymExist(gymID))
                    break;
                Console.Clear();
                Console.WriteLine("Gym ID not found. Please enter a valid ID.");
            }
            // Prompts the user to enter total wins, losses, and draws, with default values set to 0 if the input is invalid or left empty
            int totalWins = 0;
            while (true)
            {
                Console.Write("Enter Total Wins (default 0): ");
                if (int.TryParse(Console.ReadLine(), out totalWins) && totalWins >= 0)
                    break;

                Console.WriteLine("Invalid input. Wins must be 0 or more.");
            }
            int totalLosses = 0;
            while (true)
            {
                Console.Write("Enter Total Losses (default 0): ");
                if (int.TryParse(Console.ReadLine(), out totalLosses) && totalLosses >= 0)
                    break;

                Console.WriteLine("Invalid input. Losses must be 0 or more.");
            }
            int totalDraws = 0;
            while (true)
            {
                Console.Write("Enter Total Draws (default 0): ");
                if (int.TryParse(Console.ReadLine(), out totalDraws) && totalDraws >= 0)
                    break;
                Console.WriteLine("Invalid input. Draws must be 0 or more.");
            }
            // Adds the Fighter and Gym record using the AddFighterAndGym method from the storageManager
            storageManager.AddFighterAndGym(fighterID, gymID, totalWins, totalLosses, totalDraws);
            Console.WriteLine("Fighter and Gym linked successfully! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateFighterAndGym()
        {
            // Retrieve all gyms and fighters for display and validation
            var gyms = storageManager.GetAllGyms();
            var fighters = storageManager.GetAllFighters();

            while (true) // Loop until a valid FighterAndGym record is selected and updated
            {
                Console.Clear();
                Console.WriteLine("Update Fighter and Gym");
                // Display all FighterAndGym records for reference
                var fighterAndGyms = storageManager.GetAllFighterAndGyms();
                foreach (var fg in fighterAndGyms)
                {
                    Console.WriteLine($"{fg.FighterAndGymID}: Fighter {fg.FighterID}, Gym {fg.GymID}");
                }

                int id;
                while (true) // Prompt for FighterAndGymID and validate
                {
                    Console.Write("Enter Fighter and Gym ID to update: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && fighterAndGyms.Any(fg => fg.FighterAndGymID == id))
                        break;

                    Console.Clear();
                    // Display all FighterAndGym records again after error
                    foreach (var fg in fighterAndGyms)
                    {
                        Console.WriteLine($"{fg.FighterAndGymID}: Fighter {fg.FighterID}, Gym {fg.GymID}");
                    }
                    Console.WriteLine("Invalid or non-existent Fighter and Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newFighterID;
                while (true) // Prompt for new FighterID and validate
                {
                    Console.Clear();
                    // Display all fighters for reference
                    Console.WriteLine("Available Fighters:");
                    foreach (var fighter in fighters)
                    {
                        Console.WriteLine($"{fighter.FighterID}: {fighter.FirstName} {fighter.LastName}");
                    }

                    Console.Write("Enter new Fighter ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newFighterID) && storageManager.DoesFighterExist(newFighterID))
                        break;

                    Console.Clear();
                    // Display all fighters again after error
                    Console.WriteLine("Available Fighters:");
                    foreach (var fighter in fighters)
                    {
                        Console.WriteLine($"{fighter.FighterID}: {fighter.FirstName} {fighter.LastName}");
                    }
                    Console.WriteLine("Fighter ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newGymID;
                while (true) // Prompt for new GymID and validate
                {
                    Console.Clear();
                    // Display all gyms for reference
                    Console.WriteLine("Available Gyms:");
                    foreach (var gym in gyms)
                    {
                        Console.WriteLine($"{gym.GymID}: {gym.GymName}");
                    }

                    Console.Write("Enter new Gym ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newGymID) && storageManager.DoesGymExist(newGymID))
                        break;

                    Console.Clear();
                    // Display all gyms again after error
                    Console.WriteLine("Available Gyms:");
                    foreach (var gym in gyms)
                    {
                        Console.WriteLine($"{gym.GymID}: {gym.GymName}");
                    }
                    Console.WriteLine("Gym ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }

                // Prompt for total wins, losses, and draws, with default values set to 0 if invalid
                Console.Write("Enter Total Wins (default 0): ");
                if (!int.TryParse(Console.ReadLine(), out int totalWins) || totalWins < 0)
                {
                    Console.WriteLine("Invalid input. Setting Total Wins to 0.");
                    totalWins = 0;
                }

                Console.Write("Enter Total Losses (default 0): ");
                if (!int.TryParse(Console.ReadLine(), out int totalLosses) || totalLosses < 0)
                {
                    Console.WriteLine("Invalid input. Setting Total Losses to 0.");
                    totalLosses = 0;
                }

                Console.Write("Enter Total Draws (default 0): ");
                if (!int.TryParse(Console.ReadLine(), out int totalDraws) || totalDraws < 0)
                {
                    Console.WriteLine("Invalid input. Setting Total Draws to 0.");
                    totalDraws = 0;
                }

                // Update the FighterAndGym record using the UpdateFighterAndGym method from storageManager
                storageManager.UpdateFighterAndGym(id, newFighterID, newGymID, totalWins, totalLosses, totalDraws);
                Console.WriteLine("Fighter and Gym updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteFighterAndGym()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Fighter and Gym");
                // Retrieves all Fighter and Gym records by calling the GetAllFighterAndGyms method from the storageManager
                var fighterAndGyms = storageManager.GetAllFighterAndGyms();
                foreach (var fg in fighterAndGyms)
                {
                    Console.WriteLine($"{fg.FighterAndGymID}: Fighter {fg.FighterID}, Gym {fg.GymID}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Fighter and Gym ID to delete: ");
                    string input = Console.ReadLine();
                    // Validates the input to ensure it is a number and exists in the Fighter and Gym records list
                    if (int.TryParse(input, out id) && fighterAndGyms.Any(fg => fg.FighterAndGymID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter and Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the Fighter and Gym record using the DeleteFighterAndGym method from the storageManager
                storageManager.DeleteFighterAndGym(id);
                Console.WriteLine("Fighter and Gym deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        // Methods and logic for managing match outcomes
        private static void ViewMatchOutcome()
        {
            // Clears the console and retrieves all match outcomes from the storageManager
            Console.Clear();
            var matchOutcomesList = storageManager.GetAllMatchOutcomes();
            Console.WriteLine("Match outcomes:");
            // Checks if the match outcomes list is null or empty, and displays a message accordingly
            if (matchOutcomesList == null || matchOutcomesList.Count == 0)
            {
                Console.WriteLine("No Match outcomes found.");
            }
            else
            {
                Console.WriteLine("ID\tMatchID\tWinnerID(FighterID)\tOutcomeID");
                foreach (var matchOutcome in matchOutcomesList)
                {
                    Console.WriteLine($"{matchOutcome.MatchOutcomeID}\t{matchOutcome.MatchID}\t{matchOutcome.WinnerID}\t{matchOutcome.OutcomeID}");
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }
        static void AddMatchOutcome()
        {
            Console.Clear();
            Console.WriteLine("=== Add Match Outcome ===");

            int matchID = 0;
            while (true)
            {
                // Retrieves all matches from the storageManager and displays them
                var MatchList = storageManager.GetAllMatches();
                Console.WriteLine("ID\tFighter 1\tFighter 2\tDate");
                foreach (var match in MatchList)
                {
                    Console.WriteLine($"{match.MatchID}\t{match.Fighter1ID}\t\t{match.Fighter2ID}\t\t{match.MatchDate:yyyy-MM-dd}");
                }
                Console.Write("Enter Match ID: ");
                // Validates the input to ensure it is a number and exists in the matches list, using the DoesMatchExist method from StorageManager.cs
                if (int.TryParse(Console.ReadLine(), out matchID) && storageManager.DoesMatchExist(matchID))
                    break;
                Console.Clear();
                Console.WriteLine("Match ID not found in the system. Please try again.");
            }
            
            int winnerID = 0;
            while (true)
            {
                var fighterList = storageManager.GetAllFighters();
                Console.WriteLine("ID\tFighterID\tGymID\tTotalWins\tTotalLosses\tTotalDraws");
                // Displays all fighters with their details
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Winner ID (FighterID): ");
                // Validates the input to ensure it is a number and exists in the fighters list, using the DoesFighterExist method from StorageManager.cs
                if (int.TryParse(Console.ReadLine(), out winnerID) && storageManager.DoesFighterExist(winnerID))
                    break;
                Console.Clear();
                Console.WriteLine("Winner ID not found in the system. Please try again.");
            }
            int outcomeID = 0;
            while (true)// Loop until a valid Outcome ID is provided
            {
                // Retrieves all outcome types from the storageManager and displays them
                var outcomeTypesList = storageManager.GetAllOutcomeTypes();
                Console.WriteLine("ID\tOutcome Type");
                foreach (var outcomeTypes in outcomeTypesList)
                {
                    Console.WriteLine($"{outcomeTypes.OutcomeID}\t{outcomeTypes.OutcomeDescription}");
                }
                Console.Write("Enter Outcome ID: ");
                // Validates the input to ensure it is a number and exists in the outcome types list, using the DoesOutcomeTypeExist method from StorageManager.cs
                if (int.TryParse(Console.ReadLine(), out outcomeID) && storageManager.DoesOutcomeTypeExist(outcomeID))
                    break;
                Console.Clear();
                Console.WriteLine("Outcome ID not found in the system. Please try again.");
            }
            // Adds the match outcome using the method AddMatchOutcome from the storageManager
            storageManager.AddMatchOutcome(matchID, winnerID, outcomeID);
            Console.WriteLine("Match outcome added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateMatchOutcome()
        {
            while (true) // Loop until a valid match outcome is updated
            {
                Console.Clear();
                Console.WriteLine("Update Match Outcome");
                // Retrieves all match outcomes from the storageManager
                var matchOutcomes = storageManager.GetAllMatchOutcomes();
                foreach (var outcome in matchOutcomes)
                {
                    Console.WriteLine($"{outcome.MatchOutcomeID}: Match {outcome.MatchID}, Winner {outcome.WinnerID}, Outcome {outcome.OutcomeID}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Match Outcome ID to update: ");
                    string input = Console.ReadLine();// Validates the input to ensure it is a number and exists in the match outcomes list
                    if (int.TryParse(input, out id) && matchOutcomes.Any(o => o.MatchOutcomeID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match Outcome ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newMatchID;
                while (true)
                {
                    Console.Write("Enter new Match ID: ");
                    string input = Console.ReadLine();
                    // Validates the input to ensure it is a number and exists in the matches list
                    if (int.TryParse(input, out newMatchID) && storageManager.DoesMatchExist(newMatchID))
                        break;
                    // If the input is invalid, it clears the console and prompts the user again
                    Console.Clear();
                    Console.WriteLine("Match ID not found in the system. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newWinnerID;
                while (true) // Loop until a valid Winner ID is provided
                {
                    Console.Write("Enter new Winner ID (FighterID): ");
                    string input = Console.ReadLine();
                    // Validates the input to ensure it is a number and exists in the fighters list
                    if (int.TryParse(input, out newWinnerID) && storageManager.DoesFighterExist(newWinnerID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Winner ID not found in the system. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newOutcomeID;
                while (true)// Loop until a valid Outcome ID is provided
                {
                    Console.Write("Enter new Outcome ID: ");
                    string input = Console.ReadLine();
                    // Validates the input to ensure it is a number and exists in the outcome types list
                    if (int.TryParse(input, out newOutcomeID) && storageManager.DoesOutcomeTypeExist(newOutcomeID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Outcome ID not found in the system. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Updates the match outcome using the method updateMatchOutcome from the storageManager
                storageManager.updateMatchOutcome(id, newMatchID, newWinnerID, newOutcomeID);
                Console.WriteLine("Match outcome updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteMatchOutcome()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Match Outcome");
                // Retrieves all match outcomes from the storageManager
                var matchOutcomes = storageManager.GetAllMatchOutcomes();
                foreach (var outcome in matchOutcomes)
                {
                    Console.WriteLine($"{outcome.MatchOutcomeID}: Match {outcome.MatchID}, Winner {outcome.WinnerID}, Outcome {outcome.OutcomeID}");
                }

                int id;
                while (true) // Loop until a valid Match Outcome ID is provided
                
                    {
                    Console.Write("Enter Match Outcome ID to delete: ");
                    string input = Console.ReadLine();
                    // Validates the input to ensure it is a number and exists in the match outcomes list
                    if (int.TryParse(input, out id) && matchOutcomes.Any(o => o.MatchOutcomeID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match Outcome ID. Press Enter to try again.");
                    Console.ReadLine();
                }
                // Deletes the match outcome using the method deleteMatchOutcome from the storageManager
                storageManager.deleteMatchOutcome(id);
                Console.WriteLine("Match outcome deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        // Methods and logic for managing regions
        private static void ViewRegions()
        {

            Console.Clear();
            // Calls the GetAllRegions method from the storageManager to retrieve all regions
            var regions = storageManager.GetAllRegions();
            Console.WriteLine("Regions:");
            foreach (var region in regions)
            {
                // Displays each region's ID and name
                Console.WriteLine($"{region.RegionID}: {region.RegionName}");
            }
            // Prompts the user to press Enter to return to the previous menu
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }

        // Method to add a new region to the database with input validation, uniqueness check, and user feedback
        static void AddRegion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Add Region ===");
                // Display all existing regions for reference
                var regions = storageManager.GetAllRegions();
                foreach (var region in regions)
                {
                    Console.WriteLine($"{region.RegionID}: {region.RegionName}");
                }
                // Use InputValidator for region name input
                string name = InputValidator.ReadInput("Enter region name: ");
                // Check if the region name already exists (case-insensitive, trimmed)
                if (regions.Any(r => string.Equals(r.RegionName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("This region already exists. Please enter a unique name.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }
                // Add the new region using the StorageManager method
                storageManager.AddRegion(name);
                Console.WriteLine("Region added! Press Enter.");
                Console.ReadLine();
                break;
            }
        }

        static void UpdateRegion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Region");
                var regions = storageManager.GetAllRegions();
                foreach (var region in regions)
                {
                    Console.WriteLine($"{region.RegionID}: {region.RegionName}");
                }
                Console.Write("Enter region ID to update: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id) || !regions.Any(r => r.RegionID == id))
                {
                    Console.WriteLine("Invalid or non-existent region ID.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Update Region");
                    foreach (var region in regions)
                    {
                        Console.WriteLine($"{region.RegionID}: {region.RegionName}");
                    }
                    // Use InputValidator for region name input
                    string newName = InputValidator.ReadInput("Enter new region name: ");
                  
                    storageManager.UpdateRegion(id, newName);
                    Console.WriteLine("Region updated. Press Enter.");
                    Console.ReadLine();
                    break;
                }
                break;
            }
        }

        static void DeleteRegion()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Region");
                var regions = storageManager.GetAllRegions();
                foreach (var region in regions)
                {
                    Console.WriteLine($"{region.RegionID}: {region.RegionName}");
                }
                Console.Write("Enter region ID to delete: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id) || !regions.Any(r => r.RegionID == id))
                {
                    Console.WriteLine("Invalid or non-existent region ID.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }
                storageManager.DeleteRegion(id);
                Console.WriteLine("Region deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
    }
}
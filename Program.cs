using BoxingApp;
using BoxingDatabase;
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
                    ConsoleView.DisplayWelcomeMenu();
                    switch (Console.ReadLine())
                    {
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
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Login:");

                    string username;
                    do
                    {
                        Console.Write("Username: ");
                        username = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(username))
                        {
                            Console.Clear();
                            Console.WriteLine("Username cannot be blank. Please enter a valid username.");
                        }
                    } while (string.IsNullOrWhiteSpace(username));

                    string password;
                    do
                    {
                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(password))
                        {
                            Console.Clear();
                            Console.WriteLine("Password cannot be blank. Please enter a valid password.");
                        }
                    } while (string.IsNullOrWhiteSpace(password));

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
                        Console.WriteLine("Invalid credentials. Press Enter to try again.");
                        Console.ReadLine();
                    }
                }
            }

            static void Register()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Register");

                    string username;
                    do
                    {
                        Console.Write("Choose a username: ");
                        username = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(username))
                        {
                            Console.Clear();
                            Console.WriteLine("Username cannot be blank. Please enter a valid username.");
                        }
                    } while (string.IsNullOrWhiteSpace(username));

                    string password;
                    do
                    {
                        Console.Write("Choose a password: ");
                        password = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(password))
                        {
                            Console.Clear();
                            Console.WriteLine("Password cannot be blank. Please enter a valid password.");
                        }
                    } while (string.IsNullOrWhiteSpace(password));

                    bool success = storageManager.RegisterUser(username, password);
                    if (success)
                    {
                        Console.WriteLine("Registration successful. You can now log in. Press Enter.");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username already exists. Press Enter to try again.");
                        Console.ReadLine();
                    }
                }
            }


            static void RegionsMenu()
            {

                while (true)
                {
                    ConsoleView.DisplayRegionMenu();
                    switch (Console.ReadLine())
                    {
                        case "1": ViewRegions(); break;
                        case "2": AddRegion(); break;
                        case "3": UpdateRegion(); break;
                        case "4": DeleteRegion(); break;
                        case "5": return;
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
                    ConsoleView.DisplayWeightclassMenu();
                    switch (Console.ReadLine())
                    {
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
                        case "1": ViewGyms(); break;
                        case "2": AddGym(); break;
                        case "3": UpdateGym(); break;
                        case "4": DeleteGym(); break;
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
                        case "1": ViewMatches(); break;
                        case "2": AddMatch(); break;
                        case "3": UpdateMatch(); break;
                        case "4": DeleteMatch(); break;
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
                    ConsoleView.DisplayOutcomeTypeMenu();
                    switch (Console.ReadLine())
                    {
                        case "1": ViewOutcomeTypes(); break;
                        case "2": AddOutcomeType(); break;
                        case "3": UpdateOutcomeType(); break;
                        case "4": DeleteOutcomeType(); break;
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void FighterMenu()
            {
                while (true)
                {
                    ConsoleView.DisplayFighterMenu();
                    switch (Console.ReadLine())
                    {
                        case "1": ViewFighters(); break;
                        case "2": AddFighter(); break;
                        case "3": UpdateFighter(); break;
                        case "4": DeleteFighter(); break;
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void MatchOutcomeMenu()
            {
                while (true)
                {
                    ConsoleView.DisplayMatchOutcomeMenu();
                    switch (Console.ReadLine())
                    {
                        case "1": ViewMatchOutcome(); break;
                        case "2": AddMatchOutcome(); break;
                        case "3": UpdateMatchOutcome(); break;
                        case "4": DeleteMatchOutcome(); break;
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void FighterAndGymMenu()
            {
                while (true)
                {
                    ConsoleView.DisplayFighterGymMenu();
                    switch (Console.ReadLine())
                    {
                        case "1": ViewFighterAndGym(); break;
                        case "2": AddFighterAndGym(); break;
                        case "3": UpdateFighterAndGym(); break;
                        case "4": DeleteFighterAndGym(); break;
                        case "5": return;
                        default:
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void ShowAdminMenu()
            {
                while (true)
                {
                    ConsoleView.DisplayAdminMenu();
                    switch (Console.ReadLine())
                    {
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
                while (true)
                {
                    ConsoleView.DisplayUserMenu();

                    switch (Console.ReadLine())
                    {
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
                while (true)
                {
                    ConsoleView.DisplayReportsMenu();
                    switch (Console.ReadLine())
                    {
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
                            ConsoleView.ShowInvalidChoice();
                            break;
                    }
                }
            }

            static void ShowFighterFirstNameReport()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter Report (Sorted by First Name) ===");
                List<Fighter> fighters = storageManager.GetFightersSortedByFirstName();

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
                Console.Clear();
                Console.WriteLine("=== Fighter Wins Report ===");

                List<Fighter> fighters = storageManager.GetFightersSortedByWins();

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

                var fighterGyms = storageManager.GetFightersWithGyms();

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

                var fighterList = storageManager.GetFightersWithWeightclasses();

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

                var regionGymPairs = storageManager.GetGymsByRegion();

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

                var matchDetails = storageManager.GetMatchOutcomeDetails();

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

                var profiles = storageManager.GetFighterProfile();

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

                var gymCounts = storageManager.GetGymFighterCounts();

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

                var stats = storageManager.GetGymFightStats();

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

                var matchStats = storageManager.GetMatchCountByYear();

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

                var ageStats = storageManager.GetAverageAgeByWeightclass();

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

                var matchCounts = storageManager.GetFighterMatchCountsFor2025();

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

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
            static void ShowFighterMatchOutcomesReport()
            {
                Console.Clear();
                Console.WriteLine("=== Fighter Match Outcomes Report ===");

                var outcomes = storageManager.GetFighterMatchOutcomes();

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

                Console.WriteLine("\nPress Enter to return.");
                Console.ReadLine();
            }
        }


        private static void ViewWeightclasses()
        {
            Console.Clear();
            var weightclassesList = storageManager.GetAllWeightclasses();
            Console.WriteLine("Weightclasses:");
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
            Console.Clear();
            Console.WriteLine("=== Add Weightclass ===");
            string name = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Enter Weightclass name (letters only): ");
                name = Console.ReadLine();
                if (name.Length > 0 && name.All(char.IsLetter))
                {
                    isValid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Only letters allowed. Don't leave it blank.");
                }
            }
            storageManager.AddWeightclasses(name);
            Console.WriteLine("Weightclass added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateWeightclass()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Weightclasses");

                var weightclasses = storageManager.GetAllWeightclasses();
                foreach (var wc in weightclasses)
                {
                    Console.WriteLine($"{wc.WeightclassID}: {wc.WeightclassName}");
                }

                Console.Write("Enter Weightclass ID to update: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int id) || !weightclasses.Any(w => w.WeightclassID == id))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Weightclass ID. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }
                string newName;
                do
                {
                    Console.Write("Enter new weightclass name: ");
                    newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        Console.Clear();
                        Console.WriteLine("Weightclass name cannot be blank.");
                    }
                    else if (!newName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.Clear();
                        Console.WriteLine("Weightclass name must contain only letters and spaces.");
                        newName = string.Empty;
                    }
                } while (string.IsNullOrWhiteSpace(newName));

                storageManager.UpdateWeightclasses(id, newName);
                Console.WriteLine("Weightclass updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteWeightclass()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Weightclass");

                var weightclasses = storageManager.GetAllWeightclasses();
                foreach (var wc in weightclasses)
                {
                    Console.WriteLine($"{wc.WeightclassID}: {wc.WeightclassName}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Weightclass ID to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && weightclasses.Any(w => w.WeightclassID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Weightclass ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.DeleteWeightclasses(id);
                Console.WriteLine("Weightclass deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        private static void ViewMatches()
        {
            Console.Clear();
            var MatchList = storageManager.GetAllMatches();
            Console.WriteLine("Matches:");
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
            while (true)
            {
                var fighterList = storageManager.GetAllFighters();
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Fighter 1 ID: ");
                if (int.TryParse(Console.ReadLine(), out fighter1ID) && storageManager.DoesFighterExist(fighter1ID))
                    break;

                Console.WriteLine("Fighter 1 ID is invalid or does not exist.");
            }
            int fighter2ID = 0;
            while (true)
            {
                var fighterList = storageManager.GetAllFighters();
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Fighter 2 ID (must be different from Fighter 1): ");
                if (int.TryParse(Console.ReadLine(), out fighter2ID) &&
                    storageManager.DoesFighterExist(fighter2ID) &&
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

                var matches = storageManager.GetAllMatches();
                foreach (var match in matches)
                {
                    Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
                }

                int matchID;
                while (true)
                {
                    Console.Write("Enter Match ID to update: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out matchID) && matches.Any(m => m.MatchID == matchID))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                int fighter1ID;
                while (true)
                {
                    Console.Write("Enter new Fighter 1 ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out fighter1ID) && storageManager.DoesFighterExist(fighter1ID))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Fighter 1 ID is invalid or does not exist. Press Enter to try again.");
                    Console.ReadLine();
                }

                int fighter2ID;
                while (true)
                {
                    Console.Write("Enter new Fighter 2 ID: ");
                    string input = Console.ReadLine();
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

                DateTime newMatchDate;
                while (true)
                {
                    Console.Write("Enter new Match Date (yyyy-MM-dd): ");
                    string input = Console.ReadLine();
                    if (DateTime.TryParse(input, out newMatchDate))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid date format. Press Enter to try again.");
                    Console.ReadLine();
                }

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
                    if (int.TryParse(input, out matchID) && matches.Any(m => m.MatchID == matchID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.DeleteMatch(matchID);
                Console.WriteLine("Match deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        private static void ViewGyms()
        {
            Console.Clear();
            var gymList = storageManager.GetAllGyms();
            Console.WriteLine("Gyms:");
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
            Console.Clear();
            Console.WriteLine("=== Add Gym ===");

            string name = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Enter Gym name (letters only): ");
                name = Console.ReadLine();
                if (name.Length > 0 && name.All(c => char.IsLetter(c) || c == ' '))
                {
                    isValid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a Gym name using letters only. Do not leave it blank.");
                }
            }
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
                return;
            }
            if (!storageManager.DoesRegionExist(regionID))
            {
                Console.WriteLine("Region ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            storageManager.AddGym(name, regionID);
            Console.WriteLine("Gym added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateGym()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Gym");

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
                    if (int.TryParse(input, out id) && gyms.Any(g => g.GymID == id))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                string newName;
                do
                {
                    Console.Write("Enter new Gym name: ");
                    newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        Console.WriteLine("Gym name cannot be blank. Press Enter to try again.");
                        Console.ReadLine();
                    }
                    else if (!newName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.Clear();
                        Console.WriteLine("Gym name must contain only letters and spaces. Press Enter to try again.");
                        Console.ReadLine();
                        newName = string.Empty;
                    }
                } while (string.IsNullOrWhiteSpace(newName));

                storageManager.UpdateGym(id, newName);
                Console.WriteLine("Gym updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteGym()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Gym");

                var gyms = storageManager.GetAllGyms();
                foreach (var gym in gyms)
                {
                    Console.WriteLine($"{gym.GymID}: {gym.GymName}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Gym ID to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && gyms.Any(g => g.GymID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.DeleteGym(id);
                Console.WriteLine("Gym deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        private static void ViewOutcomeTypes()
        {
            Console.Clear();
            var outcomeTypesList = storageManager.GetAllOutcomeTypes();
            Console.WriteLine("Outcome Types:");
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
            Console.Clear();
            Console.WriteLine("=== Add Outcome Type ===");

            string description = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Enter Outcome Type description (letters and spaces only): ");
                description = Console.ReadLine();

                if (description.Length > 0 && description.All(c => char.IsLetter(c) || c == ' '))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Description must contain letters and spaces only, and cannot be blank.");
                }
            }
            storageManager.AddOutcomeType(description);
            Console.WriteLine("Outcome Type added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateOutcomeType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Outcome Type");

                var outcomeTypes = storageManager.GetAllOutcomeTypes();
                foreach (var outcomeType in outcomeTypes)
                {
                    Console.WriteLine($"{outcomeType.OutcomeID}: {outcomeType.OutcomeDescription}");
                }

                int id;
                while (true)
                {
                    Console.Clear();
                    Console.Write("Enter Outcome Type ID to update: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && outcomeTypes.Any(o => o.OutcomeID == id))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Outcome Type ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                string newDescription;
                do
                {
                    Console.Write("Enter new Outcome Type description: ");
                    newDescription = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDescription))
                    {
                        Console.Clear();
                        Console.WriteLine("Description cannot be blank. Press Enter to try again.");
                        Console.ReadLine();
                    }
                } while (string.IsNullOrWhiteSpace(newDescription));

                storageManager.UpdateOutcomeType(id, newDescription);
                Console.WriteLine("Outcome Type updated. Press Enter.");
                Console.ReadLine();
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

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Outcome Type");

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

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Outcome Type ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.DeleteOutcomeType(id);
                Console.WriteLine("Outcome Type deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }



        private static void ViewFighters()
        {
            Console.Clear();
            var fighterList = storageManager.GetAllFighters();
            Console.WriteLine("Fighters:");
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

            
            string firstName = "";
            while (true)
            {
                Console.Write("Enter Firstname: ");
                firstName = Console.ReadLine();

                if (firstName.Length > 0 && firstName.All(c => char.IsLetter(c) || c == ' '))
                    break;

                Console.WriteLine("Invalid input. Only letters and spaces allowed.");
            }
            string lastName = "";
            while (true)
            {
                Console.Write("Enter Lastname: ");
                lastName = Console.ReadLine();

                if (lastName.Length > 0 && lastName.All(c => char.IsLetter(c) || c == ' '))
                    break;

                Console.WriteLine("Invalid input. Only letters and spaces allowed.");
            }
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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Fighter");

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
                    if (int.TryParse(input, out id) && fighters.Any(f => f.FighterID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                string newFirstName;
                do
                {
                    Console.Write("Enter new Firstname: ");
                    newFirstName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newFirstName) || !newFirstName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.Clear();
                        Console.WriteLine("Firstname must contain only letters and spaces. Press Enter to try again.");
                        Console.ReadLine();
                        newFirstName = string.Empty;
                    }
                } while (string.IsNullOrWhiteSpace(newFirstName));

                string newLastName;
                do
                {
                    Console.Write("Enter new Lastname: ");
                    newLastName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newLastName) || !newLastName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.Clear();
                        Console.WriteLine("Lastname must contain only letters and spaces. Press Enter to try again.");
                        Console.ReadLine();
                        newLastName = string.Empty;
                    }
                } while (string.IsNullOrWhiteSpace(newLastName));

                int newAge;
                while (true)
                {
                    Console.Write("Enter new Age (10–50): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newAge) && newAge >= 10 && newAge <= 50)
                        break;

                    Console.Clear();
                    Console.WriteLine("Age must be between 10 and 50. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newRegionID;
                while (true)
                {
                    Console.Write("Enter new Region ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newRegionID) && storageManager.DoesRegionExist(newRegionID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Region ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }

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

                int newWeightclassID;
                while (true)
                {
                    Console.Write("Enter new Weightclass ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newWeightclassID) && storageManager.DoesWeightclassExist(newWeightclassID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Weightclass ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }

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

                storageManager.UpdateFighter(id, newFirstName, newLastName, newAge, newRegionID, newGymID, newWeightclassID, newWins, newLosses, newDraws);
                Console.WriteLine("Fighter info updated. Press Enter.");
                Console.ReadLine();
                break;
            }
        }
        static void DeleteFighter()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Delete Fighter");

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

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.deleteFighter(id);
                Console.WriteLine("Fighter deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }


        private static void ViewFighterAndGym()
        {
            Console.Clear();
            var fighterAndGymList = storageManager.GetAllFighterAndGyms();
            Console.WriteLine("FighterAndGyms:");
            if (fighterAndGymList == null || fighterAndGymList.Count == 0)
            {
                Console.WriteLine("No fighters and gyms found.");
            }
            else
            {
                Console.WriteLine("ID\tFighterID\tGymID\tTotalWins\tTotalLosses\tTotalDraws");
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
            while (true)
            {
                var fighterList = storageManager.GetAllFighters();
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Fighter ID: ");
                if (int.TryParse(Console.ReadLine(), out fighterID) && storageManager.DoesFighterExist(fighterID))
                    break;

                Console.WriteLine("Fighter ID not found. Please enter a valid ID.");
            }
            int gymID = 0;
            while (true)
            {
                var gymList = storageManager.GetAllGyms();
                foreach (var gyms in gymList)
                {
                    Console.WriteLine($"{gyms.GymID}\t{gyms.GymName}");
                }
                Console.Write("Enter Gym ID: ");
                if (int.TryParse(Console.ReadLine(), out gymID) && storageManager.DoesGymExist(gymID))
                    break;

                Console.WriteLine("Gym ID not found. Please enter a valid ID.");
            }
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
            storageManager.AddFighterAndGym(fighterID, gymID, totalWins, totalLosses, totalDraws);
            Console.WriteLine("Fighter and Gym linked successfully! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateFighterAndGym()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Fighter and Gym");

                var fighterAndGyms = storageManager.GetAllFighterAndGyms();
                foreach (var fg in fighterAndGyms)
                {
                    Console.WriteLine($"{fg.FighterAndGymID}: Fighter {fg.FighterID}, Gym {fg.GymID}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Fighter and Gym ID to update: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && fighterAndGyms.Any(fg => fg.FighterAndGymID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter and Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newFighterID;
                while (true)
                {
                    Console.Write("Enter new Fighter ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newFighterID) && storageManager.DoesFighterExist(newFighterID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Fighter ID not found. Press Enter to try again.");
                    Console.ReadLine();
                }

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
                    if (int.TryParse(input, out id) && fighterAndGyms.Any(fg => fg.FighterAndGymID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Fighter and Gym ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.DeleteFighterAndGym(id);
                Console.WriteLine("Fighter and Gym deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }



        private static void ViewMatchOutcome()
        {
            Console.Clear();
            var matchOutcomesList = storageManager.GetAllMatchOutcomes();
            Console.WriteLine("Match outcomes:");
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
                var MatchList = storageManager.GetAllMatches();
                Console.WriteLine("ID\tFighter 1\tFighter 2\tDate");
                foreach (var match in MatchList)
                {
                    Console.WriteLine($"{match.MatchID}\t{match.Fighter1ID}\t\t{match.Fighter2ID}\t\t{match.MatchDate:yyyy-MM-dd}");
                }
                Console.Write("Enter Match ID: ");
                if (int.TryParse(Console.ReadLine(), out matchID) && storageManager.DoesMatchExist(matchID))
                    break;

                Console.WriteLine("Match ID not found in the system. Please try again.");
            }
            int winnerID = 0;
            while (true)
            {
                var fighterList = storageManager.GetAllFighters();
                Console.WriteLine("ID\tFighterID\tGymID\tTotalWins\tTotalLosses\tTotalDraws");
                foreach (var fighter in fighterList)
                {
                    Console.WriteLine($"{fighter.FighterID}\t{fighter.FirstName}\t{fighter.LastName}\t{fighter.Age}\t{fighter.RegionID}\t{fighter.GymID}\t{fighter.WeightclassID}\t{fighter.Wins}\t{fighter.Losses}\t{fighter.Draws}");
                }
                Console.Write("Enter Winner ID (FighterID): ");
                if (int.TryParse(Console.ReadLine(), out winnerID) && storageManager.DoesFighterExist(winnerID))
                    break;

                Console.WriteLine("Winner ID not found in the system. Please try again.");
            }
            int outcomeID = 0;
            while (true)
            {
                var outcomeTypesList = storageManager.GetAllOutcomeTypes();
                Console.WriteLine("ID\tOutcome Type");
                foreach (var outcomeTypes in outcomeTypesList)
                {
                    Console.WriteLine($"{outcomeTypes.OutcomeID}\t{outcomeTypes.OutcomeDescription}");
                }
                Console.Write("Enter Outcome ID: ");
                if (int.TryParse(Console.ReadLine(), out outcomeID) && storageManager.DoesOutcomeTypeExist(outcomeID))
                    break;
                Console.WriteLine("Outcome ID not found in the system. Please try again.");
            }
            storageManager.AddMatchOutcome(matchID, winnerID, outcomeID);
            Console.WriteLine("Match outcome added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateMatchOutcome()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Update Match Outcome");

                var matchOutcomes = storageManager.GetAllMatchOutcomes();
                foreach (var outcome in matchOutcomes)
                {
                    Console.WriteLine($"{outcome.MatchOutcomeID}: Match {outcome.MatchID}, Winner {outcome.WinnerID}, Outcome {outcome.OutcomeID}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Match Outcome ID to update: ");
                    string input = Console.ReadLine();
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
                    if (int.TryParse(input, out newMatchID) && storageManager.DoesMatchExist(newMatchID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Match ID not found in the system. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newWinnerID;
                while (true)
                {
                    Console.Write("Enter new Winner ID (FighterID): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newWinnerID) && storageManager.DoesFighterExist(newWinnerID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Winner ID not found in the system. Press Enter to try again.");
                    Console.ReadLine();
                }

                int newOutcomeID;
                while (true)
                {
                    Console.Write("Enter new Outcome ID: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out newOutcomeID) && storageManager.DoesOutcomeTypeExist(newOutcomeID))
                        break;

                    Console.Clear();
                    Console.WriteLine("Outcome ID not found in the system. Press Enter to try again.");
                    Console.ReadLine();
                }

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

                var matchOutcomes = storageManager.GetAllMatchOutcomes();
                foreach (var outcome in matchOutcomes)
                {
                    Console.WriteLine($"{outcome.MatchOutcomeID}: Match {outcome.MatchID}, Winner {outcome.WinnerID}, Outcome {outcome.OutcomeID}");
                }

                int id;
                while (true)
                {
                    Console.Write("Enter Match Outcome ID to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && matchOutcomes.Any(o => o.MatchOutcomeID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent Match Outcome ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.deleteMatchOutcome(id);
                Console.WriteLine("Match outcome deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }



        private static void ViewRegions()
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
            Console.Clear();
            Console.WriteLine("=== Add Region ===");
            string name = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Enter region name (letters only): ");
                name = Console.ReadLine();
                if (name.Length > 0 && name.All(char.IsLetter))
                {
                    isValid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Region name must contain letters only and cannot be blank.");
                }
            }
            storageManager.AddRegion(name);
            Console.WriteLine("Region added! Press Enter.");
            Console.ReadLine();
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

                int id;
                while (true)
                {
                    Console.Write("Enter region ID to update: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && regions.Any(r => r.RegionID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent region ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                string newName;
                do
                {
                    Console.Write("Enter new region name: ");
                    newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        Console.Clear();
                        Console.WriteLine("Region name cannot be blank. Press Enter to try again.");
                        Console.ReadLine();
                    }
                    else if (!newName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                    {
                        Console.Clear();
                        Console.WriteLine("Region name must contain only letters and spaces. Press Enter to try again.");
                        Console.ReadLine();
                        newName = string.Empty;
                    }
                } while (string.IsNullOrWhiteSpace(newName));

                storageManager.UpdateRegion(id, newName);
                Console.WriteLine("Region updated. Press Enter.");
                Console.ReadLine();
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

                int id;
                while (true)
                {
                    Console.Write("Enter region ID to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out id) && regions.Any(r => r.RegionID == id))
                        break;

                    Console.Clear();
                    Console.WriteLine("Invalid or non-existent region ID. Press Enter to try again.");
                    Console.ReadLine();
                }

                storageManager.DeleteRegion(id);
                Console.WriteLine("Region deleted. Press Enter.");
                Console.ReadLine();
                break;
            }
        }



    }
}
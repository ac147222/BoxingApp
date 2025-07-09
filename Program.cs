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

       static void RegionsMenu()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Regions Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Regions");
                Console.WriteLine("2. Add Region");
                Console.WriteLine("3. Update Region");
                Console.WriteLine("4. Delete Region");
                Console.WriteLine("5. Return to admin Menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewRegions(); break;
                    case "2": AddRegion(); break;
                    case "3": UpdateRegion(); break;
                    case "4": DeleteRegion(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }


            }
        }

        static void WeightclassesMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Weightclasses Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Weightclasses");
                Console.WriteLine("2. Add Weightclasses");
                Console.WriteLine("3. Update Weightclasses");
                Console.WriteLine("4. Delete Weightclasses");
                Console.WriteLine("5 Return to Admin Menu");
                Console.WriteLine("6. Logout");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewWeightclasses(); break;
                    case "2": AddWeightclasses(); break;
                    case "3": UpdateWeightclass(); break;
                    case "4": DeleteWeightclass(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void GymsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Gyms Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Gyms");
                Console.WriteLine("2. Add Gyms");
                Console.WriteLine("3. Update Gyms");
                Console.WriteLine("4. Delete Gyms");
                Console.WriteLine("5. Return to admin menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewGyms(); break;
                    case "2": AddGym(); break;
                    case "3": UpdateGym(); break;
                    case "4": DeleteGym(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void MatchesMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Matches Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Matches");
                Console.WriteLine("2. Add Match");
                Console.WriteLine("3. Update Match");
                Console.WriteLine("4. Delete Match");
                Console.WriteLine("5. Return to admin menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewMatches(); break;
                    case "2": AddMatch(); break;
                    case "3": UpdateMatch(); break;
                    case "4": DeleteMatch(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void OutcomeTypeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Outcome Type Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Outcome Types");
                Console.WriteLine("2. Add Outcome Type");
                Console.WriteLine("3. Update Outcome Type");
                Console.WriteLine("4. Delete Outcome Type");
                Console.WriteLine("5. Return to admin menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewOutcomeTypes(); break;
                    case "2": AddOutcomeType(); break;
                    case "3": UpdateOutcomeType(); break;
                    case "4": DeleteOutcomeType(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void FighterMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Fighters Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Fighters");
                Console.WriteLine("2. Add Fighter");
                Console.WriteLine("3. Update Fighter");
                Console.WriteLine("4. Delete Fighter");
                Console.WriteLine("5. Return to admin menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewFighters(); break;
                    case "2": AddFighter(); break;
                    case "3": UpdateFighter(); break;
                    case "4": DeleteFighter(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void MatchOutcomeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Match Outcome Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Match Outcomes");
                Console.WriteLine("2. Add Match Outcome");
                Console.WriteLine("3. Update Match Outcome");
                Console.WriteLine("4. Delete Match Outcome");
                Console.WriteLine("5. Return to admin menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewMatchOutcome(); break;
                    case "2": AddMatchOutcome(); break;
                    case "3": UpdateMatchOutcome(); break;
                    case "4": DeleteMatchOutcome(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void FighterAndGymMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Fighter and Gym Menu, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. View Fighter and Gyms");
                Console.WriteLine("2. Add Fighter and Gym");
                Console.WriteLine("3. Update Fighter and Gym");
                Console.WriteLine("4. Delete Fighter and Gym");
                Console.WriteLine("5. Return to admin menu");
                Console.Write("Select an option: ");
                switch (Console.ReadLine())
                {
                    case "1": ViewFighterAndGym(); break;
                    case "2": AddFighterAndGym(); break;
                    case "3": UpdateFighterAndGym(); break;
                    case "4": DeleteFighterAndGym(); break;
                    case "5": ShowAdminMenu(); break;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowAdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {currentUser.Username} (ADMIN)");
                Console.WriteLine("1. Region Menu");
                Console.WriteLine("2. Weightclasses Menu");
                Console.WriteLine("3. Gyms Menu");
                Console.WriteLine("4. Matches Menu");
                Console.WriteLine("5. Match Outcome Types Menu");
                Console.WriteLine("6. Fighters Menu");
                Console.WriteLine("7. Match Outcome Menu");
                Console.WriteLine("8. Fighter and Gym Meny");
                Console.WriteLine("8. Log Out");
                Console.Write("Select an option: ");
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
                    case "9":
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
                Console.WriteLine($"Welcome, {currentUser.Username}");
                Console.WriteLine("1. View Regions");
                Console.WriteLine("2. View Weightclasses");
                Console.WriteLine("3. View Gyms");
                Console.WriteLine("4. View Matches");
                Console.WriteLine("5. View Outcome Types");
                Console.WriteLine("6. View Fighters");
                Console.WriteLine("7. View Fighter and Gyms");
                Console.WriteLine("8. View Matches and their outcomes");
                Console.WriteLine("9. Logout");
                Console.Write("Select an option: ");
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
                    case "9":
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
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to add regions.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Add Weightclass ===");
            Console.Write("Enter Weightclass name: ");
            string name = Console.ReadLine();
            storageManager.AddWeightclasses(name);
            Console.WriteLine("Weightclass added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateWeightclass()
        {
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to update weightclasses.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Update Weightclasses ===");
            var weightclass = storageManager.GetAllWeightclasses();
            foreach (var weightclasses in weightclass)
            {
                Console.WriteLine($"{weightclasses.WeightclassID}: {weightclasses.WeightclassName}");
            }
            Console.Write("Enter Weightclass ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new weightclass name: ");
            string newName = Console.ReadLine();
            storageManager.UpdateWeightclasses(id, newName);
            Console.WriteLine("Weightclass updated! Press Enter.");
            Console.ReadLine();
        }
        static void DeleteWeightclass()
        {

            Console.Clear();
            Console.WriteLine("=== Delete Weightclass ===");
            var weightclass = storageManager.GetAllWeightclasses();
            foreach (var weightclasses in weightclass)
            {
                Console.WriteLine($"{weightclasses.WeightclassID}: {weightclasses.WeightclassName}");
            }
            Console.Write("Enter Weightclass ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.DeleteWeightclasses(id);
            Console.WriteLine("Weightclass deleted! Press Enter.");
            Console.ReadLine();
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
            Console.Write("Enter Fighter 1 ID: ");
            Console.Write("Enter new Fighter 1 ID: ");
            if (!int.TryParse(Console.ReadLine(), out int fighter1ID) || !storageManager.DoesFighterExist(fighter1ID))
            {
                Console.WriteLine("Fighter 1 ID is invalid or does not exist. Press Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter new Fighter 2 ID: ");
            if (!int.TryParse(Console.ReadLine(), out int fighter2ID) || !storageManager.DoesFighterExist(fighter2ID))
            {
                Console.WriteLine("Fighter 2 ID is invalid or does not exist. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Match Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime matchDate))
            {
                Console.WriteLine("Invalid date format. Press Enter.");
                Console.ReadLine();
                return;
            }
            
            storageManager.AddMatch(fighter1ID, fighter2ID, matchDate);
            Console.WriteLine("Match added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateMatch()
        {
            Console.Clear();
            Console.WriteLine("=== Update Match ===");

            var matches = storageManager.GetAllMatches();
            foreach (var match in matches)
            {
                Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
            }

            Console.Write("Enter Match ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int matchID))
            {
                Console.WriteLine("Invalid Match ID. Press Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter new Fighter 1 ID: ");
            if (!int.TryParse(Console.ReadLine(), out int fighter1ID) || !storageManager.DoesFighterExist(fighter1ID))
            {
                Console.WriteLine("Fighter 1 ID is invalid or does not exist. Press Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter new Fighter 2 ID: ");
            if (!int.TryParse(Console.ReadLine(), out int fighter2ID) || !storageManager.DoesFighterExist(fighter2ID))
            {
                Console.WriteLine("Fighter 2 ID is invalid or does not exist. Press Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter new Match Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime newMatchDate))
            {
                Console.WriteLine("Invalid date format. Press Enter.");
                Console.ReadLine();
                return;
            }

            storageManager.UpdateMatch(matchID, fighter1ID, fighter2ID, newMatchDate);
            Console.WriteLine("Match updated! Press Enter.");
            Console.ReadLine();
        }
        static void DeleteMatch()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Match ===");
            var matches = storageManager.GetAllMatches();
            foreach (var match in matches)
            {
                Console.WriteLine($"{match.MatchID}: {match.Fighter1ID} vs {match.Fighter2ID} on {match.MatchDate:yyyy-MM-dd}");
            }
            Console.Write("Enter Match ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int matchID))
            {
                Console.WriteLine("Invalid Match ID. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.DeleteMatch(matchID);
            Console.WriteLine("Match deleted! Press Enter.");
            Console.ReadLine();
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
            Console.Write("Enter Gym name: ");
            string name = Console.ReadLine();
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
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to update Gyms.");
                Console.ReadLine();


                return;
            }
            Console.Clear();
            Console.WriteLine("=== Update Gym ===");
            var gyms = storageManager.GetAllGyms();
            foreach (var gym in gyms)
            {
                Console.WriteLine($"{gym.GymID}: {gym.GymName}");
            }
            Console.Write("Enter Gym ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Gym name: ");
            string newName = Console.ReadLine();
            storageManager.UpdateGym(id, newName);
            Console.WriteLine("Gym updated! Press Enter.");
            Console.ReadLine();
        }
        public static void DeleteGym()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Gym ===");
            var gyms = storageManager.GetAllGyms();
            foreach (var gym in gyms)
            {
                Console.WriteLine($"{gym.GymID}: {gym.GymName}");
            }
            Console.Write("Enter Gym ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.DeleteGym(id);
            Console.WriteLine("Gym deleted! Press Enter.");
            Console.ReadLine();
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
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to add outcome types.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Add Outcome Type ===");
            Console.Write("Enter Outcome Type description: ");
            string description = Console.ReadLine();
            storageManager.AddOutcomeType(description);
            Console.WriteLine("Outcome Type added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateOutcomeType()
        {
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to update outcome types.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Update Outcome Type ===");
            var outcomeTypes = storageManager.GetAllOutcomeTypes();
            foreach (var outcomeType in outcomeTypes)
            {
                Console.WriteLine($"{outcomeType.OutcomeID}: {outcomeType.OutcomeDescription}");
            }
            Console.Write("Enter Outcome Type ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Outcome Type description: ");
            string newDescription = Console.ReadLine();
            storageManager.UpdateOutcomeType(id, newDescription);
            Console.WriteLine("Outcome Type updated! Press Enter.");
            Console.ReadLine();
        }
        static void DeleteOutcomeType()
        {
            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("You do not have permission to delete outcome types.");
                Console.ReadLine();
                return;
            }
            Console.Clear();
            Console.WriteLine("=== Delete Outcome Type ===");
            var outcomeTypes = storageManager.GetAllOutcomeTypes();
            foreach (var outcomeType in outcomeTypes)
            {
                Console.WriteLine($"{outcomeType.OutcomeID}: {outcomeType.OutcomeDescription}");
            }
            Console.Write("Enter Outcome Type ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.DeleteOutcomeType(id);
            Console.WriteLine("Outcome Type deleted! Press Enter.");
            Console.ReadLine();
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
            Console.Write("Enter Firstname: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Lastname: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Region ID: ");
            if (!int.TryParse(Console.ReadLine(), out int regionID) || !storageManager.DoesRegionExist(regionID))
            {
                Console.WriteLine("Region ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Gym ID: ");
            if (!int.TryParse(Console.ReadLine(), out int gymID) || !storageManager.DoesGymExist(gymID))
            {
                Console.WriteLine("Gym ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Weightclass ID: ");
            if (!int.TryParse(Console.ReadLine(), out int weightclassID) || !storageManager.DoesWeightclassExist(weightclassID))
            {
                Console.WriteLine("Weightclass ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
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
            Console.Clear();
            Console.WriteLine("=== Update Fighter ===");
            var fighters = storageManager.GetAllFighters();
            foreach (var fighter in fighters)
            {
                Console.WriteLine($"{fighter.FighterID}: {fighter.FirstName} {fighter.LastName}");
            }
            Console.Write("Enter Fighter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Firstname: ");
            string newFirstName = Console.ReadLine();
            Console.Write("Enter new Lastname: ");
            string newLastName = Console.ReadLine();
            Console.Write("Enter new Age: ");
            if (!int.TryParse(Console.ReadLine(), out int newAge))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Region ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newRegionID) || !storageManager.DoesRegionExist(newRegionID))
            {
                Console.WriteLine("Region ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Gym ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newGymID) || !storageManager.DoesGymExist(newGymID))
            {
                Console.WriteLine("Gym ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Weightclass ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newWeightclassID) || !storageManager.DoesWeightclassExist(newWeightclassID))
            {
                Console.WriteLine("Weightclass ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
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
            Console.WriteLine("Fighter info updated! Press Enter.");
            Console.ReadLine();
        }
        static void DeleteFighter()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Fighter ===");
            var fighters = storageManager.GetAllFighters();
            foreach (var fighter in fighters)
            {
                Console.WriteLine($"{fighter.FighterID}: {fighter.FirstName} {fighter.LastName}");
            }
            Console.Write("Enter Fighter ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.deleteFighter(id);
            Console.WriteLine("Fighter deleted! Press Enter.");
            Console.ReadLine();
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
            Console.Write("Enter Fighter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int fighterID) || !storageManager.DoesFighterExist(fighterID))
            {
                Console.WriteLine("Fighter ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Gym ID: ");
            if (!int.TryParse(Console.ReadLine(), out int gymID) || !storageManager.DoesGymExist(gymID))
            {
                Console.WriteLine("Gym ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
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


            storageManager.AddFighterAndGym(fighterID, gymID, totalWins, totalLosses, totalDraws);
            Console.WriteLine("Fighter and Gym added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateFighterAndGym()
        {
            Console.Clear();
            Console.WriteLine("=== Update Fighter and Gym ===");
            var fighterAndGyms = storageManager.GetAllFighterAndGyms();
            foreach (var fighterAndGym in fighterAndGyms)
            {
                Console.WriteLine($"{fighterAndGym.FighterAndGymID}: Fighter {fighterAndGym.FighterID}, Gym {fighterAndGym.GymID}");
            }
            Console.Write("Enter Fighter and Gym ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Fighter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newFighterID) || !storageManager.DoesFighterExist(newFighterID))
            {
                Console.WriteLine("Fighter ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Gym ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newGymID) || !storageManager.DoesGymExist(newGymID))
            {
                Console.WriteLine("Gym ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
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
            Console.WriteLine("Fighter and Gym updated! Press Enter.");
            Console.ReadLine();
        }
        static void DeleteFighterAndGym()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Fighter and Gym ===");
            var fighterAndGyms = storageManager.GetAllFighterAndGyms();
            foreach (var fighterAndGym in fighterAndGyms)
            {
                Console.WriteLine($"{fighterAndGym.FighterAndGymID}: Fighter {fighterAndGym.FighterID}, Gym {fighterAndGym.GymID}");
            }
            Console.Write("Enter Fighter and Gym ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.DeleteFighterAndGym(id);
            Console.WriteLine("Fighter and Gym deleted! Press Enter.");
            Console.ReadLine();
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
            Console.Write("Enter Match ID: ");
            if (!int.TryParse(Console.ReadLine(), out int matchID) || !storageManager.DoesMatchExist(matchID))
            {
                Console.WriteLine("Match ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Winner ID (FighterID): ");
            if (!int.TryParse(Console.ReadLine(), out int winnerID) || !storageManager.DoesFighterExist(winnerID))
            {
                Console.WriteLine("Winner ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter Outcome ID: ");
            if (!int.TryParse(Console.ReadLine(), out int outcomeID) || !storageManager.DoesOutcomeTypeExist(outcomeID))
            {
                Console.WriteLine("Outcome ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            
            storageManager.AddMatchOutcome(matchID, winnerID, outcomeID);
            Console.WriteLine("Match outcome added! Press Enter.");
            Console.ReadLine();
        }
        static void UpdateMatchOutcome()
        {
            Console.Clear();
            Console.WriteLine("=== Update Match Outcome ===");
            var matchOutcomes = storageManager.GetAllMatchOutcomes();
            foreach (var matchOutcome in matchOutcomes)
            {
                Console.WriteLine($"{matchOutcome.MatchOutcomeID}: Match {matchOutcome.MatchID}, Winner {matchOutcome.WinnerID}, Outcome {matchOutcome.OutcomeID}");
            }
            Console.Write("Enter Match Outcome ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Match ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newMatchID) || !storageManager.DoesMatchExist(newMatchID))
            {
                Console.WriteLine("Match ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Winner ID (FighterID): ");
            if (!int.TryParse(Console.ReadLine(), out int newWinnerID) || !storageManager.DoesFighterExist(newWinnerID))
            {
                Console.WriteLine("Winner ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.Write("Enter new Outcome ID: ");
            if (!int.TryParse(Console.ReadLine(), out int newOutcomeID) || !storageManager.DoesOutcomeTypeExist(newOutcomeID))
            {
                Console.WriteLine("Outcome ID not found in the system. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            
            storageManager.updateMatchOutcome(id, newMatchID, newWinnerID, newOutcomeID);
            Console.WriteLine("Match outcome updated! Press Enter.");
            Console.ReadLine();
        }
        static void DeleteMatchOutcome()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Match Outcome ===");
            var matchOutcomes = storageManager.GetAllMatchOutcomes();
            foreach (var matchOutcome in matchOutcomes)
            {
                Console.WriteLine($"{matchOutcome.MatchOutcomeID}: Match {matchOutcome.MatchID}, Winner {matchOutcome.WinnerID}, Outcome {matchOutcome.OutcomeID}");
            }
            Console.Write("Enter Match Outcome ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Press Enter.");
                Console.ReadLine();
                return;
            }
            storageManager.deleteMatchOutcome(id);
            Console.WriteLine("Match outcome deleted! Press Enter.");
            Console.ReadLine();
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
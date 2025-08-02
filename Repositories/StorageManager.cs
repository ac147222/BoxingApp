using BoxingApp;
using BoxingApp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class StorageManager
{
    private SqlConnection conn;

    public StorageManager(string connectionString)
    {
        conn = new SqlConnection(connectionString);
        conn.Open();
    }

    
    public StorageManager(SqlConnection conn)
    {
        this.conn = conn;
    }

    //Method for registering users
    public bool RegisterUser(string username, string password)
    {
        //checks if user input for username is the same as already exisitng usernames 
        string checkSql = "SELECT COUNT(*) FROM tblUser WHERE Username = @Username";
        using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
        {
            checkCmd.Parameters.AddWithValue("@Username", username);
            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
                return false; 
        }

        //inserts the users username and password input into tblUsers with '0' so that they are identified as a non-admin user
        string insertSql = "INSERT INTO tblUser (Username, Password, IsAdmin) VALUES (@Username, @Password, 0)";
        using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
        {
            insertCmd.Parameters.AddWithValue("@Username", username);
            insertCmd.Parameters.AddWithValue("@Password", password); 
            insertCmd.ExecuteNonQuery();
        }
        return true;
    }
    //Method to authenticate users or check log in credentials
    public User AuthenticateUser(string username, string password)
    {
        //Checks if username and password entered by the user matches existing UserID, Usernme, and Password in tblUser
        string sql = "SELECT UserID, Username, Password, IsAdmin FROM tblUser WHERE Username = @Username AND Password = @Password";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserID = (int)reader["UserID"],
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        IsAdmin = (bool)reader["IsAdmin"]
                    };
                }
            }
        }
        return null;
    }


    public List<Region> GetAllRegions()
    {
        List<Region> regions = new List<Region>();
        //retrieves all regions from the database
        string sqlString = "SELECT * FROM dbo.tblRegion";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //loops through the data reader to get each region's ID and name
                while (reader.Read())
                {
                    //converts the RegionID to an integer and RegionName to a string, then adds it to the regions list
                    int Region_ID = Convert.ToInt32(reader["RegionID"]);
                    string Region_Name = reader["RegionName"].ToString();
                    regions.Add(new Region(Region_ID, Region_Name));
                }
            }
        }
        // returns the list of regions
        return regions;
    }
    // Method to add a new region to the database
    public void AddRegion(string name)
    {
        // inserts a new region into the tblRegion table with the provided name
        string sql = "INSERT INTO tblRegion (RegionName) VALUES (@RegionName)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@RegionName", name);
            cmd.ExecuteNonQuery();
        }
    }
    // Method to update an existing region's name in the database
    public void UpdateRegion(int id, string newName)
    {
        // updates the RegionName of a specific region identified by RegionID
        string sql = "UPDATE tblRegion SET RegionName = @RegionName WHERE RegionID = @RegionID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the new region name and the ID of the region to be updated
            cmd.Parameters.AddWithValue("@RegionName", newName);
            cmd.Parameters.AddWithValue("@RegionID", id);
            cmd.ExecuteNonQuery();
        }
    }
    // Method to delete a region from the database
    public void DeleteRegion(int id)
    {
        // deletes a region from the tblRegion table based on the RegionID
        string sql = "DELETE FROM tblRegion WHERE RegionID = @RegionID";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the region to be deleted
            cmd.Parameters.AddWithValue("@RegionID", id);
            cmd.ExecuteNonQuery();
        }
    }


    // Methods for managing weight classes
    public List<Weightclass> GetAllWeightclasses()
    {
        // retrieves all weight classes from the database
        var weightclasses = new List<Weightclass>();
        string sql = "SELECT WeightclassID, Weightclass FROM dbo.tblWeightclasses";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // converts the WeightclassID to an integer and Weightclass to a string, then adds it to the weightclasses list
                int id = Convert.ToInt32(reader["WeightclassID"]);
                
                string name = reader["Weightclass"].ToString().Trim();
                weightclasses.Add(new Weightclass(id, name));
            }
        }
        // returns the list of weight classes
        return weightclasses;
    }
    public void AddWeightclasses(string name)
    {
        // inserts a new weight class into the tblWeightclasses table with the provided name
        string sql = "INSERT INTO tblWeightclasses (Weightclass) VALUES (@Weightclass)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the new weight class name to tblWeightclasses
            cmd.Parameters.AddWithValue("@Weightclass", name);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateWeightclasses(int id, string newName)
    {
        // updates the Weightclass of a specific weight class identified by WeightclassID
        string sql = "UPDATE tblWeightclasses SET Weightclass = @Weightclass WHERE WeightclassID = @WeightclassID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the new weight class name and the ID of the weight class to be updated
            cmd.Parameters.AddWithValue("@Weightclass", newName);
            cmd.Parameters.AddWithValue("@WeightclassID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteWeightclasses(int id)
    {
        // deletes a weight class from the tblWeightclasses table based on the WeightclassID
        string sql = "DELETE FROM tblWeightclasses WHERE WeightclassID = @WeightclassID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the weight class to be deleted
            cmd.Parameters.AddWithValue("@WeightclassID", id);
            cmd.ExecuteNonQuery();
        }
    }

    // Methods for managing gyms
    public List<Gym> GetAllGyms()
    {
        List<Gym> gyms = new List<Gym>();
        string sqlString = "SELECT * FROM dbo.tblGym";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int GymID = Convert.ToInt32(reader["GymID"]);
                    string GymName = reader["GymName"].ToString();
                    gyms.Add(new Gym(GymID, GymName));
                }
            }
        }
        return gyms;
    }
    public void AddGym(string name, int ID)
    {
        //  inserts a new gym into the tblGym table with the provided name and RegionID
        string sql = "INSERT INTO tblGym (GymName, RegionID) VALUES (@GymName, @RegionID)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the new gym name and the ID of the region to which it belongs
            cmd.Parameters.AddWithValue("@GymName", name);
            cmd.Parameters.AddWithValue("@RegionID", ID);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateGym(int id, string newName)
    {
        //  updates the GymName of a specific gym identified by GymID
        string sql = "UPDATE tblGym SET GymName = @GymName WHERE GymID = @ID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the new gym name and the ID of the gym to be updated
            cmd.Parameters.AddWithValue("@GymName", newName);
            cmd.Parameters.AddWithValue("@GymID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteGym(int id)
    {
        // deletes a gym from the tblGym table based on the GymID
        string sql = "DELETE FROM tblGym WHERE GymID = @GymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the gym to be deleted
            cmd.Parameters.AddWithValue("@GymID", id);
            cmd.ExecuteNonQuery();
        }
    }

    // Methods for managing matches
    public List<Match> GetAllMatches()
    {

        List<Match> matches = new List<Match>();
        // retrieves all matches from the database
        string sqlString = "SELECT * FROM dbo.tblMatch";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // converts the MatchID, Fighter1ID, Fighter2ID to integers and MatchDate to DateTime, then adds it to the matches list
                    int MatchID = Convert.ToInt32(reader["MatchID"]);
                    int Fighter1ID = Convert.ToInt32(reader["Fighter1ID"]);
                    int Fighter2ID = Convert.ToInt32(reader["Fighter2ID"]);
                    DateTime MatchDate = Convert.ToDateTime(reader["MatchDate"]);
                    matches.Add(new Match(MatchID, Fighter1ID, Fighter2ID, MatchDate));
                }
            }
        }
        // returns the list of matches
        return matches;
    }
    public void AddMatch(int fighter1ID, int fighter2ID, DateTime matchDate)
    {
        // inserts a new match into the tblMatch table with the provided fighter IDs and match date
        string sql = "INSERT INTO tblMatch (Fighter1ID, Fighter2ID, MatchDate) VALUES (@Fighter1ID, @Fighter2ID, @MatchDate)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the fighter IDs and match date to tblMatch
            cmd.Parameters.AddWithValue("@Fighter1ID", fighter1ID);
            cmd.Parameters.AddWithValue("@Fighter2ID", fighter2ID);
            cmd.Parameters.AddWithValue("@MatchDate", matchDate);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateMatch(int matchID, int fighter1ID, int fighter2ID, DateTime matchDate)
    {
        // updates the Fighter1ID, Fighter2ID, and MatchDate of a specific match identified by MatchID
        string sql = "UPDATE tblMatch SET Fighter1ID = @Fighter1ID, Fighter2ID = @Fighter2ID, MatchDate = @MatchDate WHERE MatchID = @MatchID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the fighter IDs, match date, and ID of the match to be updated
            cmd.Parameters.AddWithValue("@Fighter1ID", fighter1ID);
            cmd.Parameters.AddWithValue("@Fighter2ID", fighter2ID);
            cmd.Parameters.AddWithValue("@MatchDate", matchDate);
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteMatch(int matchID)
    {
        // deletes a match from the tblMatch table based on the MatchID
        string sql = "DELETE FROM tblMatch WHERE MatchID = @MatchID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the match to be deleted
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.ExecuteNonQuery();
        }
    }

    // Methods for managing match outcome types
    public List<OutcomeType> GetAllOutcomeTypes()
    {
        // retrieves all outcome types from the database
        List<OutcomeType> outcomeTypes = new List<OutcomeType>();
        string sqlString = "SELECT * FROM dbo.tblOutcomeType";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // converts the OutcomeID to an integer and OutcomeDescription to a string, then adds it to the outcomeTypes list
                    int OutcomeID = Convert.ToInt32(reader["OutcomeID"]);
                    string OutcomeDescription = reader["OutcomeDescription"].ToString();
                    outcomeTypes.Add(new OutcomeType(OutcomeID, OutcomeDescription));
                }
            }
        }
        return outcomeTypes;
    }
    public void AddOutcomeType(string description)
    {
        //  inserts a new outcome type into the tblOutcomeType table with the provided description
        string sql = "INSERT INTO tblOutcomeType (OutcomeDescription) VALUES (@OutcomeDescription)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))  
        {
            // adds the new outcome description to tblOutcomeType
            cmd.Parameters.AddWithValue("@OutcomeDescription", description);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateOutcomeType(int id, string description)
    {
        // updates the OutcomeDescription of a specific outcome type identified by OutcomeID
        string sql = "UPDATE tblOutcomeType SET OutcomeDescription = @OutcomeDescription WHERE OutcomeID = @OutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the new outcome description and the ID of the outcome type to be updated
            cmd.Parameters.AddWithValue("@OutcomeDescription", description);
            cmd.Parameters.AddWithValue("@OutcomeID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteOutcomeType(int id)
    {
        // deletes an outcome type from the tblOutcomeType table based on the OutcomeID
        string sql = "DELETE FROM tblOutcomeType WHERE OutcomeID = @OutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the outcome type to be deleted
            cmd.Parameters.AddWithValue("@OutcomeID", id);
            cmd.ExecuteNonQuery();
        }
    }

    // Methods for managing fighters
    public List<Fighter> GetAllFighters()
    {
        List<Fighter> fighter = new List<Fighter>();
        // retrieves all fighters from the database
        string sqlString = "SELECT * FROM dbo.tblFighter";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // converts the FighterID, FirstName, LastName, Age, RegionID, GymID, WeightclassID, Wins, Losses, and Draws to their respective types
                    int FighterID = Convert.ToInt32(reader["FighterID"]);
                    string FirstName = reader["FirstName"].ToString();
                    string LastName = reader["LastName"].ToString();
                    int Age = Convert.ToInt32(reader["Age"]);
                    int RegionID = Convert.ToInt32(reader["RegionID"]);
                    int GymID = Convert.ToInt32(reader["GymID"]);
                    int WeightclassID = Convert.ToInt32(reader["WeightclassID"]);
                    int Wins = Convert.ToInt32(reader["Wins"]);
                    int Losses = Convert.ToInt32(reader["Losses"]);
                    int Draws = Convert.ToInt32(reader["Draws"]);   
                    fighter.Add(new Fighter(FighterID, FirstName, LastName, Age, RegionID, GymID, WeightclassID, Wins, Losses, Draws));
                    
                }
            }
        }
        // returns the list of fighters
        return fighter;
    }
    public void AddFighter(string firstName, string lastName, int age, int regionID, int gymID, int weightclassID, int wins, int losses, int draws)
    {
        // inserts a new fighter into the tblFighter table with the provided details
        string sql = "INSERT INTO tblFighter (FirstName, LastName, Age, RegionID, GymID, WeightclassID, Wins, Losses, Draws) VALUES (@FirstName, @LastName, @Age, @RegionID, @GymID, @WeightclassID, @Wins, @Losses, @Draws)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the fighter's first name, last name, age, region ID, gym ID, weight class ID, wins, losses, and draws to tblFighter
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@RegionID", regionID);
            cmd.Parameters.AddWithValue("@GymID", gymID);
            cmd.Parameters.AddWithValue("@WeightclassID", weightclassID);
            cmd.Parameters.AddWithValue("@Wins", wins);
            cmd.Parameters.AddWithValue("@Losses", losses);
            cmd.Parameters.AddWithValue("@Draws", draws);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateFighter(int fighterID, string firstName, string lastName, int age, int regionID, int gymID, int weightclassID, int wins, int losses, int draws)
    {
        // updates the details of a specific fighter identified by FighterID
        string sql = "UPDATE tblFighter SET FirstName = @FirstName, LastName = @LastName, Age = @Age, RegionID = @RegionID, GymID = @GymID, WeightclassID = @WeightclassID, Wins = @Wins, Losses = @Losses, Draws = @Draws WHERE FighterID = @FighterID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the fighter's ID, first name, last name, age, region ID, gym ID, weight class ID, wins, losses, and draws to tblFighter
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@RegionID", regionID);
            cmd.Parameters.AddWithValue("@GymID", gymID);
            cmd.Parameters.AddWithValue("@WeightclassID", weightclassID);
            cmd.Parameters.AddWithValue("@Wins", wins);
            cmd.Parameters.AddWithValue("@Losses", losses);
            cmd.Parameters.AddWithValue("@Draws", draws);
            cmd.ExecuteNonQuery();
        }
    }
    public void deleteFighter(int fighterID)
    {
        // deletes a fighter from the tblFighter table based on the FighterID
        string sql = "DELETE FROM tblFighter WHERE FighterID = @FighterID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the fighter to be deleted
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            cmd.ExecuteNonQuery();
        }
    }

    // Methods for managing fighter and gym relationships
    public List<FighterAndGym> GetAllFighterAndGyms()
    {
        // retrieves all fighter and gym relationships from the database
        List<FighterAndGym> fighterAndGyms = new List<FighterAndGym>();
        string sqlString = "SELECT * FROM dbo.tblFighterAndGym";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // converts the FighterAndGymID, FighterID, GymID, TotalWins, TotalLosses, and TotalDraws to their respective types
                    int FighterAndGymID = Convert.ToInt32(reader["FighterAndGymID"]);
                    int FighterID = Convert.ToInt32(reader["FighterID"]);
                    int GymID = Convert.ToInt32(reader["GymID"]);
                    int TotalWins = Convert.ToInt32(reader["TotalWins"]);
                    int TotalLosses = Convert.ToInt32(reader["TotalLosses"]);
                    int TotalDraws = Convert.ToInt32(reader["TotalDraws"]);
                    fighterAndGyms.Add(new FighterAndGym(FighterAndGymID, FighterID, GymID, TotalWins, TotalLosses, TotalDraws));
                    
                }
            }
        }
        // returns the list of fighter and gym relationships
        return fighterAndGyms;
    }
    public void AddFighterAndGym(int fighterID, int gymID, int totalWins, int totalLosses, int totalDraws)
    {
        // inserts a new fighter and gym relationship into the tblFighterAndGym table with the provided details
        string sql = "INSERT INTO tblFighterAndGym (FighterID, GymID, TotalWins, TotalLosses, TotalDraws) VALUES (@FighterID, @GymID, @TotalWins, @TotalLosses, @TotalDraws)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the fighter ID, gym ID, total wins, total losses, and total draws to tblFighterAndGym
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            cmd.Parameters.AddWithValue("@GymID", gymID);
            cmd.Parameters.AddWithValue("@TotalWins", totalWins);
            cmd.Parameters.AddWithValue("@TotalLosses", totalLosses);
            cmd.Parameters.AddWithValue("@TotalDraws", totalDraws);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateFighterAndGym(int fighterAndGymID, int fighterID, int gymID, int totalWins, int totalLosses, int totalDraws)
    {
        // updates the details of a specific fighter and gym relationship identified by FighterAndGymID
        string sql = "UPDATE tblFighterAndGym SET FighterID = @FighterID, GymID = @GymID, TotalWins = @TotalWins, TotalLosses = @TotalLosses, TotalDraws = @TotalDraws WHERE FighterAndGymID = @FighterAndGymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the fighter and gym relationship ID, fighter ID, gym ID, total wins, total losses, and total draws to tblFighterAndGym
            cmd.Parameters.AddWithValue("@FighterAndGymID", fighterAndGymID);
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            cmd.Parameters.AddWithValue("@GymID", gymID);
            cmd.Parameters.AddWithValue("@TotalWins", totalWins);
            cmd.Parameters.AddWithValue("@TotalLosses", totalLosses);
            cmd.Parameters.AddWithValue("@TotalDraws", totalDraws);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteFighterAndGym(int fighterAndGymID)
    {
        // deletes a fighter and gym relationship from the tblFighterAndGym table based on the FighterAndGymID
        string sql = "DELETE FROM tblFighterAndGym WHERE FighterAndGymID = @FighterAndGymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@FighterAndGymID", fighterAndGymID);
            cmd.ExecuteNonQuery();
        }
    }

    // Methods for managing match outcomes
    public List<MatchOutcome> GetAllMatchOutcomes()
    {
        // retrieves all match outcomes from the database
        List<MatchOutcome> matchOutcome = new List<MatchOutcome>();
        string sqlString = "SELECT * FROM dbo.tblMatchOutcome";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //  converts the MatchOutcomeID, MatchID, WinnerID, and OutcomeID to their respective types
                    int MatchOutcomeID = Convert.ToInt32(reader["MatchOutcomeID"]);
                    int MatchID = Convert.ToInt32(reader["MatchID"]);
                    int? WinnerID = reader["WinnerID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["WinnerID"]) : null;
                    int OutcomeID = Convert.ToInt32(reader["OutcomeID"]);
                    matchOutcome.Add(new MatchOutcome(MatchOutcomeID, MatchID, WinnerID, OutcomeID));
                    
                }
            }
        }
        // returns the list of match outcomes
        return matchOutcome;
    }
    public void AddMatchOutcome(int matchID, int winnerID, int outcomeID)
    {
        //  inserts a new match outcome into the tblMatchOutcome table with the provided details
        string sql = "INSERT INTO tblMatchOutcome (MatchID, WinnerID, OutcomeID) VALUES (@MatchID, @WinnerID, @OutcomeID)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the match ID, winner ID, and outcome ID to tblMatchOutcome
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.Parameters.AddWithValue("@WinnerID", winnerID);
            cmd.Parameters.AddWithValue("@OutcomeID", outcomeID);
            cmd.ExecuteNonQuery();
        }
    }
    public void updateMatchOutcome(int matchOutcomeID, int matchID, int winnerID, int outcomeID)
    {
        // updates the MatchID, WinnerID, and OutcomeID of a specific match outcome identified by MatchOutcomeID
        string sql = "UPDATE tblMatchOutcome SET MatchID = @MatchID, WinnerID = @WinnerID, OutcomeID = @OutcomeID WHERE MatchOutcomeID = @MatchOutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the match outcome ID, match ID, winner ID, and outcome ID to tblMatchOutcome
            cmd.Parameters.AddWithValue("@MatchOutcomeID", matchOutcomeID);
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.Parameters.AddWithValue("@WinnerID", winnerID);
            cmd.Parameters.AddWithValue("@OutcomeID", outcomeID);
            cmd.ExecuteNonQuery();
        }
    }
    public void deleteMatchOutcome(int matchOutcomeID)
    {
        // deletes a match outcome from the tblMatchOutcome table based on the MatchOutcomeID
        string sql = "DELETE FROM tblMatchOutcome WHERE MatchOutcomeID = @MatchOutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the match outcome to be deleted
            cmd.Parameters.AddWithValue("@MatchOutcomeID", matchOutcomeID);
            cmd.ExecuteNonQuery();
        }
    }


    // Methods for retrieving fighters sorted by different criteria
    public List<Fighter> GetFightersSortedByFirstName()
    {
        // retrieves fighters sorted by their first names
        List<Fighter> fighterList = new List<Fighter>();
        string sql = "SELECT FirstName, LastName FROM tblFighter ORDER BY FirstName ASC";
        // using SqlCommand to execute the SQL query
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Fighter fighter = new Fighter
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                // adding the fighter to the list
                fighterList.Add(fighter);
            }
        }
        // returning the list of fighters sorted by first name
        return fighterList;
    }
    public List<Fighter> GetFightersSortedByWins()
    {
        // retrieves fighters sorted by their number of wins
        List<Fighter> fighterList = new List<Fighter>();
        string sql = "SELECT FirstName, LastName, Wins FROM tblFighter ORDER BY Wins DESC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // creating a Fighter object and populating it with data from the database
                Fighter fighter = new Fighter
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Wins = Convert.ToInt32(reader["Wins"])
                };
                // adding the fighter to the list
                fighterList.Add(fighter);
            }
        }
        // returning the list of fighters sorted by wins
        return fighterList;
    }
    public List<(string FirstName, string LastName, string GymName)> GetFightersWithGyms()
    {
        // retrieves fighters along with their gym names
        var fighterGymList = new List<(string FirstName, string LastName, string GymName)>();
        string sql = @"
        SELECT tblFighter.FirstName, tblFighter.LastName, tblGym.GymName
        FROM tblFighter
        INNER JOIN tblGym ON tblFighter.GymID = tblGym.GymID";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the first name, last name, and gym name from the database
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string gymName = reader["GymName"].ToString();
                fighterGymList.Add((firstName, lastName, gymName));
            }
        }
        // returning the list of fighters with their gym names
        return fighterGymList;
    }
    public List<(string FirstName, string LastName, string Weightclass)> GetFightersWithWeightclasses()
    {
        // retrieves fighters along with their weight classes
        var result = new List<(string FirstName, string LastName, string Weightclass)>();
        string sql = @"
        SELECT tblFighter.FirstName, tblFighter.LastName, tblWeightclasses.Weightclass
        FROM tblFighter
        INNER JOIN tblWeightclasses ON tblFighter.WeightclassID = tblWeightclasses.WeightclassID";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the first name, last name, and weight class from the database
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string weightclass = reader["Weightclass"].ToString();
                result.Add((firstName, lastName, weightclass));
            }
        }
        //  returning the list of fighters with their weight classes
        return result;
    }
    public List<(string RegionName, string GymName)> GetGymsByRegion()
    {
        // retrieves gyms along with their region names
        var result = new List<(string RegionName, string GymName)>();
        string sql = @"
        SELECT RegionName, GymName  
        FROM tblRegion, tblGym 
        WHERE tblRegion.RegionID = tblGym.GymID";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the region name and gym name from the database
                string regionName = reader["RegionName"].ToString();
                string gymName = reader["GymName"].ToString();
                result.Add((regionName, gymName));
            }
        }
        //  returning the list of gyms with their region names
        return result;
    }
    public List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)> GetMatchOutcomeDetails()
    {
        // retrieves match outcome details including fighter names, match ID, and outcome description
        var results = new List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)>();

        string sql = @"
        SELECT DISTINCT tblFighter.FirstName, tblFighter.LastName, tblMatch.MatchID, tblOutcomeType.OutcomeDescription
        FROM tblFighter, tblMatch, tblMatchOutcome, tblOutcomeType
        WHERE tblMatch.MatchID = tblMatchOutcome.MatchID
          AND tblMatchOutcome.OutcomeID = tblOutcomeType.OutcomeID
          AND (tblFighter.FighterID = tblMatch.Fighter1ID OR tblFighter.FighterID = tblMatch.Fighter2ID)";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the first name, last name, match ID, and outcome description from the database
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                int matchID = Convert.ToInt32(reader["MatchID"]);
                string outcome = reader["OutcomeDescription"].ToString();

                results.Add((firstName, lastName, matchID, outcome));
            }
        }
        // returning the list of match outcome details
        return results;
    }
    public List<(string FirstName, string LastName, string Weightclass, string GymName)> GetFighterProfile()
    {
        var result = new List<(string FirstName, string LastName, string Weightclass, string GymName)>();
        // retrieves fighter profiles including first name, last name, weight class, and gym name
        string sql = @"
        SELECT tblFighter.FirstName, tblFighter.LastName, 
               tblWeightclasses.Weightclass, tblGym.GymName
        FROM tblFighter, tblWeightclasses, tblGym
        WHERE tblFighter.WeightclassID = tblWeightclasses.WeightclassID
          AND tblFighter.GymID = tblGym.GymID";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the first name, last name, weight class, and gym name from the database
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string weightclass = reader["Weightclass"].ToString();
                string gymName = reader["GymName"].ToString();

                result.Add((firstName, lastName, weightclass, gymName));
            }
        }
        //  returning the list of fighter profiles
        return result;
    }
    public List<(string GymName, int TotalFighters)> GetGymFighterCounts()
    {
        var result = new List<(string GymName, int TotalFighters)>();
        // retrieves the total number of fighters in each gym, sorted by the number of fighters in descending order
        string sql = @"
        SELECT tblGym.GymName, COUNT(tblFighter.FighterID) AS TotalFighters
        FROM tblFighter, tblGym
        WHERE tblFighter.GymID = tblGym.GymID
        GROUP BY tblGym.GymName
        ORDER BY TotalFighters DESC";
        // using SqlCommand to execute the SQL query
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the gym name and total fighters from the database
                string gymName = reader["GymName"].ToString();
                int totalFighters = Convert.ToInt32(reader["TotalFighters"]);
                result.Add((gymName, totalFighters));
            }
        }
        // returning the list of gyms with their total fighters
        return result;
    }
    public List<(string GymName, int TotalWins, int TotalLosses, int TotalDraws)> GetGymFightStats()
    {
        var result = new List<(string GymName, int TotalWins, int TotalLosses, int TotalDraws)>();
        // retrieves the total wins, losses, and draws for each gym, filtering gyms with more than 10 total fights
        string sql = @"
        SELECT GymName, 
               SUM(Wins) AS TotalWins, 
               SUM(Losses) AS TotalLosses, 
               SUM(Draws) AS TotalDraws
        FROM tblFighter, tblGym
        WHERE tblFighter.GymID = tblGym.GymID
        GROUP BY GymName
        HAVING SUM(Wins) + SUM(Losses) + SUM(Draws) > 10
        ORDER BY TotalWins DESC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the gym name, total wins, total losses, and total draws from the database
                string gymName = reader["GymName"].ToString();
                int wins = Convert.ToInt32(reader["TotalWins"]);
                int losses = Convert.ToInt32(reader["TotalLosses"]);
                int draws = Convert.ToInt32(reader["TotalDraws"]);

                result.Add((gymName, wins, losses, draws));
            }
        }
        // returning the list of gyms with their fight statistics
        return result;
    }
    public List<(int MatchYear, int TotalMatches)> GetMatchCountByYear()
    {
        var result = new List<(int MatchYear, int TotalMatches)>();
        // retrieves the total number of matches for the year 2025, grouped by year
        string sql = @"
        SELECT YEAR(MatchDate) AS MatchYear, 
               COUNT(MatchID) AS TotalMatches
        FROM tblMatch
        WHERE YEAR(MatchDate) = 2025
        GROUP BY YEAR(MatchDate)
        ORDER BY MatchYear ASC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the match year and total matches from the database
                int year = Convert.ToInt32(reader["MatchYear"]);
                int count = Convert.ToInt32(reader["TotalMatches"]);
                result.Add((year, count));
            }
        }
        // returning the list of match counts by year
        return result;
    }
    public List<(string WeightClassName, double AverageAge)> GetAverageAgeByWeightclass()
    {
        var result = new List<(string WeightClassName, double AverageAge)>();
        //  retrieves the average age of fighters in each weight class, sorted by average age in ascending order
        string sql = @"
        SELECT Weightclass AS WeightClassName, 
               AVG(Age) AS AverageAge
        FROM tblFighter, tblWeightclasses
        WHERE tblFighter.WeightclassID = tblWeightclasses.WeightclassID
        GROUP BY Weightclass
        ORDER BY AverageAge ASC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the weight class name and average age from the database
                string weightClassName = reader["WeightClassName"].ToString();
                double averageAge = Convert.ToDouble(reader["AverageAge"]);
                result.Add((weightClassName, averageAge));
            }
        }
        // returning the list of average ages by weight class
        return result;
    }
    public List<(string FighterFirstName, string FighterLastName, int TotalMatches)> GetFighterMatchCountsFor2025()
    {
        var result = new List<(string FighterFirstName, string FighterLastName, int TotalMatches)>();
        // retrieves the total number of matches for each fighter in the year 2025, sorted by total matches in descending order
        string sql = @"
        SELECT FirstName AS FighterFirstName, LastName AS FighterLastName, 
               COUNT(MatchID) AS TotalMatches
        FROM tblFighter, tblMatch
        WHERE (tblMatch.Fighter1ID = tblFighter.FighterID OR tblMatch.Fighter2ID = tblFighter.FighterID)
          AND YEAR(tblMatch.MatchDate) = 2025
        GROUP BY FirstName, LastName
        ORDER BY TotalMatches DESC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the fighter's first name, last name, and total matches from the database
                string firstName = reader["FighterFirstName"].ToString();
                string lastName = reader["FighterLastName"].ToString();
                int totalMatches = Convert.ToInt32(reader["TotalMatches"]);

                result.Add((firstName, lastName, totalMatches));
            }
        }
        // returning the list of fighter match counts for 2025
        return result;
    }
    public List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)> GetFighterMatchOutcomes()
    {
        var result = new List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)>();
        // retrieves match outcomes for fighters, including their first name, last name, match ID, and outcome description
        string sql = @"
        SELECT Firstname, Lastname, tblMatch.MatchID, tblOutcomeType.OutcomeDescription 
        FROM tblFighter, tblMatch, tblMatchOutcome, tblOutcomeType 
        WHERE tblMatch.MatchID = tblMatchOutcome.MatchID 
          AND tblMatchOutcome.OutcomeID = tblOutcomeType.OutcomeID 
          AND FighterID = Fighter1ID 
          OR FighterID = Fighter2ID";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                // reading the first name, last name, match ID, and outcome description from the database
                string firstName = reader["Firstname"].ToString();
                string lastName = reader["Lastname"].ToString();
                int matchID = Convert.ToInt32(reader["MatchID"]);
                string outcome = reader["OutcomeDescription"].ToString();

                result.Add((firstName, lastName, matchID, outcome));
            }
        }
        // returning the list of fighter match outcomes
        return result;
    }


    public bool IsUniqueWeightclassName(string name)
    {
        using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\FARJA\\ONEDRIVE - AVONDALE COLLEGE\\FARJADBOXINGDATABASE\\BOXINGAPP\\DB\\BOXINGDATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
        {
            connection.Open();
            // Use the correct column name: Weightclass
            string query = "SELECT COUNT(*) FROM tblWeightclasses WHERE LOWER(LTRIM(RTRIM(Weightclass))) = LOWER(LTRIM(RTRIM(@name)))";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                int count = (int)command.ExecuteScalar();
                return count == 0; // true = unique; false = already exists
            }
        }
    }


  
    //validate user input and paramaterise it    
    public static class InputValidator
    {
        public static string ReadInput(string prompt, int minLength = 2, int maxLength = 30)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    
                    Console.WriteLine("Input cannot be blank.");
                    continue;
                }

                if (input.Length < minLength || input.Length > maxLength)
                {
                    
                    Console.WriteLine($"Input must be between {minLength} and {maxLength} characters.");
                    continue;
                }

               
                return input;
            }
        }
    }
    

    // Methods to check if a record exists in various tables
    public bool DoesRegionExist(int regionID)
    {
        // checks if a region exists in the tblRegion table based on the RegionID
        string sql = "SELECT COUNT(*) FROM tblRegion WHERE RegionID = @RegionID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the region to be checked
            cmd.Parameters.AddWithValue("@RegionID", regionID);
            int count = (int)cmd.ExecuteScalar();
            // returns true if the region exists, false otherwise
            return count > 0;
        }
    }
    // checks if a fighter exists in the tblFighter table based on the FighterID
    public bool DoesFighterExist(int fighterID)
    {
        // checks if a fighter exists in the tblFighter table based on the FighterID
        string sql = "SELECT COUNT(*) FROM tblFighter WHERE FighterID = @FighterID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the fighter to be checked
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    // checks if a weight class exists in the tblWeightclasses table based on the WeightclassID
    public bool DoesWeightclassExist(int weightclassID)
    {
        // checks if a weight class exists in the tblWeightclasses table based on the WeightclassID
        string sql = "SELECT COUNT(*) FROM tblWeightclasses WHERE WeightclassID = @WeightclassID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the weight class to be checked
            cmd.Parameters.AddWithValue("@WeightclassID", weightclassID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    // checks if a gym exists in the tblGym table based on the GymID
    public bool DoesGymExist(int gymID)
    {
        // checks if a gym exists in the tblGym table based on the GymID
        string sql = "SELECT COUNT(*) FROM tblGym WHERE GymID = @GymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the gym to be checked
            cmd.Parameters.AddWithValue("@GymID", gymID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    // checks if an outcome type exists in the tblOutcomeType table based on the OutcomeID
    public bool DoesOutcomeTypeExist(int outcomeID)
    {
        // checks if an outcome type exists in the tblOutcomeType table based on the OutcomeID
        string sql = "SELECT COUNT(*) FROM tblOutcomeType WHERE OutcomeID = @OutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the outcome type to be checked
            cmd.Parameters.AddWithValue("@OutcomeID", outcomeID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    // checks if a match exists in the tblMatch table based on the MatchID
    public bool DoesMatchExist(int matchID)
    {
        // checks if a match exists in the tblMatch table based on the MatchID
        string sql = "SELECT COUNT(*) FROM tblMatch WHERE MatchID = @MatchID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            // adds the ID of the match to be checked
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }

}
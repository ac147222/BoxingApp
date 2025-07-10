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

    public bool RegisterUser(string username, string password)
    {
        
        string checkSql = "SELECT COUNT(*) FROM tblUser WHERE Username = @Username";
        using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
        {
            checkCmd.Parameters.AddWithValue("@Username", username);
            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
                return false; 
        }

        
        string insertSql = "INSERT INTO tblUser (Username, Password, IsAdmin) VALUES (@Username, @Password, 0)";
        using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
        {
            insertCmd.Parameters.AddWithValue("@Username", username);
            insertCmd.Parameters.AddWithValue("@Password", password); 
            insertCmd.ExecuteNonQuery();
        }
        return true;
    }

    public User AuthenticateUser(string username, string password)
    {
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
        string sqlString = "SELECT * FROM dbo.tblRegion";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int Region_ID = Convert.ToInt32(reader["RegionID"]);
                    string Region_Name = reader["RegionName"].ToString();
                    regions.Add(new Region(Region_ID, Region_Name));
                }
            }
        }
        return regions;
    }
    public void AddRegion(string name)
    {
        string sql = "INSERT INTO tblRegion (RegionName) VALUES (@RegionName)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@RegionName", name);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateRegion(int id, string newName)
    {
        string sql = "UPDATE tblRegion SET RegionName = @RegionName WHERE RegionID = @RegionID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@RegionName", newName);
            cmd.Parameters.AddWithValue("@RegionID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteRegion(int id)
    {
        string sql = "DELETE FROM tblRegion WHERE RegionID = @RegionID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@RegionID", id);
            cmd.ExecuteNonQuery();
        }
    }


    public List<Weightclass> GetAllWeightclasses()
    {
        var weightclasses = new List<Weightclass>();
        string sql = "SELECT WeightclassID, Weightclass FROM dbo.tblWeightclasses";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["WeightclassID"]);
                
                string name = reader["Weightclass"].ToString().Trim();
                weightclasses.Add(new Weightclass(id, name));
            }
        }
        return weightclasses;
    }
    public void AddWeightclasses(string name)
    {
        string sql = "INSERT INTO tblWeightclasses (Weightclass) VALUES (@Weightclass)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Weightclass", name);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateWeightclasses(int id, string newName)
    {
        string sql = "UPDATE tblWeightclasses SET Weightclass = @Weightclass WHERE WeightclassID = @WeightclassID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Weightclass", newName);
            cmd.Parameters.AddWithValue("@WeightclassID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteWeightclasses(int id)
    {
        string sql = "DELETE FROM tblWeightclasses WHERE WeightclassID = @WeightclassID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@WeightclassID", id);
            cmd.ExecuteNonQuery();
        }
    }


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
        string sql = "INSERT INTO tblGym (GymName, RegionID) VALUES (@GymName, @RegionID)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@GymName", name);
            cmd.Parameters.AddWithValue("@RegionID", ID);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateGym(int id, string newName)
    {
        string sql = "UPDATE tblGym SET GymName = @GymName WHERE GymID = @ID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@GymName", newName);
            cmd.Parameters.AddWithValue("@GymID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteGym(int id)
    {
        string sql = "DELETE FROM tblGym WHERE GymID = @GymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@GymID", id);
            cmd.ExecuteNonQuery();
        }
    }


    public List<Match> GetAllMatches()
    {
        List<Match> matches = new List<Match>();
        string sqlString = "SELECT * FROM dbo.tblMatch";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int MatchID = Convert.ToInt32(reader["MatchID"]);
                    int Fighter1ID = Convert.ToInt32(reader["Fighter1ID"]);
                    int Fighter2ID = Convert.ToInt32(reader["Fighter2ID"]);
                    DateTime MatchDate = Convert.ToDateTime(reader["MatchDate"]);
                    matches.Add(new Match(MatchID, Fighter1ID, Fighter2ID, MatchDate));
                }
            }
        }
        return matches;
    }
    public void AddMatch(int fighter1ID, int fighter2ID, DateTime matchDate)
    {
        string sql = "INSERT INTO tblMatch (Fighter1ID, Fighter2ID, MatchDate) VALUES (@Fighter1ID, @Fighter2ID, @MatchDate)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Fighter1ID", fighter1ID);
            cmd.Parameters.AddWithValue("@Fighter2ID", fighter2ID);
            cmd.Parameters.AddWithValue("@MatchDate", matchDate);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateMatch(int matchID, int fighter1ID, int fighter2ID, DateTime matchDate)
    {
        string sql = "UPDATE tblMatch SET Fighter1ID = @Fighter1ID, Fighter2ID = @Fighter2ID, MatchDate = @MatchDate WHERE MatchID = @MatchID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Fighter1ID", fighter1ID);
            cmd.Parameters.AddWithValue("@Fighter2ID", fighter2ID);
            cmd.Parameters.AddWithValue("@MatchDate", matchDate);
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteMatch(int matchID)
    {
        string sql = "DELETE FROM tblMatch WHERE MatchID = @MatchID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.ExecuteNonQuery();
        }
    }


    public List<OutcomeType> GetAllOutcomeTypes()
    {
        List<OutcomeType> outcomeTypes = new List<OutcomeType>();
        string sqlString = "SELECT * FROM dbo.tblOutcomeType";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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
        string sql = "INSERT INTO tblOutcomeType (OutcomeDescription) VALUES (@OutcomeDescription)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))  
        {
            cmd.Parameters.AddWithValue("@OutcomeDescription", description);
            cmd.ExecuteNonQuery();
        }
    }
    public void UpdateOutcomeType(int id, string description)
    {
        string sql = "UPDATE tblOutcomeType SET OutcomeDescription = @OutcomeDescription WHERE OutcomeID = @OutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@OutcomeDescription", description);
            cmd.Parameters.AddWithValue("@OutcomeID", id);
            cmd.ExecuteNonQuery();
        }
    }
    public void DeleteOutcomeType(int id)
    {
        string sql = "DELETE FROM tblOutcomeType WHERE OutcomeID = @OutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@OutcomeID", id);
            cmd.ExecuteNonQuery();
        }
    }


    public List<Fighter> GetAllFighters()
    {
        List<Fighter> fighter = new List<Fighter>();
        string sqlString = "SELECT * FROM dbo.tblFighter";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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
        return fighter;
    }
    public void AddFighter(string firstName, string lastName, int age, int regionID, int gymID, int weightclassID, int wins, int losses, int draws)
    {
        string sql = "INSERT INTO tblFighter (FirstName, LastName, Age, RegionID, GymID, WeightclassID, Wins, Losses, Draws) VALUES (@FirstName, @LastName, @Age, @RegionID, @GymID, @WeightclassID, @Wins, @Losses, @Draws)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
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
        string sql = "UPDATE tblFighter SET FirstName = @FirstName, LastName = @LastName, Age = @Age, RegionID = @RegionID, GymID = @GymID, WeightclassID = @WeightclassID, Wins = @Wins, Losses = @Losses, Draws = @Draws WHERE FighterID = @FighterID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
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
        string sql = "DELETE FROM tblFighter WHERE FighterID = @FighterID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            cmd.ExecuteNonQuery();
        }
    }


    public List<FighterAndGym> GetAllFighterAndGyms()
    {
        List<FighterAndGym> fighterAndGyms = new List<FighterAndGym>();
        string sqlString = "SELECT * FROM dbo.tblFighterAndGym";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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
        return fighterAndGyms;
    }
    public void AddFighterAndGym(int fighterID, int gymID, int totalWins, int totalLosses, int totalDraws)
    {
        string sql = "INSERT INTO tblFighterAndGym (FighterID, GymID, TotalWins, TotalLosses, TotalDraws) VALUES (@FighterID, @GymID, @TotalWins, @TotalLosses, @TotalDraws)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
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
        string sql = "UPDATE tblFighterAndGym SET FighterID = @FighterID, GymID = @GymID, TotalWins = @TotalWins, TotalLosses = @TotalLosses, TotalDraws = @TotalDraws WHERE FighterAndGymID = @FighterAndGymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
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
        string sql = "DELETE FROM tblFighterAndGym WHERE FighterAndGymID = @FighterAndGymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@FighterAndGymID", fighterAndGymID);
            cmd.ExecuteNonQuery();
        }
    }

    public List<MatchOutcome> GetAllMatchOutcomes()
    {
        List<MatchOutcome> matchOutcome = new List<MatchOutcome>();
        string sqlString = "SELECT * FROM dbo.tblMatchOutcome";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int MatchOutcomeID = Convert.ToInt32(reader["MatchOutcomeID"]);
                    int MatchID = Convert.ToInt32(reader["MatchID"]);
                    int? WinnerID = reader["WinnerID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["WinnerID"]) : null;
                    int OutcomeID = Convert.ToInt32(reader["OutcomeID"]);
                    matchOutcome.Add(new MatchOutcome(MatchOutcomeID, MatchID, WinnerID, OutcomeID));
                    
                }
            }
        }
        return matchOutcome;
    }
    public void AddMatchOutcome(int matchID, int winnerID, int outcomeID)
    {
        string sql = "INSERT INTO tblMatchOutcome (MatchID, WinnerID, OutcomeID) VALUES (@MatchID, @WinnerID, @OutcomeID)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.Parameters.AddWithValue("@WinnerID", winnerID);
            cmd.Parameters.AddWithValue("@OutcomeID", outcomeID);
            cmd.ExecuteNonQuery();
        }
    }
    public void updateMatchOutcome(int matchOutcomeID, int matchID, int winnerID, int outcomeID)
    {
        string sql = "UPDATE tblMatchOutcome SET MatchID = @MatchID, WinnerID = @WinnerID, OutcomeID = @OutcomeID WHERE MatchOutcomeID = @MatchOutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@MatchOutcomeID", matchOutcomeID);
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            cmd.Parameters.AddWithValue("@WinnerID", winnerID);
            cmd.Parameters.AddWithValue("@OutcomeID", outcomeID);
            cmd.ExecuteNonQuery();
        }
    }
    public void deleteMatchOutcome(int matchOutcomeID)
    {
        string sql = "DELETE FROM tblMatchOutcome WHERE MatchOutcomeID = @MatchOutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@MatchOutcomeID", matchOutcomeID);
            cmd.ExecuteNonQuery();
        }
    }


    public List<Fighter> GetFightersSortedByFirstName()
    {
        List<Fighter> fighterList = new List<Fighter>();
        string sql = "SELECT FirstName, LastName FROM tblFighter ORDER BY FirstName ASC";

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
                fighterList.Add(fighter);
            }
        }

        return fighterList;
    }
    public List<Fighter> GetFightersSortedByWins()
    {
        List<Fighter> fighterList = new List<Fighter>();
        string sql = "SELECT FirstName, LastName, Wins FROM tblFighter ORDER BY Wins DESC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Fighter fighter = new Fighter
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Wins = Convert.ToInt32(reader["Wins"])
                };
                fighterList.Add(fighter);
            }
        }

        return fighterList;
    }
    public List<(string FirstName, string LastName, string GymName)> GetFightersWithGyms()
    {
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
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string gymName = reader["GymName"].ToString();
                fighterGymList.Add((firstName, lastName, gymName));
            }
        }

        return fighterGymList;
    }
    public List<(string FirstName, string LastName, string Weightclass)> GetFightersWithWeightclasses()
    {
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
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string weightclass = reader["Weightclass"].ToString();
                result.Add((firstName, lastName, weightclass));
            }
        }

        return result;
    }
    public List<(string RegionName, string GymName)> GetGymsByRegion()
    {
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
                string regionName = reader["RegionName"].ToString();
                string gymName = reader["GymName"].ToString();
                result.Add((regionName, gymName));
            }
        }

        return result;
    }
    public List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)> GetMatchOutcomeDetails()
    {
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
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                int matchID = Convert.ToInt32(reader["MatchID"]);
                string outcome = reader["OutcomeDescription"].ToString();

                results.Add((firstName, lastName, matchID, outcome));
            }
        }

        return results;
    }
    public List<(string FirstName, string LastName, string Weightclass, string GymName)> GetFighterProfile()
    {
        var result = new List<(string FirstName, string LastName, string Weightclass, string GymName)>();

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
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string weightclass = reader["Weightclass"].ToString();
                string gymName = reader["GymName"].ToString();

                result.Add((firstName, lastName, weightclass, gymName));
            }
        }

        return result;
    }
    public List<(string GymName, int TotalFighters)> GetGymFighterCounts()
    {
        var result = new List<(string GymName, int TotalFighters)>();

        string sql = @"
        SELECT tblGym.GymName, COUNT(tblFighter.FighterID) AS TotalFighters
        FROM tblFighter, tblGym
        WHERE tblFighter.GymID = tblGym.GymID
        GROUP BY tblGym.GymName
        ORDER BY TotalFighters DESC";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string gymName = reader["GymName"].ToString();
                int totalFighters = Convert.ToInt32(reader["TotalFighters"]);
                result.Add((gymName, totalFighters));
            }
        }

        return result;
    }
    public List<(string GymName, int TotalWins, int TotalLosses, int TotalDraws)> GetGymFightStats()
    {
        var result = new List<(string GymName, int TotalWins, int TotalLosses, int TotalDraws)>();

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
                string gymName = reader["GymName"].ToString();
                int wins = Convert.ToInt32(reader["TotalWins"]);
                int losses = Convert.ToInt32(reader["TotalLosses"]);
                int draws = Convert.ToInt32(reader["TotalDraws"]);

                result.Add((gymName, wins, losses, draws));
            }
        }

        return result;
    }
    public List<(int MatchYear, int TotalMatches)> GetMatchCountByYear()
    {
        var result = new List<(int MatchYear, int TotalMatches)>();

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
                int year = Convert.ToInt32(reader["MatchYear"]);
                int count = Convert.ToInt32(reader["TotalMatches"]);
                result.Add((year, count));
            }
        }

        return result;
    }
    public List<(string WeightClassName, double AverageAge)> GetAverageAgeByWeightclass()
    {
        var result = new List<(string WeightClassName, double AverageAge)>();

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
                string weightClassName = reader["WeightClassName"].ToString();
                double averageAge = Convert.ToDouble(reader["AverageAge"]);
                result.Add((weightClassName, averageAge));
            }
        }

        return result;
    }
    public List<(string FighterFirstName, string FighterLastName, int TotalMatches)> GetFighterMatchCountsFor2025()
    {
        var result = new List<(string FighterFirstName, string FighterLastName, int TotalMatches)>();

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
                string firstName = reader["FighterFirstName"].ToString();
                string lastName = reader["FighterLastName"].ToString();
                int totalMatches = Convert.ToInt32(reader["TotalMatches"]);

                result.Add((firstName, lastName, totalMatches));
            }
        }

        return result;
    }
    public List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)> GetFighterMatchOutcomes()
    {
        var result = new List<(string FirstName, string LastName, int MatchID, string OutcomeDescription)>();

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
                string firstName = reader["Firstname"].ToString();
                string lastName = reader["Lastname"].ToString();
                int matchID = Convert.ToInt32(reader["MatchID"]);
                string outcome = reader["OutcomeDescription"].ToString();

                result.Add((firstName, lastName, matchID, outcome));
            }
        }

        return result;
    }





    public bool DoesRegionExist(int regionID)
    {
        string sql = "SELECT COUNT(*) FROM tblRegion WHERE RegionID = @RegionID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@RegionID", regionID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    public bool DoesFighterExist(int fighterID)
    {
        string sql = "SELECT COUNT(*) FROM tblFighter WHERE FighterID = @FighterID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@FighterID", fighterID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    public bool DoesWeightclassExist(int weightclassID)
    {
        string sql = "SELECT COUNT(*) FROM tblWeightclasses WHERE WeightclassID = @WeightclassID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@WeightclassID", weightclassID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    public bool DoesGymExist(int gymID)
    {
        string sql = "SELECT COUNT(*) FROM tblGym WHERE GymID = @GymID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@GymID", gymID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    public bool DoesOutcomeTypeExist(int outcomeID)
    {
        string sql = "SELECT COUNT(*) FROM tblOutcomeType WHERE OutcomeID = @OutcomeID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@OutcomeID", outcomeID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }
    public bool DoesMatchExist(int matchID)
    {
        string sql = "SELECT COUNT(*) FROM tblMatch WHERE MatchID = @MatchID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@MatchID", matchID);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }

}
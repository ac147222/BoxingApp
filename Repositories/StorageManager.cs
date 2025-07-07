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
        string sql = "INSERT INTO tblWeightclasses (WeightclassesName) VALUES (@WeightclassesName)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@WeightclassesName", name);
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateWeightclasses(int id, string newName)
    {
        string sql = "UPDATE tblWeightclasses SET WeightclassesName = @WeightclassesName WHERE WeightclassesID = @WeightclassesID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@WeightclassesName", newName);
            cmd.Parameters.AddWithValue("@WeightclassesID", id);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteWeightclasses(int id)
    {
        string sql = "DELETE FROM tblWeightclasses WHERE WeightclassesID = @WeightclassesID";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@WeightclassesID", id);
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
}
using BoxingApp;
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
        // Checks if username exists
        string checkSql = "SELECT COUNT(*) FROM tblUser WHERE Username = @Username";
        using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
        {
            checkCmd.Parameters.AddWithValue("@Username", username);
            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
                return false; // Username taken
        }

        // Inserts new user with IsAdmin = 0
        string insertSql = "INSERT INTO tblUser (Username, Password, IsAdmin) VALUES (@Username, @Password, 0)";
        using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
        {
            insertCmd.Parameters.AddWithValue("@Username", username);
            insertCmd.Parameters.AddWithValue("@Password", password); // For production, hash your passwords!
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

    public void InsertRegion(string regionName)
    {
        string sqlString = "INSERT INTO dbo.tblRegion (RegionName) VALUES (@RegionName)";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@RegionName", regionName);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Region added successfully.");
    }

    public void UpdateRegionName(int regionId, string newName)
    {
        string sqlString = "UPDATE dbo.tblRegion SET RegionName = @RegionName WHERE RegionID = @RegionID";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@RegionID", regionId);
            cmd.Parameters.AddWithValue("@RegionName", newName);  
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Region updated successfully.");
            else
                Console.WriteLine("Region not found.");
        }
    }

    public void DeleteRegionByName(string regionName)
    {
        string sqlString = "DELETE FROM dbo.tblRegion WHERE RegionName = @RegionName";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@RegionName", regionName);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Region deleted successfully.");
            else
                Console.WriteLine("Region not found.");
        }
    }

    internal void AddRegion(string? name)
    {
        throw new NotImplementedException();
    }

    internal void UpdateRegion(int id, string? newName)
    {
        throw new NotImplementedException();
    }

    internal void DeleteRegion(int id)
    {
        throw new NotImplementedException();
    }
}
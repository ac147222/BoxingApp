using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

public class StorageManager
{
    private SqlConnection conn;

    public StorageManager(string connectionString)
    {
        conn = new SqlConnection(connectionString);
        conn.Open();
    }

    public User AuthenticateUser(string username, string password)
    {
        string sql = "SELECT * FROM dbo.tblUser WHERE Username = @Username AND Password = @Password";
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
                        Role = reader["Role"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        
                    };
                }
            }
        }
        return null;
    }


    public List<region> GetAllRegions()
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
}
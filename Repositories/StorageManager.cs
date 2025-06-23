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

    public bool RegisterUser(string username, string pin)
    {
        string sql = "INSERT INTO dbo.tblUser (Username, Password) VALUES (@Username, @Password)";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", pin);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
               
                return false;
            }
        }
    }

   
    public static class PinValidator
    {
        public static bool IsValidPin(string pin)
        {
            return pin.Length == 6 && pin.All(char.IsDigit);
        }
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
}
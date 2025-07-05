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

    public List<Weightclasses> GetAllWeightclasses()
    {
        List<Weightclasses> weightclasses = new List<Weightclasses>();
        string sqlString = "SELECT * FROM dbo.tblWeightclasses";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int weightclassID = Convert.ToInt32(reader["WeightclassID"]);
                    string weightclass = reader["Weightclass"].ToString();
                    weightclasses.Add(new Weightclasses(weightclassID, weightclass));
                }
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

}
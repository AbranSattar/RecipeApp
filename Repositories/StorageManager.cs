using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using RecipeApp.Models;

namespace RecipeApp.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection successful");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection not successful\n");
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured");
                Console.WriteLine(ex.Message);
            }
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            string allCountries = "Select * FROM tblCountry";
            using (SqlCommand cmd = new SqlCommand(allCountries, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int countryID = Convert.ToInt32(reader["CountryID"]);
                        string countryName = reader["Country"].ToString();
						countries.Add(new Country(countryID, countryName));
                    }
                }
            }
            return countries;
        }
		// Country CRUD Operations
		public int UpdateCountry(int countryID, string countryName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE tblCountry SET Country = @countryName WHERE CountryID = @countryID", conn))
            {
                cmd.Parameters.AddWithValue("@countryName", countryName);
                cmd.Parameters.AddWithValue("@countryID", countryID);
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertCountry(Country countryTemp)
        {
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblCountry (Country) VALUES (@countryName); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@countryName", countryTemp.countryName);
                return Convert.ToInt32(cmd.ExecuteScalar);
            }
        }

        public int DeleteCountry(string countryName)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblCountry WHERE Country = @countryName;", conn))
            {
                cmd.Parameters.AddWithValue("@countryName", countryName);
                return cmd.ExecuteNonQuery();
            }
        }
		//Role CRUD Operations
		public int UpdateRole(int roleID, string role)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblRole SET Role = @role WHERE RoleID = @roleID", conn))
			{
				cmd.Parameters.AddWithValue("@role", role);
				cmd.Parameters.AddWithValue("@roleID", roleID);
				return cmd.ExecuteNonQuery();
			}
		}

		public int InsertRole(Role roleTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRole (Role) VALUES (@role); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@role", roleTemp.role);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}

		public int DeleteRole(string role)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblRole WHERE Role = @role;", conn))
			{
				cmd.Parameters.AddWithValue("@role", role);
				return cmd.ExecuteNonQuery();
			}
		}
		// Close the connection
		public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
    }
 }

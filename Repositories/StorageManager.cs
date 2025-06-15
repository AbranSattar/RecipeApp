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
        // CRUD operations for Region

        public int UpdateRegion(int regionID, string regionName)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblRegion SET Region = @regionName WHERE RegionID = @regionID", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionName);
				cmd.Parameters.AddWithValue("@regionID", regionID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertRegion(Region regionTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRegion (Region) VALUES (@regionName); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionTemp.Area);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteRegion(string regionName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblRegion WHERE Region = @regionName;", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionName);
				return cmd.ExecuteNonQuery();
			}
		}
		// CRUD operations for City
		public int UpdateCity(int cityID, string cityName)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblCity SET City = @cityName WHERE CityID = @cityID", conn))
			{
				cmd.Parameters.AddWithValue("@cityName", cityName);
				cmd.Parameters.AddWithValue("@cityID", cityID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertCity(City cityTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblCity (City) VALUES (@cityName); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@cityName", cityTemp.city);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteCity(string cityName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblCity WHERE City = @cityName;", conn))
			{
				cmd.Parameters.AddWithValue("@cityName", cityName);
				return cmd.ExecuteNonQuery();
			}
		}
		// CRUD operations for Suburb
		public int UpdateSuburb(int suburbID, string suburbName)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblSuburb SET Suburb = @suburbName WHERE SuburbID = @suburbID", conn))
			{
				cmd.Parameters.AddWithValue("@suburbName", suburbName);
				cmd.Parameters.AddWithValue("@suburbID", suburbID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertSuburb(Suburb suburbTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblSuburb (Suburb) VALUES (@suburbName); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@suburbName", suburbTemp.suburb);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteSuburb(string suburbName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblSuburb WHERE Suburb = @suburbName;", conn))
			{
				cmd.Parameters.AddWithValue("@suburbName", suburbName);
				return cmd.ExecuteNonQuery();
			}
		}
		// CRUD operations for Store
		public int UpdateStore(int storeID, string storeName)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblStore SET Store = @storeName WHERE StoreID = @storeID", conn))
			{
				cmd.Parameters.AddWithValue("@storeName", storeName);
				cmd.Parameters.AddWithValue("@storeID", storeID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertStore(Store storeTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblStore (Store) VALUES (@storeName); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@storeName", storeTemp.store);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteStore(string storeName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblStore WHERE Store = @storeName;", conn))
			{
				cmd.Parameters.AddWithValue("@storeName", storeName);
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

using System;
using System.Collections.Generic;
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
            List<Country> Countries = new List<Country>();
            string sqlString = "Select * FROM tblCountry";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int countryID = Convert.ToInt32(reader["COUNTRY_ID"]);
                        string countryName = reader["COUNTRY_NAME"].ToString();
                        Countries.Add(new Country(countryID, countryName));
                    }
                }
            }
            return Countries;
        }
    }
}

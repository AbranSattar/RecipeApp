﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
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
		public int GetRoleIDByName(string roleName)
		{
			using (SqlCommand cmd = new SqlCommand("SELECT roleID FROM Role WHERE role = @roleName", conn))
			{
				cmd.Parameters.AddWithValue("@roleName", roleName);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1;
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
		public List<Role> GetAllRoles()
		{
			List<Role> roles = new List<Role>();
			string allRoles = "Select * FROM tblRole";
			using (SqlCommand cmd = new SqlCommand(allRoles, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int roleID = Convert.ToInt32(reader["RoleID"]);
						string roleName = reader["Role"].ToString();
						roles.Add(new Role(roleID, roleName));
					}
				}
			}
			return roles;
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
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRegion (Region) VALUES (@regionName), (@countryID); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionTemp.Area);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int GetCountryIDByName(string country)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT CountryID FROM tblCountry WHERE Country = @countryName", conn))
			{
				cmd.Parameters.AddWithValue("@countryName", country);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
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
		public List<Region> GetAllRegions()
		{
			List<Region> regions = new List<Region>();
			string allRegions = "Select * FROM tblRegion";
			using (SqlCommand cmd = new SqlCommand(allRegions, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int regionID = Convert.ToInt32(reader["RegionID"]);
						string regionName = reader["Region"].ToString();
						int countryID = Convert.ToInt32(reader["CountryID"]);
						regions.Add(new Region(regionID, countryID, regionName));
					}
				}
			}
			return regions;
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
		public int GetCityIDByName(string city)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT CityID FROM tblCity WHERE City = @cityName", conn))
			{
				cmd.Parameters.AddWithValue("@cityName", city);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
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
		public List<City> GetAllCities()
		{
			List<City> cities = new List<City>();
			string allCities = "Select * FROM tblCity";
			using (SqlCommand cmd = new SqlCommand(allCities, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int cityID = Convert.ToInt32(reader["CityID"]);
						string cityName = reader["City"].ToString();
						cities.Add(new City(cityID, cityName));
					}
				}
			}
			return cities;
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
		public int GetSuburbIDByName(string suburb)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT SuburbID FROM tblSuburb WHERE Suburb = @suburbName", conn))
			{
				cmd.Parameters.AddWithValue("@suburbName", suburb);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
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
		public List<Suburb> GetAllSuburbs()
		{
			List<Suburb> suburbs = new List<Suburb>();
			string allSuburbs = "Select * FROM tblSuburb";
			using (SqlCommand cmd = new SqlCommand(allSuburbs, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int suburbID = Convert.ToInt32(reader["SuburbID"]);
						int cityID = Convert.ToInt32(reader["CityID"]);
						string suburbName = reader["Suburb"].ToString();
						int zipcode = Convert.ToInt32(reader["Zipcode"]);
						suburbs.Add(new Suburb(suburbID, cityID, suburbName, zipcode));
					}
				}
			}
			return suburbs;
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
		public List<Store> GetAllStores()
		{
			List<Store> stores = new List<Store>();
			string allStores = "Select * FROM tblStore";
			using (SqlCommand cmd = new SqlCommand(allStores, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int storeID = Convert.ToInt32(reader["StoreID"]);
						int suburbID = Convert.ToInt32(reader["SuburbID"]);
						string storeName = reader["Store"].ToString();
						stores.Add(new Store(storeID, suburbID, storeName));
					}
				}
			}
			return stores;
		}
		//CRUD operations for User
		public int UpdateUser(int userID, string username, string password)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblUser SET Username = @username, Password = @password WHERE UserID = @userID", conn))
			{
				cmd.Parameters.AddWithValue("@username", username);
				cmd.Parameters.AddWithValue("@password", password);
				cmd.Parameters.AddWithValue("@userID", userID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertUser(User userTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblUser UserID, FirstName, LastName, Email, Username, Password, RoleID) VALUES (@username, @password, @roleID); SELECT SCOPE_IDENTITY();", conn))
			{
				
				cmd.Parameters.AddWithValue("@username", userTemp.UserName);
				cmd.Parameters.AddWithValue("@firstName", userTemp.FirstName);
				cmd.Parameters.AddWithValue("@lastName", userTemp.LastName);
				cmd.Parameters.AddWithValue("@email", userTemp.Email);
				cmd.Parameters.AddWithValue("@password", userTemp.Password);
				cmd.Parameters.AddWithValue("@roleID", userTemp.roleID);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteUser(string username)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE UserID FROM tblUser WHERE Username = @username;", conn))
			{
				cmd.Parameters.AddWithValue("@username", username);
				return cmd.ExecuteNonQuery();
			}
		}
		public List<User> GetAllUsers()
		{
			List<User> users = new List<User>();
			string allUsers = "Select * FROM tblUser";
			using (SqlCommand cmd = new SqlCommand(allUsers, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int userID = Convert.ToInt32(reader["UserID"]);
						string firstName = reader["FirstName"].ToString();
						string lastName = reader["LastName"].ToString();
						string username = reader["Username"].ToString();
						string email = reader["Email"].ToString();
						int roleID = Convert.ToInt32(reader["RoleID"]);
						string password = reader["Password"].ToString();
						users.Add(new User(userID, firstName, lastName, username, email, roleID, password));
					}
				}
			}
			return users;
		}
		// CRUD operations for category
		public int UpdateCategory(int categoryID, string categoryName)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblCategory SET Category = @categoryName WHERE CategoryID = @categoryID", conn))
			{
				cmd.Parameters.AddWithValue("@categoryName", categoryName);
				cmd.Parameters.AddWithValue("@categoryID", categoryID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertCategory(Category categoryTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblCategory (Category) VALUES (@categoryName); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@categoryName", categoryTemp.CategoryName);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteCategory(string categoryName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblCategory WHERE Category = @categoryName;", conn))
			{
				cmd.Parameters.AddWithValue("@categoryName", categoryName);
				return cmd.ExecuteNonQuery();
			}
		}
		public List<Category> GetAllCategories()
		{
			List<Category> categories = new List<Category>();
			string allCategories = "Select * FROM tblCategory";
			using (SqlCommand cmd = new SqlCommand(allCategories, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int categoryID = Convert.ToInt32(reader["CategoryID"]);
						string categoryName = reader["Category"].ToString();
						categories.Add(new Category(categoryID, categoryName));
					}
				}
			}
			return categories;
		}
		//CRUD for Recipe
		public int UpdateRecipe(int recipeID, string Title, string Method, int CategoryID, int RegionID)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblRecipe SET Title = @Title, Method = @Method, CategoryID = @CategoryID , RegionID = @Region ID WHERE RecipeID = @recipeID", conn))
			{
				cmd.Parameters.AddWithValue("@Title", Title);
				cmd.Parameters.AddWithValue("@Method", Method);
				cmd.Parameters.AddWithValue("@RegionID", RegionID);
				cmd.Parameters.AddWithValue("@RecipeID", recipeID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                return cmd.ExecuteNonQuery();
			}
		}
		public int InsertRecipe(Recipe recipeTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRecipe (Title, Method, CategoryID, UserID, RegionID) VALUES (@Title, @Method, @categoryID, @UserID, @RegionID); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@recipeName", recipeTemp.Title);
				cmd.Parameters.AddWithValue("@description", recipeTemp.Method);
				cmd.Parameters.AddWithValue("@categoryID", recipeTemp.CategoryID);
                cmd.Parameters.AddWithValue("@recipeName", recipeTemp.UserID);
                cmd.Parameters.AddWithValue("@description", recipeTemp.RegionID);
                return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteRecipe(string title)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblRecipe WHERE Title = @title;", conn))
			{
				cmd.Parameters.AddWithValue("@title", title);
				return cmd.ExecuteNonQuery();
			}
		}
		public List<Recipe> GetAllRecipes()
		{
			List<Recipe> recipes = new List<Recipe>();
			string allRecipes = "Select * FROM tblRecipe";
			using (SqlCommand cmd = new SqlCommand(allRecipes, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int recipeID = Convert.ToInt32(reader["RecipeID"]);
						string title = reader["Title"].ToString();
						string method = reader["Method"].ToString();
						int categoryID = Convert.ToInt32(reader["CategoryID"]);
						int userID = Convert.ToInt32(reader["UserID"]);
						int regionID = Convert.ToInt32(reader["RegionID"]);
						recipes.Add(new Recipe(recipeID, title, method, categoryID, userID, regionID));
					}
				}
			}
			return recipes;
		}
		// Get userID by username
		public int GetUserIDByUsername(string username)
		{
			using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM tblUser WHERE UserName = @username", conn))
			{
				cmd.Parameters.AddWithValue("@username", username);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // lambda if statement if userID is not null then convert and return result, if null then return -1
			}
		}
		//get regionID by name
		public int GetRegionIDByName(string regionName)
		{
			using (SqlCommand cmd = new SqlCommand("SELECT RegionID FROM tblRegion WHERE Region = @regionName", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionName);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
			}
		}
		// get categoryID by name
		public int GetCategoryIDByName(string categoryName)
		{
			using (SqlCommand cmd = new SqlCommand("SELECT CategoryID FROM tblCategory WHERE Category = @categoryName", conn))
			{
				cmd.Parameters.AddWithValue("@categoryName", categoryName);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
			}
		}
		// CRUD operations for Ingredients
		public int UpdateIngredient(int ingredientID, string ingredientName)
		{
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblIngredient SET IngredientName = @ingredientName, RecipeID = @recipeID WHERE IngredientID = @ingredientID", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
				cmd.Parameters.AddWithValue("@ingredientID", ingredientID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertIngredient(Ingredient ingredientTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblIngredient (IngredientName, RecipeID) VALUES (@ingredientName, @recipeID); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientTemp.IngredientName);
				cmd.Parameters.AddWithValue("@recipeID", ingredientTemp.IngredientID);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteIngredient(string ingredientName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblIngredient WHERE IngredientName = @ingredientName;", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
				return cmd.ExecuteNonQuery();
			}
		}
		public List<Ingredient> GetAllIngredients()
		{
			List<Ingredient> ingredients = new List<Ingredient>();
			string allIngredients = "Select * FROM tblIngredient";
			using (SqlCommand cmd = new SqlCommand(allIngredients, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int ingredientID = Convert.ToInt32(reader["IngredientID"]);
						string ingredientName = reader["IngredientName"].ToString();
						ingredients.Add(new Ingredient(ingredientID, ingredientName));
					}
				}
			}
			return ingredients;
		}


		public List<User> UsersReport()
        {
			List<User> user = new List<User>();
			string allUsers = "Select * FROM tblUser";
			using (SqlCommand cmd = new SqlCommand(allUsers, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int userID = Convert.ToInt32(reader["UserID"]);
						string FirstName = Convert.ToString(reader["FirstName"]);
						string LastName = Convert.ToString(reader["LastName"]);
						string UserName = Convert.ToString(reader["UserName"]);
						string Email = Convert.ToString(reader["Email"]);
						int roleID = Convert.ToInt32(reader["RoleID"]);
						// Assuming the Password field is not needed for this query

						user.Add(new User(userID, FirstName, LastName, UserName, Email, roleID, null));
					}
				}
			}
			return user;
		}
		public List<City> CityReport()
		{
			List<City> cities = new List<City>();
			string allCities = "Select * FROM tblCity";
			using (SqlCommand cmd = new SqlCommand(allCities, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int cityID = Convert.ToInt32(reader["CityID"]);
						string cityName = reader["City"].ToString();
						cities.Add(new City(cityID, cityName));
					}
				}
			}
			return cities;
		}
		public List<Country> CountryReport()
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
		public List<Recipe> RecipeReport()
		{
			List<Recipe> recipes = new List<Recipe>();
			string allRecipes = "Select Title, Method FROM tblRecipe";
			using (SqlCommand cmd = new SqlCommand(allRecipes, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int recipeID = Convert.ToInt32(reader["RecipeID"]);
						string title = reader["Title"].ToString();
						string method = reader["Method"].ToString();
						int categoryID = Convert.ToInt32(reader["CategoryID"]);
						int userID = Convert.ToInt32(reader["UserID"]);
						int regionID = Convert.ToInt32(reader["RegionID"]);
						recipes.Add(new Recipe(recipeID, title, method, categoryID, userID, regionID));
					}
				}
			}
			return recipes;
		}
		public List<Suburb> SuburbReport()
		{
			List<Suburb> suburbs = new List<Suburb>();
			string allSuburbs = "SELECT * FROM tblSuburb";
			using (SqlCommand cmd = new SqlCommand(allSuburbs, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int suburbID = Convert.ToInt32(reader["SuburbID"]);
						int cityID = Convert.ToInt32(reader["CityID"]);
						string suburbName = reader["Suburb"].ToString();
						int zipcode = Convert.ToInt32(reader["Zipcode"]);
						suburbs.Add(new Suburb(suburbID, cityID, suburbName, zipcode));
					}
				}
			}
			return suburbs;
		}
		public bool CheckIfUserExists(string UserName)
		{
			SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE UserName = @UserName", conn);
			cmd.Parameters.AddWithValue("@UserName", UserName);
			int count = (int)cmd.ExecuteScalar();
			if (count > 0) 
			{
				return true; // User exists
			}
			else
			{
				return false; // User does not exist
			}

		}
		public bool CheckPassword(string UserName, string Password)
		{
			SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblUser WHERE UserName = @UserName AND Password = @Password", conn);
			cmd.Parameters.AddWithValue("@UserName", UserName);
			cmd.Parameters.AddWithValue("@Password", Password);
			int count = (int)cmd.ExecuteScalar();
			// If count is greater than 0, the user exists with the provided password
			if (count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public string CheckUserRole(string UserName) 
		{ 
		SqlCommand cmd = new SqlCommand("SELECT Role FROM tblUser, tblRole WHERE tblUser.RoleID = tblRole.RoleID AND UserName = @UserName", conn);
			cmd.Parameters.AddWithValue("@UserName", UserName);
			object result = cmd.ExecuteScalar();
			if (result != null)
			{
				return result.ToString(); // Return the role as a string
			}
			else
			{
				return null; // No role found for the user
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

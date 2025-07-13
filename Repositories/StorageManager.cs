using System;
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
            using (SqlCommand cmd = new SqlCommand($"DELETE CountryID FROM tblCountry WHERE Country = @countryName;", conn))
            {
                cmd.Parameters.AddWithValue("@countryName", countryName);
                return cmd.ExecuteNonQuery();
            }
        }
		public int GetCountryID(string Country)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT CountryID FROM tblCountry WHERE Country = @Country", conn))
			{
				cmd.Parameters.AddWithValue("@Country", Country);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
			}
		}
		public string ValidCountry(string countryName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Country FROM tblCountry WHERE Country = @countryName", conn))
			{
				cmd.Parameters.AddWithValue("@countryName", countryName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
			using (SqlCommand cmd = new SqlCommand($"DELETE RoleID FROM tblRole WHERE Role = @role;", conn))
			{
				cmd.Parameters.AddWithValue("@role", role);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidRole(string roleName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Role FROM tblRole WHERE Role = @roleName", conn))
			{
				cmd.Parameters.AddWithValue("@roleName", roleName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblRegion SET Area = @regionName WHERE RegionID = @regionID", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionName);
				cmd.Parameters.AddWithValue("@regionID", regionID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertRegion(Region regionTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRegion (Area, CountryID) VALUES (@regionName), (@countryID); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionTemp.Area);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteRegion(string regionName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE RegionID FROM tblRegion WHERE Area = @regionName;", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionName);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidRegion(string regionName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Region FROM tblRegion WHERE Region = @regionName", conn))
			{
				cmd.Parameters.AddWithValue("@regionName", regionName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
						string regionName = reader["Area"].ToString();
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
			using (SqlCommand cmd = new SqlCommand($"DELETE CityID FROM tblCity WHERE City = @cityName;", conn))
			{
				cmd.Parameters.AddWithValue("@cityName", cityName);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidCity(string cityName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT City FROM tblCity WHERE City = @cityName", conn))
			{
				cmd.Parameters.AddWithValue("@cityName", cityName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
			using (SqlCommand cmd = new SqlCommand($"DELETE SuburbID FROM tblSuburb WHERE Suburb = @suburbName;", conn))
			{
				cmd.Parameters.AddWithValue("@suburbName", suburbName);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidSuburb(string suburbName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Suburb FROM tblSuburb WHERE Suburb = @suburbName", conn))
			{
				cmd.Parameters.AddWithValue("@suburbName", suburbName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
			using (SqlCommand cmd = new SqlCommand($"DELETE StoreID FROM tblStore WHERE Store = @storeName;", conn))
			{
				cmd.Parameters.AddWithValue("@storeName", storeName);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidStore(string storeName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Store FROM tblStore WHERE Store = @storeName", conn))
			{
				cmd.Parameters.AddWithValue("@storeName", storeName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
		public string ValidUsername(string username)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Username FROM tblUser WHERE Username = @username", conn))
			{
				cmd.Parameters.AddWithValue("@username", username);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
			using (SqlCommand cmd = new SqlCommand($"DELETE CategoryID FROM tblCategory WHERE Category = @categoryName;", conn))
			{
				cmd.Parameters.AddWithValue("@categoryName", categoryName);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidCategory(string categoryName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Category FROM tblCategory WHERE Category = @categoryName", conn))
			{
				cmd.Parameters.AddWithValue("@categoryName", categoryName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
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
			using (SqlCommand cmd = new SqlCommand($"DELETE RecipeID FROM tblRecipe WHERE Title = @title;", conn))
			{
				cmd.Parameters.AddWithValue("@title", title);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidRecipe(string title)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Title FROM tblRecipe WHERE Title = @title", conn))
			{
				cmd.Parameters.AddWithValue("@title", title);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
			}
		}
		public int GetRecipeIDByTitle(string title)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT RecipeID FROM tblRecipe WHERE Title = @title", conn))
			{
				cmd.Parameters.AddWithValue("@title", title);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
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
			using (SqlCommand cmd = new SqlCommand($"UPDATE tblIngredient SET Ingredient = @ingredientName, RecipeID = @recipeID WHERE IngredientID = @ingredientID", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
				cmd.Parameters.AddWithValue("@ingredientID", ingredientID);
				return cmd.ExecuteNonQuery();
			}
		}
		public int InsertIngredient(Ingredient ingredientTemp)
		{
			using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblIngredient (Ingredient, RecipeID) VALUES (@ingredientName, @recipeID); SELECT SCOPE_IDENTITY();", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientTemp.IngredientName);
				cmd.Parameters.AddWithValue("@recipeID", ingredientTemp.IngredientID);
				return Convert.ToInt32(cmd.ExecuteScalar());
			}
		}
		public int DeleteIngredient(string ingredientName)
		{
			using (SqlCommand cmd = new SqlCommand($"DELETE IngredientID FROM tblIngredient WHERE Ingredient = @ingredientName;", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
				return cmd.ExecuteNonQuery();
			}
		}
		public string ValidIngredient(string ingredientName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT Ingredient FROM tblIngredient WHERE Ingredient = @ingredientName", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
				object result = cmd.ExecuteScalar();
				return result != null ? result.ToString() : null; // Return null if not found
			}
		}
		public int GetIngredientIDByName(string ingredientName)
		{
			using (SqlCommand cmd = new SqlCommand($"SELECT IngredientID FROM tblIngredient WHERE Ingredient = @ingredientName", conn))
			{
				cmd.Parameters.AddWithValue("@ingredientName", ingredientName);
				object result = cmd.ExecuteScalar();
				return result != null ? Convert.ToInt32(result) : -1; // Return -1 if not found
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
		// REPORTS SIMPLE
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
		// REPORTS COMPLEX
		public List<ComplexQry1> IngredientsInRecipe()
		{
			List<ComplexQry1> ingredientsInRecipe = new List<ComplexQry1>();
			string query = "SELECT r.Title ,r.Method , STRING_AGG (i.Ingredient, ', ') AS Ingredients_List\r\nFROM tblRecipe r, tblRecipeIngredientBridge rib, tblIngredient i \r\nWHERE r.RecipeID = rib.RecipeID AND rib.IngredientID = i.IngredientID\r\nGROUP BY Method, Title\r\nORDER BY Title DESC;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string ingredient = reader["Ingredient"].ToString();
						string title = reader["Title"].ToString();
						string Method = reader["Method"].ToString();
						ingredientsInRecipe.Add(new ComplexQry1(title, Method, ingredient));
					}
				}
			}
			return ingredientsInRecipe;
		}
		public List<ComplexQry2> IngredientsPerStore()
		{
			List<ComplexQry2> ingredientsPerStore = new List<ComplexQry2>();
			string query = "SELECT s.StoreID AS StoreID, s.Store , COUNT(DISTINCT isb.IngredientID) AS NumberOfIngredients\r\nFROM tblStore s, tblRecipe r, tblIngredientStoreBridge isb, tblIngredient i\r\nWHERE s.StoreID = isb.StoreID AND  isb.IngredientID = i.IngredientID  \r\nGROUP BY s.StoreID, s.Store\r\nORDER BY NumberOfIngredients DESC;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int storeID = Convert.ToInt32(reader["StoreID"]);
						string storeName = reader["Store"].ToString();
						int ingredientID = Convert.ToInt32(reader["IngredientID"]);
						ingredientsPerStore.Add(new ComplexQry2(storeID, storeName, ingredientID));
					}
				}
			}
			return ingredientsPerStore;
		}
		public List<ComplexQry3> CitiesWithMostStores()
		{
			List<ComplexQry3> citiesWithMostStores = new List<ComplexQry3>();
			string query = "SELECT TOP 10 c.City, COUNT(st.Store) AS Number_of_Stores \r\nFROM tblSuburb su, tblCity c, tblStore st\r\nWHERE c.CityID = su.CityID AND su.SuburbID = st.SuburbID\r\nGROUP BY c.City\r\nORDER BY Number_of_Stores DESC;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string city = reader["City"].ToString();
						string store = reader["Store"].ToString();
						citiesWithMostStores.Add(new ComplexQry3(city, store));
					}
				}
			}
			return citiesWithMostStores;
		}
		public List<ComplexQry4> MostIngredientsByStore()
		{
			List<ComplexQry4> mostIngredientsByStore = new List<ComplexQry4>();
			string query = "SELECT s.Store, COUNT(i.Ingredient) AS Total_Ingredients, su.Suburb, c.City\r\nFROM tblStore s, tblIngredient i, tblSuburb su, tblIngredientStoreBridge isb, tblCity c\r\nWHERE s.StoreID = isb.StoreID \r\nAND i.IngredientID = isb.IngredientID\r\nAND su.SuburbID = s.SuburbID\r\nAND su.CityID = c.CityID\r\nGROUP BY City, Store, Suburb\r\nORDER BY Total_Ingredients DESC;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string store = reader["Store"].ToString();
						string ingredient = reader["Ingredient"].ToString();
						string suburb = reader["Suburb"].ToString();
						string city = reader["City"].ToString();
						mostIngredientsByStore.Add(new ComplexQry4(store, ingredient, suburb, city));
					}
				}
			}
			return mostIngredientsByStore;
		}
		public List<ComplexQry5> NumOfRecipePerRegion()

		{
			List<ComplexQry5> numOfRecipePerRegion = new List<ComplexQry5>();
			string query = "SELECT  reg.Area AS Region, COUNT(DISTINCT r.RecipeID) AS TotalRecipes, COUNT(DISTINCT i.IngredientID) AS TotalUniqueIngredients\r\nFROM tblRecipe r, tblRecipeIngredientBridge rib, tblIngredient i, tblRegion reg\r\nWHERE r.RecipeID = rib.RecipeID AND rib.IngredientID = i.IngredientID AND r.RegionID = reg.RegionID\r\nGROUP BY  reg.Area\r\nORDER BY TotalRecipes DESC;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						int recipeID = Convert.ToInt32(reader["RecipeID"]);
						string area = reader["Area"].ToString();
						int IngredientID = Convert.ToInt32(reader["IngredientID"]);
						numOfRecipePerRegion.Add(new ComplexQry5(area, recipeID, IngredientID));
					}
				}
			}
			return numOfRecipePerRegion;
		}
		// REPORTS ADVANCED
		public List<AdvancedQry1> ChefRecipeRegion()
		{
			List<AdvancedQry1> chefRecipeRegion = new List<AdvancedQry1>();
			string query = "SELECT c.FirstName , c.LastName , r.Title, reg.Area AS Region\r\nFROM  tblRecipe r, tblChef c, tblRegion reg\r\nWHERE r.ChefID = c.ChefID AND r.RegionID = reg.RegionID;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string firstName = reader["FirstName"].ToString();
						string lastName = reader["LastName"].ToString();
						string title = reader["Title"].ToString();
						string area = reader["Area"].ToString();
						chefRecipeRegion.Add(new AdvancedQry1(firstName, lastName, title, area));
					}
				}
			}
			return chefRecipeRegion;
		}
		public List<AdvancedQry2> RecipeCategoryIngredients()
		{
			List<AdvancedQry2> recipeCategoryIngredients = new List<AdvancedQry2>();
			string query = "SELECT r.Title ,c.Category, STRING_AGG(i.Ingredient, ', ') AS Ingredients\r\nFROM tblRecipe r, tblCategory c, tblRecipeIngredientBridge rib, tblIngredient i\r\nWHERE r.CategoryID = c.CategoryID AND r.RecipeID = rib.RecipeID AND rib.IngredientID = i.IngredientID\r\nGROUP BY  r.Title, c.Category;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string title = reader["Title"].ToString();
						string category = reader["Category"].ToString();
						string ingredientsList = reader["Ingredient"].ToString();
						recipeCategoryIngredients.Add(new AdvancedQry2(title, category, ingredientsList));
					}
				}
			}
			return recipeCategoryIngredients;
		}
		public List<AdvancedQry3> RecipeRegionCountry()
		{
			List<AdvancedQry3> recipeRegionCountry = new List<AdvancedQry3>();
			string query = "SELECT r.Area AS Region, re.Title AS Recipe, c.Country\r\nFROM tblRegion r, tblRecipe re, tblCountry c\r\nWHERE r.RegionID = re.RegionID\r\nAND r.CountryID = c.CountryID;";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string title = reader["Title"].ToString();
						string area = reader["Area"].ToString();
						string country = reader["Country"].ToString();
						recipeRegionCountry.Add(new AdvancedQry3(area, title, country));
					}
				}
			}
			return recipeRegionCountry;
		}
		public List<AdvancedQry4> RecipesUseGarlic()
		{
			List<AdvancedQry4> recipesUseGarlic = new List<AdvancedQry4>();
			string query = "SELECT r.Title, r.Method, Ingredient\r\nFROM tblRecipe r, tblRecipeIngredientBridge rib, tblIngredient i\r\nWHERE r.RecipeID = rib.RecipeID AND rib.IngredientID = i.IngredientID\r\nAND i.Ingredient = 'Garlic';";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string title = reader["Title"].ToString();
						string method = reader["Method"].ToString();
						string ingredient = reader["Ingredient"].ToString();
						recipesUseGarlic.Add(new AdvancedQry4(title, method, ingredient));
					}
				}
			}
			return recipesUseGarlic;
		}
		public List<AdvancedQry5> StoreContainChicken()
		{
			List<AdvancedQry5> storeContainChicken = new List<AdvancedQry5>();
			string query = "SELECT s.Store, i.Ingredient\r\nFROM tblStore s, tblIngredient i, tblIngredientStoreBridge isb\r\nWHERE s.StoreID = isb.StoreID AND isb.IngredientID = i.IngredientID AND Ingredient = 'Chicken Breast';";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string store = reader["Store"].ToString();
						string ingredient = reader["Ingredient"].ToString();
						storeContainChicken.Add(new AdvancedQry5(store, ingredient));
					}
				}
			}
			return storeContainChicken;
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

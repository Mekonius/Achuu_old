using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using System.Text.Json;
using System.Threading.Tasks;

namespace Achuu.Models.Services
{
    public class ProductService
    {
        private readonly AchuuContext _context;

        public ProductService(AchuuContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products!
                .Include(p => p.Ingredients)
                .ToListAsync();

            return products;
        }



        public void getJsonFeed()
        {


            var file = File.ReadAllText("models/json.json");
            var products = new List<Product>();

            var jsonDocument = JsonDocument.Parse(file);
            foreach (var jsonElement in jsonDocument.RootElement.EnumerateArray())
            {
                var product = new Product
                {
                    // Remove the explicit value for ProductID
                    // ProductID = jsonElement.GetProperty("id").GetInt32(),

                    Name = jsonElement.GetProperty("name").GetString(),
                    Description = jsonElement.GetProperty("description").GetString(),
                    Price = jsonElement.GetProperty("price").GetString(),
                    Image_link = jsonElement.GetProperty("image_link").GetString(),
                    Category = jsonElement.GetProperty("category").GetString(),
                    ProductType = jsonElement.GetProperty("product_type").GetString(),
                    CreatedAt = jsonElement.GetProperty("created_at").GetDateTime(),
                    UpdatedAt = jsonElement.GetProperty("updated_at").GetDateTime(),
                    ProductApiUrl = jsonElement.GetProperty("product_api_url").GetString(),
                    ApiFeatured_image = jsonElement.GetProperty("api_featured_image").GetString(),
                    Brand = jsonElement.GetProperty("brand").GetString(),
                };

                var ingredients = jsonElement.GetProperty("description").GetString();

                // search for INGREDIENTS: in the description
                if (ingredients != null)
                {
                    if (ingredients.Contains("Ingredients:"))
                    {
                        // split the string into an array
                        var splitIngredients = ingredients.Split("Ingredients:");
                        // get the second element in the array
                        var ingredientList = splitIngredients[1];
                        // split the string into an array
                        var splitIngredientList = ingredientList.Split(",");
                        // stop the reading the line after new line'
                        splitIngredientList[splitIngredientList.Length - 1] = splitIngredientList[splitIngredientList.Length - 1].Split("\n")[0];

                        foreach (var ingredient in splitIngredientList)
                        {
                            // add each ingredient to the ingredients list of the product, and set the product id
                           
                 
                                _context.Ingredients?.Add(new Ingredient { Name = ingredient, Product = product });
                                
                            
                        }

                        

                    }

                }
                else
                {
                    continue;
                }

                //if the prodct is not already in the database, don't add it
                if (_context.Products.Any(p => p.Name == product.Name))
                {
                    continue;
                }
                else
                {
                    products.Add(product);
                    _context.Products?.Add(product);
                    _context.SaveChanges();

                }




            }


        }


    }
}
using Achuu.Pages.Products;

using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

using System.Drawing.Printing;
using System.Drawing.Text;
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

        //Creeate product 
        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
            {
                  throw new ArgumentNullException(nameof(product));

            }
            else
            {
                _context.Products?.Add(product);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<(List<Product> products, int totalItems)> DeleteProductAsync(int productId, int pageNumber, int pageSize)
        {
            var product = await _context.Products!.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            var (resultProducts, totalItems, _) = await GetProductsAsync(pageNumber, pageSize);
            return (resultProducts, totalItems); // Return the updated list of products and total items after deletion
        }



        public async Task<(List<Product> products, int totalItems, int pageNumber)> GetProductsAsync(int pageNumber, int pageSize)
        {
            
            var productsQuery = _context.Products!.Include(p => p.Ingredients);

            // Execute the first operation sequentially
            var totalItems = await productsQuery.CountAsync();

            // Debug information
            Console.WriteLine($"Total products: {totalItems}");
            Console.WriteLine($"Requested page number: {pageNumber}");
            Console.WriteLine($"Requested page size: {pageSize}");

            // Execute the second operation sequentially
            var products = await productsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalItems, pageNumber);
        }



        //public void GetJsonFeed()
        //{


        //    var file = File.ReadAllText("models/json.json");
        //    var products = new List<Product>();

        //    var jsonDocument = JsonDocument.Parse(file);
        //    foreach (var jsonElement in jsonDocument.RootElement.EnumerateArray())
        //    {
        //        var product = new Product
        //        {
        //            // Remove the explicit value for ProductID
        //            // ProductID = jsonElement.GetProperty("id").GetInt32(),


        //            // Add the explicit value for ProductID
        //            Name = jsonElement.GetProperty("name").GetString(),
        //            Description = jsonElement.GetProperty("description").GetString(),
        //            Price = jsonElement.GetProperty("price").GetString(),
        //            Image_link = jsonElement.GetProperty("image_link").GetString(),
        //            Category = jsonElement.GetProperty("category").GetString(),
        //            ProductType = jsonElement.GetProperty("product_type").GetString(),
        //            CreatedAt = jsonElement.GetProperty("created_at").GetDateTime(),
        //            UpdatedAt = jsonElement.GetProperty("updated_at").GetDateTime(),
        //            ProductApiUrl = jsonElement.GetProperty("product_api_url").GetString(),
        //            ApiFeatured_image = jsonElement.GetProperty("api_featured_image").GetString(),
        //            Brand = jsonElement.GetProperty("brand").GetString(),
        //        };

        //        var ingredients = jsonElement.GetProperty("description").GetString();

        //        // search for INGREDIENTS: in the description
        //        if (ingredients != null)
        //        {
        //            if (ingredients.Contains("Ingredients:"))
        //            {
        //                // split the string into an array
        //                var splitIngredients = ingredients.Split("Ingredients:");
        //                // get the second element in the array
        //                var ingredientList = splitIngredients[1];
        //                // split the string into an array
        //                var splitIngredientList = ingredientList.Split(",");
        //                // stop the reading the line after new line'
        //                splitIngredientList[^1] = splitIngredientList[^1].Split("\n")[0];

        //                foreach (var ingredient in splitIngredientList)
        //                {
        //                    // add each ingredient to the ingredients list of the product, and set the product id


        //                    _context.Ingredients?.Add(new Ingredient { Name = ingredient, Product = product });


        //                }



        //            }

        //        }
        //        else
        //        {
        //            continue;
        //        }

        //        //if the prodct is not already in the database, don't add it
        //        if (product != null && _context.Products!.Any(p => p.Name == product.Name))
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            products.Add(product!);
        //            _context.Products?.Add(product!);
        //            _context.SaveChanges();

        //        }




        //    }


        //}


    }
}
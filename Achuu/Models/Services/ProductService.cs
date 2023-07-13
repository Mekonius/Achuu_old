using Microsoft.EntityFrameworkCore;

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
            var products = await _context.Products
                .Include(p => p.Ingredients)
                .ToListAsync();

            return products;
        }

    }
}
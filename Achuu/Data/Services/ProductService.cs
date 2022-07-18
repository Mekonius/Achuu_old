namespace Achuu.Data.Services
{
    public class ProductService
    {
        public Task<Product[]> GetProductsAsync(DateTime startDate)
        {
            //return Task.FromResult(Enumerable.Range(1, 5).Select(Index => new Product
            //{
            //    ProductID = Index,
            //    Name = "Product " + Index,
            //    Description = "Description " + Index,
            //    Warning = "Warning " + Index,
            //    GalleryID = $"{Index}",
            //    Ingredients = new List<Ingredient>
            //    {
            //        new Ingredient
            //        {
            //            Id = Index,
            //            Name = "Ingredient " + Index,
            //            IsAllergic = false,
            //        }
            //    }
            //}).ToArray());
        }
    }
}
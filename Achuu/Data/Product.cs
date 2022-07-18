namespace Achuu.Data
{
    public class Product
    {
        //Creating a product
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? GalleryID { get; set; }
        public string? Description { get; set; }
        public string? Warning { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

    }
}
namespace Achuu.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsAllergic { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }



        //To be continued in v2 
        //public string? Description { get; set; }
    }
}
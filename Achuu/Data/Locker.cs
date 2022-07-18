namespace Achuu.Data
{
    public class Locker
    {
        public int LockerID { get; set; }
        public int UserID { get; set; }
        public List<Product>? Products { get; set; }
        
    }
}

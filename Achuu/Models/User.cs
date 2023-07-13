namespace Achuu.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public virtual Locker? Locker { get; set; }
        
    }
}

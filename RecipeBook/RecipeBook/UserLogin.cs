using System.ComponentModel.DataAnnotations;

namespace RecipeBook
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public bool TermsAccepted { get; set; }
    }
}

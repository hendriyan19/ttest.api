using System.ComponentModel.DataAnnotations;

namespace test.api.Models
{
    public class User
    {

        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } = string.Empty;

    }
}

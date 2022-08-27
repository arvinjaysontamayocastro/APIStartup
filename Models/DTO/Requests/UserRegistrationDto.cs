// For simplicity we are only adding these 3 feilds we can change it and make it as complex as we need
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.DTOs.Requests
{
    public class UserRegistrationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

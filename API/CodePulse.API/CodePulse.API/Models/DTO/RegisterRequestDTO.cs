using System.ComponentModel.DataAnnotations;

namespace CodePulse.API.Models.DTO
{
    public class RegisterRequestDTO  // this is DTO , wheever we get inputs or send inputs from user or to user we send DTO's so for login page we require two things , email and password , so created this DTO
    {

        public string Email { get; set; }

        public string  Password { get; set; }
    }
}

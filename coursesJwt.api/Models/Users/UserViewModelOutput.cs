using System.ComponentModel.DataAnnotations;

namespace coursesJwt.api.Models.Users
{
    public class UserViewModelOutput
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace coursesJwt.api.Models.Users
{
    public class LoginFieldsViewModelOutput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Password { get; set; }
    }
}

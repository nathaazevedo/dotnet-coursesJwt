using coursesJwt.api.Models.Users;

namespace coursesJwt.api.Configurations
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserViewModelOutput userViewModelOutPut);
    }
}

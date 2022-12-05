using coursesJwt.api.Business.Entities;
using coursesJwt.api.Business.Repositories;
using coursesJwt.api.Filters;
using coursesJwt.api.Models;
using coursesJwt.api.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace coursesJwt.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly Configurations.IAuthenticationService _authenticationService;

        public UserController(
            IUserRepository userRepository,
            Configurations.IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }
        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuário e token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginFieldsViewModelOutput))]
        [SwaggerResponse(statusCode: 400, description: "Sucesso ao autenticar", Type = typeof(ValidateFieldsViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [CustomValidateModelState]
        public IActionResult Login(LoginFieldsViewModelOutput loginViewModelInput)
        {
            var user = _userRepository.GetUser(loginViewModelInput.Login);

            if (user == null)
            {
                return BadRequest("Houve um erro ao tentar acessar");
            }

            var userViewModelOutput = new UserViewModelOutput()
            {
                Id = user.Id,
                Login = loginViewModelInput.Login,
                Email = user.Email,
            };

            var token = _authenticationService.GenerateToken(userViewModelOutput);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput,
            });
        }

        /// <summary>
        /// Este serviço permite cadastrar um usuário não existente.
        /// </summary>
        /// <param name="registerViewModelInput">View model do registro</param>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginFieldsViewModelOutput))]
        [SwaggerResponse(statusCode: 400, description: "Sucesso ao autenticar", Type = typeof(ValidateFieldsViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("registrar")]
        [CustomValidateModelState]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            var user = new User();
            user.Login = registerViewModelInput.Login;
            user.Password = registerViewModelInput.Password;
            user.Email = registerViewModelInput.Email;

            _userRepository.Add(user);
            _userRepository.Commit();

            return Created("", registerViewModelInput);
        }
    }
}

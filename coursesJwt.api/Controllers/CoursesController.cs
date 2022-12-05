using coursesJwt.api.Business.Entities;
using coursesJwt.api.Business.Repositories;
using coursesJwt.api.Infrastructure.Repositories;
using coursesJwt.api.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace coursesJwt.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos para o usuário.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter os cursos")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = int.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            var cursos = _courseRepository.GetCourseByUser(userId)
                .Select(x => new CourseViewModelOutput()
            {
                Name = x.Name,
                Description = x.Descripton,
                UserId = x.UserId,
            });

            return Ok(cursos);
        }

        /// <summary>
        /// Este serviço permite cadastrar um curso para o usuário autenticado.
        /// </summary>
        /// <param name="courseViewModelInput">View model do curso</param>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            Course course = new Course();
            course.Id = courseViewModelInput.Id;
            course.Name = courseViewModelInput.Name;
            course.Descripton = courseViewModelInput.Description;
            var userId = int.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            course.UserId = userId;

            _courseRepository.Add(course);
            _courseRepository.Commit();

            return Created("", courseViewModelInput);
        }
    }
}

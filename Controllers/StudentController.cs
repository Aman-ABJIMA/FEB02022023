using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Repository;
using Response;
using Services.Infrastructure.Handlers.Interface;
using Student_Model;


namespace WebAPI.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentHandler _studentHandler;

        public StudentController(ILogger<StudentController> logger, IStudentHandler studentHandler)
        {
            _logger = logger;
            _studentHandler = studentHandler;
        }
        [HttpPost]
        [Route("[Controller]Add")]
        public async Task<responseWrapper<bool>> Add(Student student)
        {
            var response = new responseWrapper<bool>();
            try
            {
                var result = await _studentHandler.HandleStudentAddAsync(student);
                response.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Student/CreateStudent");
                response.Set(ex);
            }
            return response;

        }

        [HttpGet]
        [Route("[Controller]GetAll")]
        public async Task<responseWrapper<List<Student>>> GetAll()
        {
            var respo = new responseWrapper<List<Student>>();
            try
            {
                var result = await _studentHandler.HandleStudentGetAll();
                respo.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Student/GetAll");
                respo.Set(ex);
            }
            return respo;

        }

        [HttpGet]
        [Route("[Controller]GetById/{id}")]
        public async Task<responseWrapper<Student>> GetByID(int id)
        {
            var response = new responseWrapper<Student>();
            try
            {
                var result = await _studentHandler.HandleStudentGetById(id);
                response.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Student/GetById:data .{id}");
                response.Set(ex);
            }
            return response;


        }

        [HttpPut]
        [Route("[Controller]Update/{id}")]
        public async Task<responseWrapper<bool>> Update(int id, Student studentModel)
        {
            var response = new responseWrapper<bool>();
            try
            {
                var result = await _studentHandler.HandleStudentUpdateAsync(id, studentModel);
                response.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Student/updateStudent");
                response.Set(ex);
            }

            return response;
        }
        [HttpDelete]
        [Route("[Controller]Delete")]
        public async Task<responseWrapper<bool>> Delete(int id)
        {
            var response = new responseWrapper<bool>();
            try
            {
                var result = await _studentHandler.HandleStudentDeleteAsync(id);
                response.Set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "student/deleteStudent");
                response.Set(ex);
            }
            return response;
        }

    }
}

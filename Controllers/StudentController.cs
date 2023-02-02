using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Repository;
using Student_Data;
using Student_Interface;
using Student_Model;

namespace WebAPI.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
      
        [HttpPost]
        public Task<IActionResult> Add([FromBody]Student student)
        {
           _studentRepository.AddStudentAsync(student);
        
        }
    }
}

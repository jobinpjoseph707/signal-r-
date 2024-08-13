using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using testsignar.Data;
using testsignar.Hubs;
using testsignar.Models;
using Microsoft.EntityFrameworkCore;


namespace testsignar.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;
        private readonly IHubContext<StudentHub> _hubContext;

        public StudentController(StudentDbContext context, IHubContext<StudentHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            int studentCount = await _context.Students.CountAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveStudentCountUpdate", studentCount);

            return Ok(student);
        }

        [HttpGet("count")]
        public async Task<int> GetStudentCount()
        {
            return await _context.Students.CountAsync();
        }
    }
}

using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftDeleted.Model;

namespace SoftDeleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        public readonly IRepository _repository;
        public EmployeeController(IRepository  repository)
        {
            _repository = repository;
                
        }
        [HttpPost]
        [Route("Create_New_Employee")]
        public async Task<IActionResult> Create( Employee employee)
        {
            try
            {
                
                return Ok(await _repository.Create(employee));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Transaction creation failed");
            }

        }
    }
}

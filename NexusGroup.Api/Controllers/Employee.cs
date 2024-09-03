using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs;
using NexusGroup.Service.Services.Employees;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee : ControllerBase
    {
        private readonly IEmployeesService _service;
        public Employee(IEmployeesService service)
        {
            _service = service;
        }
        // GET: api/<Employee>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Employee>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Employee>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEmployeeDTO dto)
        {
            var result = await _service.Add(dto);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // PUT api/<Employee>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Employee>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

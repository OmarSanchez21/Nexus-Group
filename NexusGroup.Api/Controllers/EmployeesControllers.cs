using Microsoft.AspNetCore.Mvc;
using NexusGroup.Service.DTOs.Employees;
using NexusGroup.Service.Services.Employees;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesControllers : ControllerBase
    {
        private readonly iEmployeesService service;
        public EmployeesControllers(iEmployeesService services)
        {
            this.service = services;
        }
        // GET: api/<EmployeesControllers>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await service.GetAll();
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // GET api/<EmployeesControllers>/5
        [HttpGet("value/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("The employee not can be 0");
            }
            var result = await this.service.GetValue(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // POST api/<EmployeesControllers>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEmployees add)
        {
            var result = await this.service.Save(add);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // PUT api/<EmployeesControllers>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateEmployees update)
        {
            var result = await this.service.Update(update);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<EmployeesControllers>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.service.Delete(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

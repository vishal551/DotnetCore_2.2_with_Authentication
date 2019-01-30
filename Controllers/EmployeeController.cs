using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthCoreWEBAPI.DTO;
using AuthCoreWEBAPI.Entities;
using AuthCoreWEBAPI.Helpers;
using AuthCoreWEBAPI.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthCoreWEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployee _iemployee;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public EmployeeController(
            IEmployee iemployee,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _iemployee = iemployee;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var employee = _iemployee.GetAllEmployee();
            var employeeDTO = _mapper.Map<IList<EmployeeDTO>>(employee);
            return Ok(employeeDTO);
        }


        // POST api/<controller>
        [HttpPost("addemployee")]
        public IActionResult AddEmployee([FromBody]EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            try
            {
               var employeeObj= _iemployee.AddEmployee(employee);
                if (employeeObj!=null)
                {
                    return Ok(employeeDTO);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<controller>/5
        [HttpPut("updateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody]EmployeeDTO value)
        {
            var employee = _mapper.Map<Employee>(value);
            try
            {
                var objEmployee = _iemployee.UpdateEmployee(employee);
                if (objEmployee != null)
                {
                    return Ok(objEmployee);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("deleteEmployee/{id}")]
        public bool Delete(int id)
        {
           return _iemployee.DeleteEmployee(id);
        }
    }
}

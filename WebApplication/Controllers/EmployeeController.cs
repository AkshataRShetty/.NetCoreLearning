using WebApplication.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Webapplication.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        public EmployeeController(IEmployeeRepository employees)
        {
            Employees = employees;
        }

        public IEmployeeRepository Employees { get; set; }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return Employees.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = Employees.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            Employees.Add(item);
            return CreatedAtRoute("Akshata", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Employee item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var emp = Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            emp.FirstName = item.FirstName;
            emp.LastName = item.LastName;
            emp.PhoneNumber = item.PhoneNumber;
            emp.Email = item.Email;


            Employees.Update(emp);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var emp = Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            Employees.Remove(id);
            return new NoContentResult();
        }
    }
}
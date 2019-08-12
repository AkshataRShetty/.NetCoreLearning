using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee Find(long id)
        {
            return _context.Employees.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Employees.First(t => t.Id == id);
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    }
}
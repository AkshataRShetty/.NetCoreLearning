using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
        Employee Find(long key);
        void Remove(long key);
        void Update(Employee employee);
    }
}
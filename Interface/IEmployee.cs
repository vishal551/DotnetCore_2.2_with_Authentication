using AuthCoreWEBAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCoreWEBAPI.Interface
{
    public interface IEmployee
    {
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}

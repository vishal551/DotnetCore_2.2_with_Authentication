using AuthCoreWEBAPI.Entities;
using AuthCoreWEBAPI.Helpers;
using AuthCoreWEBAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCoreWEBAPI.Services
{
    public class EmployeeService:IEmployee
    {
        private DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
               return _context.Employees;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                var objEmp = _context.Employees.Find(employee.Id);
                if (objEmp != null)
                {
                    objEmp.Name = employee.Name;
                    objEmp.ID_City = employee.Id;
                    objEmp.Mobile = employee.Mobile;
                    objEmp.Gender = employee.Gender;
                }
                _context.Employees.Update(objEmp);
                _context.SaveChanges();
                return objEmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                var obemp = _context.Employees.Find(id);
                if (obemp != null)
                {
                    _context.Employees.Remove(obemp);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}

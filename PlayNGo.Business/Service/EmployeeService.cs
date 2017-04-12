using PlayNGo.Business.Interface;
using PlayNGo.Core.Entity;
using PlayNGo.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGo.Business.Service
{
    public class EmployeeService :IEmployeeService
    {
        private ICoreRepository<Employee> _employeeRepository;

        public EmployeeService(ICoreRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll().OrderBy(m => m.LastName).ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.SearchFor(a => a.Id == id).FirstOrDefault();
        }

        public void UpdateEmployee(Employee employee)
        {
            var emp = _employeeRepository.SearchFor(a => a.Id == employee.Id).FirstOrDefault();
            _employeeRepository.Update(employee, s => s.Id == employee.Id);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(a => a.Id == id);
        }

        public Employee AddEmployee(Employee employee)
        {
            var newEmployee = _employeeRepository.Insert(employee);
            return newEmployee;
        }

    }
}

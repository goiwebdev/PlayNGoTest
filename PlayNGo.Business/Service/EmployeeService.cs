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

    }
}

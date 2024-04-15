using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeDTO>? EmployeeList()
        {
            List<Employee> employees = _employeeRepository.GetAll()
                .Include(e => e.DaysOff)
                .Include(e => e.Position)
                .ToList();

            List<EmployeeDTO> employeeDTOs = employees
                .Select(employee => employee.MapEmployeeToEmployeeDto())
                .ToList();

            return employeeDTOs;
        }
    }
}

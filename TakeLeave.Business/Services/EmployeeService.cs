using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
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

            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            foreach (Employee employee in employees)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();

                employeeDTO.Id = employee.Id;
                employeeDTO.FirstName = employee.FirstName;
                employeeDTO.LastName = employee.LastName;
                employeeDTO.EmploymentStartDate = employee.EmploymentStartDate;
                employeeDTO.EmploymentEndDate = employee.EmploymentEndDate;

                employeeDTO.DaysOff.Vacation = employee.DaysOff.Vacation;
                employeeDTO.DaysOff.Paid = employee.DaysOff.Paid;
                employeeDTO.DaysOff.Unpaid = employee.DaysOff.Unpaid;
                employeeDTO.DaysOff.SickLeave = employee.DaysOff.SickLeave;

                employeeDTO.Position.Title = employee.Position.Title;
                employeeDTO.Position.SeniorityLevel = Enum.GetName(typeof(SeniorityLevel), employee.Position.SeniorityLevel);

                employeeDTOs.Add(employeeDTO);
            }

            return employeeDTOs;
        }
    }
}

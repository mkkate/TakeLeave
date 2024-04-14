using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UserService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public UserDTO GetUserDetails(int id)
        {
            UserDTO userDto = new UserDTO();

            Employee? employee = _employeeRepository
                .GetByCondition(e => e.Id.Equals(id))
                .Include(e => e.DaysOff)
                .Include(e => e.Position)
                .FirstOrDefault();

            if (employee != null)
            {
                userDto.FirstName = employee.FirstName;
                userDto.LastName = employee.LastName;
                userDto.Address = employee.Address;
                userDto.EmploymentStartDate = DateOnly.FromDateTime(employee.EmploymentStartDate);
                userDto.EmploymentEndDate = DateOnly.FromDateTime((DateTime)employee.EmploymentEndDate);

                userDto.DaysOff.Vacation = employee.DaysOff.Vacation;
                userDto.DaysOff.Paid = employee.DaysOff.Paid;
                userDto.DaysOff.Unpaid = employee.DaysOff.Unpaid;
                userDto.DaysOff.SickLeave = employee.DaysOff.SickLeave;

                userDto.Position.Title = employee.Position.Title;
                userDto.Position.Description = employee.Position.Description;
                userDto.Position.SeniorityLevel = Enum.GetName(typeof(SeniorityLevel), employee.Position.SeniorityLevel);
            }

            return userDto;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
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

        public UserDTO? GetUserDetails(int id)
        {
            Employee? employee = _employeeRepository
                .GetByCondition(e => e.Id.Equals(id))
                .Include(e => e.DaysOff)
                .Include(e => e.Position)
                .FirstOrDefault();

            UserDTO? userDto = employee?.MapEmployeeToUserDto();

            return userDto;
        }
    }
}

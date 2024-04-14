using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Business.Mappers
{
    public static class UserMapper
    {
        public static UserDTO MapEmployeeToUserDto(this Employee employee)
        {
            UserDTO userDto = new UserDTO();

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
            userDto.Position.SeniorityLevel = Enum.GetName(typeof(SeniorityLevel), employee.Position.SeniorityLevel);

            return userDto;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Business.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeInfoDTO MapEmployeeToEmployeeInfoDto(this Employee employee)
        {
            EmployeeInfoDTO employeeInfoDTO = new EmployeeInfoDTO();

            employeeInfoDTO.Id = employee.Id;
            employeeInfoDTO.FirstName = employee.FirstName;
            employeeInfoDTO.LastName = employee.LastName;
            employeeInfoDTO.EmploymentStartDate = employee.EmploymentStartDate;
            employeeInfoDTO.EmploymentEndDate = employee.EmploymentEndDate;

            employeeInfoDTO.DaysOff.Vacation = employee.DaysOff.Vacation;
            employeeInfoDTO.DaysOff.Paid = employee.DaysOff.Paid;
            employeeInfoDTO.DaysOff.Unpaid = employee.DaysOff.Unpaid;
            employeeInfoDTO.DaysOff.SickLeave = employee.DaysOff.SickLeave;

            employeeInfoDTO.Position.Title = employee.Position.Title;
            employeeInfoDTO.Position.SeniorityLevel = Enum.GetName(typeof(SeniorityLevel), employee.Position.SeniorityLevel);

            return employeeInfoDTO;
        }

        public static EmployeeUpdateDTO MapEmployeeToEmployeeUpdateDto(this Employee employee)
        {
            EmployeeUpdateDTO employeeUpdateDTO = new EmployeeUpdateDTO();

            employeeUpdateDTO.Id = employee.Id;
            employeeUpdateDTO.FirstName = employee.FirstName;
            employeeUpdateDTO.LastName = employee.LastName;
            employeeUpdateDTO.UserName = employee.UserName;
            employeeUpdateDTO.Email = employee.Email;
            employeeUpdateDTO.Address = employee.Address;
            employeeUpdateDTO.IDNumber = employee.IDNumber;
            employeeUpdateDTO.EmploymentStartDate = employee.EmploymentStartDate;
            employeeUpdateDTO.EmploymentEndDate = employee.EmploymentEndDate;

            employeeUpdateDTO.DaysOff.Vacation = employee.DaysOff.Vacation;
            employeeUpdateDTO.DaysOff.Paid = employee.DaysOff.Paid;
            employeeUpdateDTO.DaysOff.Unpaid = employee.DaysOff.Unpaid;
            employeeUpdateDTO.DaysOff.SickLeave = employee.DaysOff.SickLeave;

            employeeUpdateDTO.Position.Title = employee.Position.Title;
            employeeUpdateDTO.Position.SeniorityLevel = Enum.GetName(typeof(Models.SeniorityLevel), employee.Position.SeniorityLevel);

            return employeeUpdateDTO;
        }

        public static void MapEmployeeUpdateDtoToEmployee(
            this EmployeeUpdateDTO employeeUpdateDTO,
            Employee employee, UserManager<Employee> userManager,
            int positionId)
        {
            employee.Id = employeeUpdateDTO.Id;
            employee.FirstName = employeeUpdateDTO.FirstName;
            employee.LastName = employeeUpdateDTO.LastName;
            employee.UserName = employeeUpdateDTO.UserName;
            employee.Email = employeeUpdateDTO.Email;
            employee.Address = employeeUpdateDTO.Address;
            employee.IDNumber = employeeUpdateDTO.IDNumber;
            employee.EmploymentStartDate = employeeUpdateDTO.EmploymentStartDate;
            employee.EmploymentEndDate = employeeUpdateDTO.EmploymentEndDate;

            employee.DaysOff.Vacation = employeeUpdateDTO.DaysOff.Vacation;
            employee.DaysOff.Paid = employeeUpdateDTO.DaysOff.Paid;
            employee.DaysOff.Unpaid = employeeUpdateDTO.DaysOff.Unpaid;
            employee.DaysOff.SickLeave = employeeUpdateDTO.DaysOff.SickLeave;

            employee.PositionID = positionId;

            employee.PasswordHash = userManager.PasswordHasher.HashPassword(employee, employeeUpdateDTO.Password);
            employee.NormalizedUserName = userManager.NormalizeName(employee.UserName);
            employee.NormalizedEmail = userManager.NormalizeEmail(employee.Email);
        }
    }
}

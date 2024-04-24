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

        public static EmployeeDTO MapEmployeeToEmployeeDto(this Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();

            employeeDTO.Id = employee.Id;
            employeeDTO.FirstName = employee.FirstName;
            employeeDTO.LastName = employee.LastName;
            employeeDTO.UserName = employee.UserName;
            employeeDTO.Email = employee.Email;
            employeeDTO.Address = employee.Address;
            employeeDTO.IDNumber = employee.IDNumber;
            employeeDTO.EmploymentStartDate = employee.EmploymentStartDate;
            employeeDTO.EmploymentEndDate = employee.EmploymentEndDate;

            employeeDTO.DaysOff.Vacation = employee.DaysOff.Vacation;
            employeeDTO.DaysOff.Paid = employee.DaysOff.Paid;
            employeeDTO.DaysOff.Unpaid = employee.DaysOff.Unpaid;
            employeeDTO.DaysOff.SickLeave = employee.DaysOff.SickLeave;

            employeeDTO.Position.Title = employee.Position.Title;
            employeeDTO.Position.SeniorityLevel = Enum.GetName(typeof(Models.SeniorityLevel), employee.Position.SeniorityLevel);

            return employeeDTO;
        }

        public static void MapEmployeeDtoToEmployeeForUpdate(
            this EmployeeDTO employeeDTO,
            Employee employee, UserManager<Employee> userManager,
            int positionId)
        {
            employee.Id = employeeDTO.Id;
            employee.FirstName = employeeDTO.FirstName;
            employee.LastName = employeeDTO.LastName;
            employee.UserName = employeeDTO.UserName;
            employee.Email = employeeDTO.Email;
            employee.Address = employeeDTO.Address;
            employee.IDNumber = employeeDTO.IDNumber;
            employee.EmploymentStartDate = employeeDTO.EmploymentStartDate;
            employee.EmploymentEndDate = employeeDTO.EmploymentEndDate;
            //employee.PhoneNumber = employeeUpdateDTO.PhoneNumber;

            employee.DaysOff.Vacation = employeeDTO.DaysOff.Vacation;
            employee.DaysOff.Paid = employeeDTO.DaysOff.Paid;
            employee.DaysOff.Unpaid = employeeDTO.DaysOff.Unpaid;
            employee.DaysOff.SickLeave = employeeDTO.DaysOff.SickLeave;

            employee.PositionID = positionId;

            employee.PasswordHash = userManager.PasswordHasher.HashPassword(employee, employeeDTO.Password);
            employee.NormalizedUserName = userManager.NormalizeName(employee.UserName);
            employee.NormalizedEmail = userManager.NormalizeEmail(employee.Email);
        }

            employee.PositionID = positionId;

            employee.PasswordHash = userManager.PasswordHasher.HashPassword(employee, employeeUpdateDTO.Password);
            employee.NormalizedUserName = userManager.NormalizeName(employee.UserName);
            employee.NormalizedEmail = userManager.NormalizeEmail(employee.Email);
        }
    }
}

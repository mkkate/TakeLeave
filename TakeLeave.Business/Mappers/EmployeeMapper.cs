using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Business.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO MapEmployeeToEmployeeDto(this Employee employee)
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

            return employeeDTO;
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
            employeeUpdateDTO.Position.SeniorityLevel = Enum.GetName(typeof(SeniorityLevel), employee.Position.SeniorityLevel);

            return employeeUpdateDTO;
        }
    }
}

using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.HR.Mappers
{
    public static class EmployeeViewModelMapper
    {
        public static EmployeeViewModel MapEmployeeDtoToEmployeeViewModel(this EmployeeDTO employeeDTO)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Id = employeeDTO.Id;
            employeeViewModel.FirstName = employeeDTO.FirstName;
            employeeViewModel.LastName = employeeDTO.LastName;
            employeeViewModel.EmploymentStartDate = employeeDTO.EmploymentStartDate;
            employeeViewModel.EmploymentEndDate = employeeDTO.EmploymentEndDate;

            employeeViewModel.DaysOff.Vacation = employeeDTO.DaysOff.Vacation;
            employeeViewModel.DaysOff.Paid = employeeDTO.DaysOff.Paid;
            employeeViewModel.DaysOff.Unpaid = employeeDTO.DaysOff.Unpaid;
            employeeViewModel.DaysOff.SickLeave = employeeDTO.DaysOff.SickLeave;

            employeeViewModel.Position.Title = employeeDTO.Position.Title;
            employeeViewModel.Position.SeniorityLevel = employeeDTO.Position.SeniorityLevel;

            return employeeViewModel;
        }

        public static EmployeeUpdateViewModel MapEmployeeUpdateDtoToEmployeeUpdateViewModel(this EmployeeUpdateDTO employeeUpdateDTO)
        {
            EmployeeUpdateViewModel employeeUpdateViewModel = new EmployeeUpdateViewModel();

            employeeUpdateViewModel.Id = employeeUpdateDTO.Id;
            employeeUpdateViewModel.FirstName = employeeUpdateDTO.FirstName;
            employeeUpdateViewModel.LastName = employeeUpdateDTO.LastName;
            employeeUpdateViewModel.UserName = employeeUpdateDTO.UserName;
            employeeUpdateViewModel.Email = employeeUpdateDTO.Email;
            employeeUpdateViewModel.Password = employeeUpdateDTO.Password;
            employeeUpdateViewModel.Address = employeeUpdateDTO.Address;
            employeeUpdateViewModel.IDNumber = employeeUpdateDTO.IDNumber;
            employeeUpdateViewModel.EmploymentStartDate = employeeUpdateDTO.EmploymentStartDate;
            employeeUpdateViewModel.EmploymentEndDate = employeeUpdateDTO.EmploymentEndDate;

            employeeUpdateViewModel.DaysOff.Vacation = employeeUpdateDTO.DaysOff.Vacation;
            employeeUpdateViewModel.DaysOff.Paid = employeeUpdateDTO.DaysOff.Paid;
            employeeUpdateViewModel.DaysOff.Unpaid = employeeUpdateDTO.DaysOff.Unpaid;
            employeeUpdateViewModel.DaysOff.SickLeave = employeeUpdateDTO.DaysOff.SickLeave;

            employeeUpdateViewModel.Position.Title = employeeUpdateDTO.Position.Title;
            employeeUpdateViewModel.Position.SeniorityLevel = employeeUpdateDTO.Position.SeniorityLevel;

            return employeeUpdateViewModel;
        }

    }
}

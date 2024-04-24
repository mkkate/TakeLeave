using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.HR.Mappers
{
    public static class EmployeeViewModelMapper
    {
        public static EmployeeInfoViewModel MapEmployeeInfoDtoToEmployeeInfoViewModel(this EmployeeInfoDTO employeeDTO)
        {
            EmployeeInfoViewModel employeeInfoViewModel = new EmployeeInfoViewModel();

            employeeInfoViewModel.Id = employeeDTO.Id;
            employeeInfoViewModel.FirstName = employeeDTO.FirstName;
            employeeInfoViewModel.LastName = employeeDTO.LastName;
            employeeInfoViewModel.EmploymentStartDate = employeeDTO.EmploymentStartDate;
            employeeInfoViewModel.EmploymentEndDate = employeeDTO.EmploymentEndDate;

            employeeInfoViewModel.DaysOff.Vacation = employeeDTO.DaysOff.Vacation;
            employeeInfoViewModel.DaysOff.Paid = employeeDTO.DaysOff.Paid;
            employeeInfoViewModel.DaysOff.Unpaid = employeeDTO.DaysOff.Unpaid;
            employeeInfoViewModel.DaysOff.SickLeave = employeeDTO.DaysOff.SickLeave;

            employeeInfoViewModel.Position.Title = employeeDTO.Position.Title;
            employeeInfoViewModel.Position.SeniorityLevel = employeeDTO.Position.SeniorityLevel;

            return employeeInfoViewModel;
        }

        public static EmployeeViewModel MapEmployeeDtoToEmployeeViewModel(this EmployeeDTO employeeDTO)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel.Id = employeeDTO.Id;
            employeeViewModel.FirstName = employeeDTO.FirstName;
            employeeViewModel.LastName = employeeDTO.LastName;
            employeeViewModel.UserName = employeeDTO.UserName;
            employeeViewModel.Email = employeeDTO.Email;
            employeeViewModel.Password = employeeDTO.Password;
            employeeViewModel.Address = employeeDTO.Address;
            employeeViewModel.IDNumber = employeeDTO.IDNumber;
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

        public static EmployeeDTO MapEmployeeViewModelToEmployeeDto(this EmployeeViewModel employeeViewModel)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();

            employeeDTO.Id = employeeViewModel.Id;
            employeeDTO.FirstName = employeeViewModel.FirstName;
            employeeDTO.LastName = employeeViewModel.LastName;
            employeeDTO.UserName = employeeViewModel.UserName;
            employeeDTO.Email = employeeViewModel.Email;
            employeeDTO.Password = employeeViewModel.Password;
            employeeDTO.Address = employeeViewModel.Address;
            employeeDTO.IDNumber = employeeViewModel.IDNumber;
            employeeDTO.EmploymentStartDate = employeeViewModel.EmploymentStartDate;
            employeeDTO.EmploymentEndDate = employeeViewModel.EmploymentEndDate;

            employeeDTO.DaysOff.Vacation = employeeViewModel.DaysOff.Vacation;
            employeeDTO.DaysOff.Paid = employeeViewModel.DaysOff.Paid;
            employeeDTO.DaysOff.Unpaid = employeeViewModel.DaysOff.Unpaid;
            employeeDTO.DaysOff.SickLeave = employeeViewModel.DaysOff.SickLeave;

            employeeDTO.Position.Title = employeeViewModel.Position.Title;
            employeeDTO.Position.SeniorityLevel = employeeViewModel.Position.SeniorityLevel;

            return employeeDTO;
        }
    }
}

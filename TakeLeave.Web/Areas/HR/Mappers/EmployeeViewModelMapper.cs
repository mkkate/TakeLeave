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

        public static EmployeeUpdateDTO MapEmployeeUpdateViewModelToEmployeeUpdateDto(this EmployeeUpdateViewModel employeeUpdateViewModel)
        {
            EmployeeUpdateDTO employeeUpdateDTO = new EmployeeUpdateDTO();

            employeeUpdateDTO.Id = employeeUpdateViewModel.Id;
            employeeUpdateDTO.FirstName = employeeUpdateViewModel.FirstName;
            employeeUpdateDTO.LastName = employeeUpdateViewModel.LastName;
            employeeUpdateDTO.UserName = employeeUpdateViewModel.UserName;
            employeeUpdateDTO.Email = employeeUpdateViewModel.Email;
            employeeUpdateDTO.Password = employeeUpdateViewModel.Password;
            employeeUpdateDTO.Address = employeeUpdateViewModel.Address;
            employeeUpdateDTO.IDNumber = employeeUpdateViewModel.IDNumber;
            employeeUpdateDTO.EmploymentStartDate = employeeUpdateViewModel.EmploymentStartDate;
            employeeUpdateDTO.EmploymentEndDate = employeeUpdateViewModel.EmploymentEndDate;

            employeeUpdateDTO.DaysOff.Vacation = employeeUpdateViewModel.DaysOff.Vacation;
            employeeUpdateDTO.DaysOff.Paid = employeeUpdateViewModel.DaysOff.Paid;
            employeeUpdateDTO.DaysOff.Unpaid = employeeUpdateViewModel.DaysOff.Unpaid;
            employeeUpdateDTO.DaysOff.SickLeave = employeeUpdateViewModel.DaysOff.SickLeave;

            employeeUpdateDTO.Position.Title = employeeUpdateViewModel.Position.Title;
            employeeUpdateDTO.Position.SeniorityLevel = employeeUpdateViewModel.Position.SeniorityLevel;

            return employeeUpdateDTO;
        }
    }
}

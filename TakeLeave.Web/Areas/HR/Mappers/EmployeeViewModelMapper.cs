using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Models;
using TakeLeave.Web.Mappers;

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

            employeeInfoViewModel.DaysOff = employeeDTO.DaysOff.MapDaysOffDtoToDaysOffViewModel();

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

            employeeViewModel.DaysOff = employeeDTO.DaysOff.MapDaysOffDtoToDaysOffViewModel();

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

            employeeDTO.DaysOff = employeeViewModel.DaysOff.MapDaysOffViewModelToDaysOffDto();

            employeeDTO.Position.Title = employeeViewModel.Position.Title;
            employeeDTO.Position.SeniorityLevel = employeeViewModel.Position.SeniorityLevel;

            return employeeDTO;
        }
    }
}

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
    }
}

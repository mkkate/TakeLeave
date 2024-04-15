using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class EmployeesController : BaseHrController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult EmployeeList()
        {
            List<EmployeeDTO>? employeeDtoList = _employeeService.EmployeeList();

            List<EmployeeViewModel> employeesViewModel = new List<EmployeeViewModel>();

            foreach (EmployeeDTO employeeDTO in employeeDtoList)
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

                employeesViewModel.Add(employeeViewModel);
            }

            return View(employeesViewModel);
        }
    }
}

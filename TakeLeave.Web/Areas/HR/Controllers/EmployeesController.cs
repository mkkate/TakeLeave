using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Mappers;
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

            List<EmployeeViewModel>? employeesViewModel = employeeDtoList?
                .Select(e => e.MapEmployeeDtoToEmployeeViewModel())
                .ToList();

            return View(employeesViewModel);
        }

        public IActionResult UpdateEmployee(int id)
        {
            EmployeeUpdateDTO? employeeUpdateDTO = _employeeService.GetEmployeeById<EmployeeUpdateDTO>(id);

            EmployeeUpdateViewModel? employeeUpdateViewModel = employeeUpdateDTO?.MapEmployeeUpdateDtoToEmployeeUpdateViewModel();

            employeeUpdateViewModel.PositionTitlesAndSeniorityLevels = _employeeService.GetPositionTitlesAndSeniorityLevels();

            return View(employeeUpdateViewModel);
        }
    }
}

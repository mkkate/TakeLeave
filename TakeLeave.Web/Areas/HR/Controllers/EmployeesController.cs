using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Mappers;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class EmployeesController : BaseHrController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(
            IEmployeeService employeeService,
            INotyfService notyfService)
            : base(notyfService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult CreateEmployee()
        {
            EmployeeViewModel employee = new EmployeeViewModel();

            employee.PositionTitlesAndSeniorityLevels = _employeeService.GetPositionTitlesAndSeniorityLevels();

            return View(employee);
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRoles.Admin)]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            EmployeeDTO employeeDTO = employeeViewModel.MapEmployeeViewModelToEmployeeDto();

            await _employeeService.CreateEmployeeAsync(employeeDTO);

            return RedirectToAction(nameof(EmployeeList));
        }

        public IActionResult EmployeeList()
        {
            List<EmployeeInfoDTO>? employeeInfoDtoList = _employeeService.EmployeeList();

            List<EmployeeInfoViewModel>? employeeInfoViewModels = employeeInfoDtoList?
                .Select(e => e.MapEmployeeInfoDtoToEmployeeInfoViewModel())
                .ToList();

            return View(employeeInfoViewModels);
        }

        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult UpdateEmployee(int id)
        {
            EmployeeDTO? employeeDTO = _employeeService.GetEmployeeById<EmployeeDTO>(id);

            EmployeeViewModel? employeeViewModel = employeeDTO?.MapEmployeeDtoToEmployeeViewModel();

            employeeViewModel.PositionTitlesAndSeniorityLevels = _employeeService.GetPositionTitlesAndSeniorityLevels();

            return View(employeeViewModel);
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRoles.Admin)]
        public async Task<IActionResult> UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            EmployeeDTO employeeDTO = employeeViewModel.MapEmployeeViewModelToEmployeeDto();

            await _employeeService.UpdateEmployeeAsync(employeeDTO);

            employeeViewModel.PositionTitlesAndSeniorityLevels = _employeeService.GetPositionTitlesAndSeniorityLevels();

            return View(employeeViewModel);
        }

        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult DeleteEmployee(int id)
        {
            EmployeeInfoDTO? employeeInfoDTO = _employeeService.GetEmployeeById<EmployeeInfoDTO>(id);

            return employeeInfoDTO is null ?
                BadRequest() :
                View(employeeInfoDTO.MapEmployeeInfoDtoToEmployeeInfoViewModel());
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRoles.Admin)]
        public async Task<IActionResult> DeleteEmployee(EmployeeInfoViewModel employeeInfoViewModel)
        {
            await _employeeService.DeleteEmployeeAsync(employeeInfoViewModel.Id);

            return RedirectToAction(nameof(EmployeeList));
        }
    }
}

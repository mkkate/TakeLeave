using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Constants;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Mappers;
using TakeLeave.Web.Areas.HR.Models;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class PositionsController : BaseHrController
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        public IActionResult PositionsList()
        {
            PositionsViewModel positionsViewModel = new PositionsViewModel
            {
                TitlesAndSeniorityLevels = _positionService.PositionList()
            };

            return View(positionsViewModel);
        }

        public IActionResult GetPositionDescription(string title, SeniorityLevel seniority)
        {
            string description = _positionService.GetPositionDescription(title, seniority);

            return Ok(description);
        }

        public IActionResult GetEmployeesListForPosition(string title, SeniorityLevel seniorityLevel)
        {
            List<EmployeeInfoDTO> employeeInfoDTOs = _positionService.GetEmployeesListForSpecifiedPosition(title, seniorityLevel);

            List<EmployeeInfoViewModel> employeeInfoViewModels = employeeInfoDTOs.Select(e => e.MapEmployeeInfoDtoToEmployeeInfoViewModel()).ToList();

            return PartialView("/Areas/HR/Views/Employees/EmployeeList.cshtml", employeeInfoViewModels);
        }

        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult CreatePosition()
        {
            PositionViewModel positionViewModel = new PositionViewModel();

            positionViewModel.SeniorityLevels = _positionService.GetSeniorityLevels();

            return View(positionViewModel);
        }

        [HttpPost]
        [Authorize(Roles = EmployeeRoles.Admin)]
        public IActionResult CreatePosition(PositionViewModel positionViewModel)
        {
            PositionDTO positionDTO = positionViewModel.MapPositionViewModelToPositionDto();

            _positionService.CreatePosition(positionDTO);

            return RedirectToAction(nameof(PositionsList));
        }
    }
}

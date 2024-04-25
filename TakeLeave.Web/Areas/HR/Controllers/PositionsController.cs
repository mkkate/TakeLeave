using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Mappers;
using TakeLeave.Web.Areas.HR.Models;

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
    }
}

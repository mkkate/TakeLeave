using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
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

        [HttpGet]
        public IActionResult GetPositionDescription(string title, SeniorityLevel seniority)
        {
            string description = _positionService.GetPositionDescription(title, seniority);

            return Ok(description);
        }
    }
}

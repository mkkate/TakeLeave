using TakeLeave.Business.Models;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.HR.Mappers
{
    public static class PositionViewModelMapper
    {
        public static PositionDTO MapPositionViewModelToPositionDto(this PositionViewModel positionViewModel)
        {
            return new PositionDTO()
            {
                Title = positionViewModel.Title,
                SeniorityLevel = positionViewModel.SeniorityLevel,
                Description = positionViewModel.Description
            };
        }
    }
}

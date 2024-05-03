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

        public static PositionViewModel MapPositionDtoToPositionViewModel(this PositionDTO positionDTO)
        {
            return new PositionViewModel()
            {
                Title = positionDTO.Title,
                SeniorityLevel = positionDTO.SeniorityLevel,
                Description = positionDTO.Description
            };
        }
    }
}

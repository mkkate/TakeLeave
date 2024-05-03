using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Positions;

namespace TakeLeave.Business.Mappers
{
    public static class PositionMapper
    {
        public static void MapPositionDtoToPosition(this PositionDTO positionDTO, Position position)
        {
            position.Title = positionDTO.Title;
            position.SeniorityLevel = Enum.Parse<Data.Database.Positions.SeniorityLevel>(positionDTO.SeniorityLevel);
            position.Description = positionDTO.Description;
        }

        public static PositionDTO MapPositionToPositionDto(this Position position)
        {
            return new PositionDTO()
            {
                Title = position.Title,
                SeniorityLevel = Enum.GetName(position.SeniorityLevel),
                Description = position.Description
            }; ;
        }
    }
}

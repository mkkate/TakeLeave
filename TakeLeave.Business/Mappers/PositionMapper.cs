using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Positions;

namespace TakeLeave.Business.Mappers
{
    public static class PositionMapper
    {
        public static Position MapPositionDtoToPosition(this PositionDTO positionDTO)
        {
            return new Position()
            {
                Title = positionDTO.Title,
                SeniorityLevel = Enum.Parse<Data.Database.Positions.SeniorityLevel>(positionDTO.SeniorityLevel),
                Description = positionDTO.Description
            };
        }
    }
}

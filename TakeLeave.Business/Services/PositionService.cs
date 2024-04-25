using TakeLeave.Business.Interfaces;
using TakeLeave.Data.Database.Positions;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public Dictionary<string, List<Tuple<string, string>>> PositionList()
        {
            List<Position> positions = _positionRepository.GetAll().ToList();

            Dictionary<string, List<Tuple<string, string>>> titlesAndSeniorityLevels = new Dictionary<string, List<Tuple<string, string>>>();

            foreach (var position in positions)
            {
                if (titlesAndSeniorityLevels.ContainsKey(position.Title))
                {
                    titlesAndSeniorityLevels[position.Title].Add((position.SeniorityLevel.ToString(), position.Description).ToTuple());
                }
                else
                {
                    List<Tuple<string, string>> seniorityLevels = new List<Tuple<string, string>>
                    {
                        Tuple.Create(position.SeniorityLevel.ToString(), position.Description)
                    };
                    titlesAndSeniorityLevels.Add(position.Title, seniorityLevels);
                }
            }

            return titlesAndSeniorityLevels;
        }

        public string GetPositionDescription(string title, Models.SeniorityLevel seniority)
        {
            string? description = _positionRepository.GetByCondition(
                    p => p.Title.Equals(title.Trim()) &&
                    p.SeniorityLevel.Equals((Data.Database.Positions.SeniorityLevel)seniority))
                    .FirstOrDefault()
                    ?.Description;

            return description is null ? string.Empty : description;
        }
    }
}

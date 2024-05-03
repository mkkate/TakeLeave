using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IPositionService
    {
        Dictionary<string, List<Tuple<string, string>>> PositionList();
        string GetPositionDescription(string title, Models.SeniorityLevel seniority);
        List<EmployeeInfoDTO> GetEmployeesListForSpecifiedPosition(string title, Models.SeniorityLevel seniority);
        HashSet<string> GetSeniorityLevels();
        void CreatePosition(PositionDTO positionDTO);
    }
}

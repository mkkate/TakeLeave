namespace TakeLeave.Business.Interfaces
{
    public interface IPositionService
    {
        public Dictionary<string, List<Tuple<string, string>>> PositionList();
        string GetPositionDescription(string title, Models.SeniorityLevel seniority);
    }
}

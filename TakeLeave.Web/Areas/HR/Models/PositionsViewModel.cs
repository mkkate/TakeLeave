namespace TakeLeave.Web.Areas.HR.Models
{
    public class PositionsViewModel
    {
        public Dictionary<string, List<Tuple<string, string>>> TitlesAndSeniorityLevels { get; set; } = new Dictionary<string, List<Tuple<string, string>>>();
    }
}

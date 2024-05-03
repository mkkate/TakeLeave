namespace TakeLeave.Business.Models
{
    public enum SeniorityLevel
    {
        Junior,
        Medior,
        Senior
    }

    public class PositionDTO
    {
        public string Title { get; set; }
        public string SeniorityLevel { get; set; }
        public string Description { get; set; }
        public int EmployeeRoleId { get; set; }
    }
}

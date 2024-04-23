namespace TakeLeave.Business.Models
{
    public class EmployeeInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public DaysOffDTO DaysOff { get; set; } = new DaysOffDTO();
        public PositionDTO Position { get; set; } = new PositionDTO();
    }
}

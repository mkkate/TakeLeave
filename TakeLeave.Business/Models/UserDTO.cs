namespace TakeLeave.Business.Models
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateOnly EmploymentStartDate { get; set; }
        public DateOnly? EmploymentEndDate { get; set; }
        public DaysOffDTO DaysOff { get; set; } = new DaysOffDTO();
        public PositionDTO Position { get; set; } = new PositionDTO();
    }
}

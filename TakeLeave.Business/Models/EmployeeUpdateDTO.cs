namespace TakeLeave.Business.Models
{
    public class EmployeeUpdateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public DaysOffDTO DaysOff { get; set; } = new DaysOffDTO();
        public PositionDTO Position { get; set; } = new PositionDTO();
    }
}

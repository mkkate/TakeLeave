namespace TakeLeave.Business.Models
{
    public class EmployeeChatDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PositionDTO Position { get; set; } = new PositionDTO();
    }
}

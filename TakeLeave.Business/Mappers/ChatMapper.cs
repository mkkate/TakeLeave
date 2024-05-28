using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Business.Mappers
{
    public static class ChatMapper
    {
        public static EmployeeChatDTO MapEmployeeToEmployeeChatDto(this Employee employee)
        {
            return new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position.MapPositionToPositionDto()
            };
        }
    }
}

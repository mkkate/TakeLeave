using TakeLeave.Business.Models;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Mappers
{
    public static class ChatViewModelMapper
    {
        public static EmployeeChatViewModel MapEmployeeChatDtoToEmployeeChatViewModel(this EmployeeChatDTO employeeChatDto)
        {
            return new()
            {
                Id = employeeChatDto.Id,
                FirstName = employeeChatDto.FirstName,
                LastName = employeeChatDto.LastName,
                PositionTitle = employeeChatDto.Position.Title,
                //seniority level
            };
        }
    }
}

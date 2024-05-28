using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IChatService
    {
        List<EmployeeChatDTO> GetEmployeesChatList();
    }
}

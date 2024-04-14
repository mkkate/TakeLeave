using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserDetails(int id);
    }
}

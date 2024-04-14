using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.User.Models;

namespace TakeLeave.Web.Areas.User.Mappers
{
    public static class UserViewModelMapper
    {
        public static UserViewModel MapUserDtoToUserViewModel(this UserDTO userDTO)
        {
            UserViewModel userViewModel = new UserViewModel();

            userViewModel.FirstName = userDTO.FirstName;
            userViewModel.LastName = userDTO.LastName;
            userViewModel.Address = userDTO.Address;
            userViewModel.EmploymentStartDate = userDTO.EmploymentStartDate;
            userViewModel.EmploymentEndDate = userDTO.EmploymentEndDate;

            userViewModel.DaysOff.Vacation = userDTO.DaysOff.Vacation;
            userViewModel.DaysOff.Paid = userDTO.DaysOff.Paid;
            userViewModel.DaysOff.Unpaid = userDTO.DaysOff.Unpaid;
            userViewModel.DaysOff.SickLeave = userDTO.DaysOff.SickLeave;

            userViewModel.Position.Title = userDTO.Position.Title;
            userViewModel.Position.SeniorityLevel = userDTO.Position.SeniorityLevel;

            return userViewModel;
        }
    }
}

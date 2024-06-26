﻿using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.User.Models;
using TakeLeave.Web.Mappers;

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

            userViewModel.DaysOff = userDTO.DaysOff.MapDaysOffDtoToDaysOffViewModel();

            userViewModel.Position.Title = userDTO.Position.Title;
            userViewModel.Position.SeniorityLevel = userDTO.Position.SeniorityLevel;

            return userViewModel;
        }
    }
}

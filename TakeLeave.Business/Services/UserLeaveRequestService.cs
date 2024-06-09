using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Interfaces;
using LeaveRequestType = TakeLeave.Data.Database.LeaveRequests.LeaveRequestType;

namespace TakeLeave.Business.Services
{
    public class UserLeaveRequestService : IUserLeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UserLeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public void CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
        {
            double requestedDaysOff = DaysOffHelper.CountRequestedDaysOff(
                leaveRequestDTO.LeaveStartDate,
                leaveRequestDTO.LeaveEndDate);

            LeaveRequestType leaveRequestType = Enum.Parse<LeaveRequestType>(leaveRequestDTO.LeaveType);

            bool hasEnoughDays = DaysOffHelper.HasEnoughDays(
                requestedDaysOff,
                leaveRequestDTO.DaysOff,
                leaveRequestType);

            if (hasEnoughDays)
            {
                LeaveRequest leaveRequest = leaveRequestDTO.MapLeaveRequestDtoToLeaveRequest();

                _leaveRequestRepository.Insert(leaveRequest);
                _leaveRequestRepository.Save();
            }
        }

        public List<LeaveRequestDTO> GetLeaveRequestsForLoggedInUser(int id)
        {
            List<LeaveRequest> leaveRequests = _leaveRequestRepository.
                GetByCondition(leave => leave.EmployeeID.Equals(id))
                .Include(lr => lr.HandledByHr)
                .OrderByDescending(lr => lr.LeaveStartDate)
                .ToList();

            List<LeaveRequestDTO> leaveRequestDTOs = leaveRequests
                .Select(leave => leave.MapLeaveRequestToLeaveRequestDto())
                .ToList();

            return leaveRequestDTOs;
        }
    }
}

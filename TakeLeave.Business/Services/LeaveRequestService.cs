using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Interfaces;
using LeaveRequestType = TakeLeave.Data.Database.LeaveRequests.LeaveRequestType;

namespace TakeLeave.Business.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
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
    }
}

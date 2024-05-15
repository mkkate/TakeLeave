using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Interfaces;
using LeaveRequestStatus = TakeLeave.Data.Database.LeaveRequests.LeaveRequestStatus;
using LeaveRequestType = TakeLeave.Data.Database.LeaveRequests.LeaveRequestType;

namespace TakeLeave.Business.Services
{
    public class HrLeaveRequestService : IHrLeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public HrLeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public List<HrLeaveRequestDTO> GetLeaveRequests()
        {
            List<LeaveRequest> leaveRequests = _leaveRequestRepository
                .GetAll()
                .Include(lr => lr.RequestedByEmployee)
                .ToList();

            List<HrLeaveRequestDTO> leaveRequestDTOs = leaveRequests
                .Select(lr => lr.MapLeaveRequestToHrLeaveRequestDto())
                .ToList();

            return leaveRequestDTOs;
        }

        public HrLeaveRequestDTO GetLeaveRequestById(int id)
        {
            LeaveRequest? leaveRequest = _leaveRequestRepository
                .GetByCondition(lr => lr.ID.Equals(id))
                .Include(lr => lr.RequestedByEmployee)
                .Include(lr => lr.RequestedByEmployee.DaysOff)
                .FirstOrDefault();

            if (leaveRequest is null)
            {
                return null;
            }

            HrLeaveRequestDTO hrLeaveRequestDTO = leaveRequest.MapLeaveRequestToHrLeaveRequestDto();
            hrLeaveRequestDTO.DaysOff = leaveRequest.RequestedByEmployee.DaysOff.MapDaysOffToDaysOffDto();

            return hrLeaveRequestDTO;
        }

        public HashSet<string> GetLeaveTypes()
        {
            var enums = Enum.GetValues<Models.LeaveRequests.LeaveRequestType>()
                .ToHashSet();

            return enums.Select(e => e.GetEnumDescription())
                .ToHashSet();
        }

        public void UpdateLeaveRequest(HrLeaveRequestDTO hrLeaveRequestDTO)
        {
            LeaveRequest? leaveRequest = _leaveRequestRepository
                .GetByCondition(lr => lr.ID.Equals(hrLeaveRequestDTO.Id))
                .Include(lr => lr.RequestedByEmployee)
                .FirstOrDefault();

            if (leaveRequest is not null)
            {
                hrLeaveRequestDTO.MapHrLeaveRequestDtoToLeaveRequest(leaveRequest);

                _leaveRequestRepository.Update(leaveRequest);
                _leaveRequestRepository.Save();
            }
        }

        public void ApproveLeaveRequest(HrLeaveRequestDTO hrLeaveRequestDTO, int loggedHrId)
        {
            LeaveRequest? leaveRequest = _leaveRequestRepository
                .GetByCondition(lr => lr.ID.Equals(hrLeaveRequestDTO.Id))
                .Include(lr => lr.RequestedByEmployee)
                .Include(e => e.RequestedByEmployee.DaysOff)
                .FirstOrDefault();

            if (leaveRequest is not null)
            {
                double requestedDaysOff = DaysOffHelper.CountRequestedDaysOff(
                hrLeaveRequestDTO.LeaveStartDate,
                hrLeaveRequestDTO.LeaveEndDate);

                LeaveRequestType leaveRequestType = (LeaveRequestType)EnumHelper.
                    GetEnumValueFromDisplayName<Models.LeaveRequests.LeaveRequestType>(hrLeaveRequestDTO.LeaveType);

                bool hasEnoughDays = DaysOffHelper.HasEnoughDays(
                    requestedDaysOff,
                    leaveRequest.RequestedByEmployee.DaysOff.MapDaysOffToDaysOffDto(),
                    leaveRequestType);

                if (hasEnoughDays)
                {
                    leaveRequest.Status = LeaveRequestStatus.Approved;
                    leaveRequest.HandledByHrID = loggedHrId;

                    DaysOffHelper.ReduceDaysOff(
                        (int)requestedDaysOff,
                        leaveRequestType,
                        leaveRequest.RequestedByEmployee.DaysOff);

                    _leaveRequestRepository.Update(leaveRequest);
                    _leaveRequestRepository.Save();
                }
            }
        }

        public void RejectLeaveRequest(int id, int loggedHrId)
        {
            LeaveRequest? leaveRequest = _leaveRequestRepository
                .GetByCondition(lr => lr.ID.Equals(id))
                .FirstOrDefault();

            if (leaveRequest is not null)
            {
                leaveRequest.Status = LeaveRequestStatus.Rejected;
                leaveRequest.HandledByHrID = loggedHrId;

                _leaveRequestRepository.Update(leaveRequest);
                _leaveRequestRepository.Save();
            }
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Interfaces;
using LeaveRequestStatus = TakeLeave.Data.Database.LeaveRequests.LeaveRequestStatus;

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
                .OrderByDescending(lr => lr.LeaveStartDate)
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

        public void ApproveLeaveRequest(int id, int loggedHrId)
        {
            LeaveRequest? leaveRequest = _leaveRequestRepository
                .GetByCondition(lr => lr.ID.Equals(id))
                .Include(lr => lr.RequestedByEmployee)
                .Include(e => e.RequestedByEmployee.DaysOff)
                .FirstOrDefault();

            if (leaveRequest is not null)
            {
                double requestedDaysOff = DaysOffHelper.CountRequestedDaysOff(
                    leaveRequest.LeaveStartDate,
                    leaveRequest.LeaveEndDate);

                bool hasEnoughDays = DaysOffHelper.HasEnoughDays(
                    requestedDaysOff,
                    leaveRequest.RequestedByEmployee.DaysOff.MapDaysOffToDaysOffDto(),
                    leaveRequest.LeaveType);

                if (hasEnoughDays)
                {
                    leaveRequest.Status = LeaveRequestStatus.Approved;
                    leaveRequest.HandledByHrID = loggedHrId;

                    DaysOffHelper.ReduceDaysOff(
                        (int)requestedDaysOff,
                        leaveRequest.LeaveType,
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

        public List<CalendarDTO> GetEmployeesOnLeave(DateTime date)
        {
            List<LeaveRequest>? leaves = _leaveRequestRepository
                .GetByCondition(leave =>
                leave.LeaveStartDate <= date &&
                leave.LeaveEndDate >= date &&
                leave.Status.Equals(LeaveRequestStatus.Approved))
                .Include(leave => leave.RequestedByEmployee)
                .ToList();

            if (leaves.Any())
            {
                List<CalendarDTO> calendarDTOs = leaves
                    .Select(leave => leave.MapLeaveRequestToCalendarDto())
                    .ToList();

                return calendarDTOs;
            }
            else
            {
                return new List<CalendarDTO>();
            }
        }
    }
}

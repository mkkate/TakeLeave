using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models.LeaveRequests;
using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Interfaces;

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
    }
}

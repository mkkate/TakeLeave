using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
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
            double requestedDaysOff = CountRequestedDaysOff(
                leaveRequestDTO.LeaveStartDate,
                leaveRequestDTO.LeaveEndDate);

            LeaveRequestType leaveRequestType = Enum.Parse<LeaveRequestType>(leaveRequestDTO.LeaveType);

            bool hasEnoughDays = HasEnoughDays(
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

        private double CountRequestedDaysOff(DateTime startDate, DateTime endDate)
        {
            return endDate.AddDays(1).Subtract(startDate).TotalDays - CountWeekendDays(startDate, endDate);
        }

        public double CountWeekendDays(DateTime startDate, DateTime endDate)
        {
            double countWeekendDays = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    countWeekendDays++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return countWeekendDays;
        }

        private bool HasEnoughDays(double requestedDaysOff, DaysOffDTO daysOffDTO, LeaveRequestType leaveRequestType)
        {
            switch (leaveRequestType)
            {
                case LeaveRequestType.Vacation:
                    return requestedDaysOff <= daysOffDTO.Vacation;

                case LeaveRequestType.Paid:
                    return requestedDaysOff <= daysOffDTO.Paid;

                case LeaveRequestType.Unpaid:
                    return requestedDaysOff <= daysOffDTO.Unpaid;

                case LeaveRequestType.SickLeave:
                    return requestedDaysOff <= daysOffDTO.SickLeave;

                default: return false;
            }
        }
    }
}

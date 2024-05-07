using TakeLeave.Business.Models;
using TakeLeave.Data.Database.LeaveRequests;

namespace TakeLeave.Business.Helpers
{
    public static class DaysOffHelper
    {
        public static double CountRequestedDaysOff(DateTime startDate, DateTime endDate)
        {
            return endDate.AddDays(1).Subtract(startDate).TotalDays - CountWeekendDays(startDate, endDate);
        }

        public static double CountWeekendDays(DateTime startDate, DateTime endDate)
        {
            double countWeekendDays = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                if (CurrentDateIsWeekendDay(currentDate))
                {
                    countWeekendDays++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return countWeekendDays;
        }

        private static bool CurrentDateIsWeekendDay(DateTime currentDate)
        {
            return currentDate.DayOfWeek == DayOfWeek.Saturday ||
                currentDate.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool HasEnoughDays(
            double requestedDaysOff,
            DaysOffDTO daysOffDTO,
            LeaveRequestType leaveRequestType)
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

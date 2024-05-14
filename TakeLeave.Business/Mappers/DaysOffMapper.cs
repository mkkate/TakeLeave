using TakeLeave.Business.Models;
using TakeLeave.Data.Database.DaysOffs;

namespace TakeLeave.Business.Mappers
{
    public static class DaysOffMapper
    {
        public static DaysOffDTO MapDaysOffToDaysOffDto(this DaysOff daysOff)
        {
            return new()
            {
                Vacation = daysOff.Vacation,
                Paid = daysOff.Paid,
                Unpaid = daysOff.Unpaid,
                SickLeave = daysOff.SickLeave,
            };
        }
    }
}

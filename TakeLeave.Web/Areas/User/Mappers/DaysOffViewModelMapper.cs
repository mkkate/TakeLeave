using TakeLeave.Business.Models;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.User.Mappers
{
    public static class DaysOffViewModelMapper
    {
        public static DaysOffViewModel MapDaysOffDtoToDaysOffViewModel(this DaysOffDTO daysOffDTO)
        {
            return new()
            {
                Vacation = daysOffDTO.Vacation,
                Paid = daysOffDTO.Paid,
                Unpaid = daysOffDTO.Unpaid,
                SickLeave = daysOffDTO.SickLeave,
            };
        }

        public static DaysOffDTO MapDaysOffViewModelToDaysOffDto(this DaysOffViewModel daysOffViewModel)
        {
            return new()
            {
                Vacation = daysOffViewModel.Vacation,
                Paid = daysOffViewModel.Paid,
                Unpaid = daysOffViewModel.Unpaid,
                SickLeave = daysOffViewModel.SickLeave,
            };
        }
    }
}

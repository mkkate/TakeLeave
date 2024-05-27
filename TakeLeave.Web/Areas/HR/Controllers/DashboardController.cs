using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Areas.HR.Models;

namespace TakeLeave.Web.Areas.HR.Controllers
{
    public class DashboardController : BaseHrController
    {
        private readonly IHrLeaveRequestService _hrLeaveRequestService;

        public DashboardController(IHrLeaveRequestService hrLeaveRequestService)
        {
            _hrLeaveRequestService = hrLeaveRequestService;
        }

        public IActionResult Index(int? year, int? month)
        {
            List<LeaveCalendarViewModel> leaveViewModel = new List<LeaveCalendarViewModel>();

            DateTime startDate = new DateTime(year ?? DateTime.Now.Year, month ?? DateTime.Now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (DaysOffHelper.CurrentDateIsWeekendDay(date))
                {
                    leaveViewModel.Add(new LeaveCalendarViewModel
                    {
                        Date = date,
                        EmployeesOnLeave = new()
                    });
                }
                else
                {
                    List<CalendarDTO> employeesOnLeave = _hrLeaveRequestService.GetEmployeesOnLeave(date);

                    leaveViewModel.Add(new LeaveCalendarViewModel
                    {
                        Date = date,
                        EmployeesOnLeave = employeesOnLeave
                    });
                }
            }

            if (year.HasValue && month.HasValue)
            {
                return PartialView("Partial/_CalendarPartial", leaveViewModel);
            }
            else
            {
                return View(leaveViewModel);
            }
        }
    }
}

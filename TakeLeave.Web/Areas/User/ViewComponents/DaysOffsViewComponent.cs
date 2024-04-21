using Microsoft.AspNetCore.Mvc;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Areas.User.ViewComponents
{
    public class DaysOffsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DaysOffViewModel daysOffViewModel)
        {
            return View(daysOffViewModel);
        }
    }
}

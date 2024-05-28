using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Mappers;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public IActionResult GetUsers()
        {
            List<EmployeeChatDTO> employeeChatDTOs = _chatService.GetEmployeesChatList();

            List<EmployeeChatViewModel> employeeChatViewModels = employeeChatDTOs
                .Select(dto => dto.MapEmployeeChatDtoToEmployeeChatViewModel())
                .ToList();

            return PartialView("~/Views/Shared/GetUsersPartial.cshtml", employeeChatViewModels);
        }
    }
}

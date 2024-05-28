using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;

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
            return Json(employeeChatDTOs);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Models;
using TakeLeave.Web.Mappers;
using TakeLeave.Web.Models;

namespace TakeLeave.Web.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public IActionResult GetUsers()
        {
            List<EmployeeChatDTO> employeeChatDTOs = _chatService.GetEmployeesChatList(GetLoggedInEmployeeId());

            List<EmployeeChatViewModel> employeeChatViewModels = employeeChatDTOs
                .Select(dto => dto.MapEmployeeChatDtoToEmployeeChatViewModel())
                .ToList();

            return PartialView("~/Views/Shared/GetUsersPartial.cshtml", employeeChatViewModels);
        }

        public IActionResult GetMessages(int receiverId)
        {
            int senderId = GetLoggedInEmployeeId();

            List<ChatMessageDTO> chatMessageDTOs = _chatService.GetMessagesBetweenUsers(senderId, receiverId);

            return Json(chatMessageDTOs);
        }
    }
}

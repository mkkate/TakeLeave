using AspNetCoreHero.ToastNotification.Abstractions;
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

        public ChatController(
            IChatService chatService,
            INotyfService notyfService)
            : base(notyfService)
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

        public IActionResult GetNumberOfUnreadMessages()
        {
            int receiverId = GetLoggedInEmployeeId();

            Dictionary<int, int> unreadMessagesCount = _chatService.GetNumberOfUnreadMessagesForCurrentUser(receiverId);

            return Json(unreadMessagesCount);
        }

        public IActionResult ReadAllUnreadMessagesFromUser(int fromUserId)
        {
            int receiverId = GetLoggedInEmployeeId();

            bool allRead = _chatService.ReadAllUnreadMessagesFromUser(fromUserId, receiverId);

            return Json(allRead);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using TakeLeave.Business.Interfaces;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly UserManager<Employee> _employeeUserManager;

        public ChatHub(IChatService chatService,
             UserManager<Employee> employeeUserManager)
        {
            _chatService = chatService;
            _employeeUserManager = employeeUserManager;
        }

        public async Task SendMessage(string receiverId, string message)
        {
            string? loggedInUserId = Context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInUserId != null)
            {
                Employee? sender = _employeeUserManager
                    .FindByIdAsync(loggedInUserId)
                    .Result;

                if (sender != null)
                {
                    bool writtenToDb = _chatService
                        .InsertMessageIntoDatabase(sender.Id, Int32.Parse(receiverId), message);

                    if (writtenToDb)
                    {
                        await Clients
                            .User(receiverId)
                            .SendAsync("ReceiveMessage", sender.Id, sender.FirstName, sender.LastName, message);
                    }
                }
            }
        }

        public override async Task OnConnectedAsync()
        {
            string? userId = Context.UserIdentifier;
            if (userId != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userId);
                await base.OnConnectedAsync();
            }
        }
    }
}

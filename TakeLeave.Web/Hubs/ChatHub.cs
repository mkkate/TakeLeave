using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using TakeLeave.Business.Interfaces;

namespace TakeLeave.Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string userId, string message)
        {
            Int32.TryParse(Context.User?.FindFirstValue(ClaimTypes.NameIdentifier), out int senderId);

            bool writtenToDb = _chatService
                .InsertMessageIntoDatabase(senderId, Int32.Parse(userId), message);

            if (writtenToDb)
            {
                await Clients.User(userId).SendAsync("ReceiveMessage", senderId, message);
            }
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            await base.OnConnectedAsync();
        }
    }
}

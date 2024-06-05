using TakeLeave.Business.Models;
using TakeLeave.Data.Database.ChatMessages;

namespace TakeLeave.Business.Mappers
{
    public static class ChatMessageMapper
    {
        public static ChatMessageDTO MapChatMessageToChatMessageDto(this ChatMessage chatMessage)
        {
            return new()
            {
                ID = chatMessage.ID,
                SenderId = chatMessage.SenderId,
                ReceiverId = chatMessage.ReceiverId,
                Content = chatMessage.Content,
                Timestamp = chatMessage.Timestamp,
            };
        }
    }
}

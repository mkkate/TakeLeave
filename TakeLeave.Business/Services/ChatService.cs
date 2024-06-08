using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
using TakeLeave.Data.Database.ChatMessages;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Services
{
    public class ChatService : IChatService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IChatMessageRepository _chatMessageRepository;

        public ChatService(
            IEmployeeRepository employeeRepository,
            IChatMessageRepository chatMessageRepository)
        {
            _employeeRepository = employeeRepository;
            _chatMessageRepository = chatMessageRepository;
        }

        public List<EmployeeChatDTO> GetEmployeesChatList(int logedEmployeeId)
        {
            List<EmployeeChatDTO>? employeeChatDTOs = _employeeRepository
                .GetCurrentlyEmployedEmployees(logedEmployeeId)
                .Include(employee => employee.Position)
                .Select(employee => employee.MapEmployeeToEmployeeChatDto())
                .ToList();

            return employeeChatDTOs;
        }

        public bool InsertMessageIntoDatabase(int senderId, int receiverId, string content)
        {
            ChatMessage chatMessage = new()
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.Now
            };

            _chatMessageRepository.Insert(chatMessage);
            _chatMessageRepository.Save();

            return chatMessage.ID > 0 ? true : false;
        }

        public List<ChatMessageDTO> GetMessagesBetweenUsers(int userId1, int userId2)
        {
            List<ChatMessage> chatMessages = _chatMessageRepository
                .GetByCondition(message =>
                (message.SenderId.Equals(userId1) && message.ReceiverId.Equals(userId2)) ||
                (message.SenderId.Equals(userId2) && message.ReceiverId.Equals(userId1)))
                .OrderBy(message => message.Timestamp)
                .ToList();

            List<ChatMessageDTO> chatMessageDTOs = chatMessages
                .Select(message => message.MapChatMessageToChatMessageDto())
                .ToList();

            return chatMessageDTOs;
        }

        public Dictionary<int, int> GetNumberOfUnreadMessagesForCurrentUser(int receiverId)
        {
            var count = _chatMessageRepository
                .GetByCondition(message =>
                message.ReceiverId.Equals(receiverId) &&
                message.Seen.Equals(false));

            Dictionary<int, int> sendersCounts = new();

            foreach (var message in count)
            {
                if (sendersCounts.ContainsKey(message.SenderId))
                {
                    sendersCounts[message.SenderId]++;
                }
                else
                {
                    sendersCounts.Add(message.SenderId, 1);
                }
            }

            return sendersCounts;
        }

        public bool ReadAllUnreadMessagesFromUser(int fromUserId, int receiverId)
        {
            List<ChatMessage> chatMessages = _chatMessageRepository
                .GetByCondition(message =>
                message.SenderId.Equals(fromUserId) &&
                message.ReceiverId.Equals(receiverId))
                .OrderBy(message => message.Timestamp)
                .ToList();

            if (chatMessages.Any(message => message.Seen.Equals(false)))
            {
                foreach (ChatMessage message in chatMessages)
                {
                    if (message.Seen.Equals(false))
                    {
                        message.Seen = true;
                        _chatMessageRepository.Update(message);
                    }
                }
                _chatMessageRepository.Save();
            }

            return true;
        }
    }
}

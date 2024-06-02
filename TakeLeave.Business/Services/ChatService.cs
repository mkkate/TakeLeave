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
                Timestamp = DateTime.UtcNow
            };

            _chatMessageRepository.Insert(chatMessage);
            _chatMessageRepository.Save();

            return chatMessage.ID > 0 ? true : false;
        }
    }
}

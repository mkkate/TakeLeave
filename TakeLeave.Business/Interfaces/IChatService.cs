﻿using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IChatService
    {
        List<EmployeeChatDTO> GetEmployeesChatList(int logedEmployeeId);
        bool InsertMessageIntoDatabase(int senderId, int receiverId, string content);
        List<ChatMessageDTO> GetMessagesBetweenUsers(int userId1, int userId2);
        Dictionary<int, int> GetNumberOfUnreadMessagesForCurrentUser(int receiverId);
        bool ReadAllUnreadMessagesFromUser(int fromUserId, int receiverId);
    }
}

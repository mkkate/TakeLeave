using TakeLeave.Data.Database.ChatMessages;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public class ChatMessageRepository : RepositoryBase<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(TakeLeaveDbContext dbContext) : base(dbContext)
        {
        }
    }
}

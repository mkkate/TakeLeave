using TakeLeave.Data.Database.LeaveRequests;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public class LeaveRequestRepository : RepositoryBase<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(TakeLeaveDbContext dbContext) : base(dbContext)
        {
        }
    }
}

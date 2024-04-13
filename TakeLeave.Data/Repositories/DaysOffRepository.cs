using TakeLeave.Data.Database.DaysOffs;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public class DaysOffRepository : RepositoryBase<DaysOff>, IDaysOffRepository
    {
        public DaysOffRepository(TakeLeaveDbContext dbContext) : base(dbContext)
        {
        }
    }
}

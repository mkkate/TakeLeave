using TakeLeave.Data.Database.Positions;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(TakeLeaveDbContext dbContext) : base(dbContext)
        {
        }
    }
}

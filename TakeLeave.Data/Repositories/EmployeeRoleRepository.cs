using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public class EmployeeRoleRepository : RepositoryBase<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(TakeLeaveDbContext dbContext) : base(dbContext)
        {
        }
    }
}

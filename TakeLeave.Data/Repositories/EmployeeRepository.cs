using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TakeLeaveDbContext dbContext) : base(dbContext)
        {
        }
        public IQueryable<Employee> GetAllNotDeleted()
        {
            return GetByCondition(e => e.DeleteDate.Equals(null));
        }
    }
}

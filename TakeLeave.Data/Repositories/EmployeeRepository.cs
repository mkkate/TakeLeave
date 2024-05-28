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

        public IQueryable<Employee> GetCurrentlyEmployedEmployees()
        {
            return GetByCondition(employee =>
                employee.DeleteDate.Equals(null) &&
                employee.EmploymentStartDate <= DateTime.UtcNow &&
                employee.EmploymentEndDate >= DateTime.UtcNow);
        }
    }
}

using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Data.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        IQueryable<Employee> GetAllNotDeleted();
        IQueryable<Employee> GetCurrentlyEmployedEmployees();
    }
}

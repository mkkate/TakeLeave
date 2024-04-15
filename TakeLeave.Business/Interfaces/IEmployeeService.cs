using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO>? EmployeeList();
    }
}

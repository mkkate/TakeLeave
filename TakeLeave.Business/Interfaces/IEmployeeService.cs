using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO>? EmployeeList();
        T? GetEmployeeById<T>(int id) where T : class;
        Tuple<List<string>, List<string>> GetPositionTitlesAndSeniorityLevels();
        Task UpdateEmployeeAsync(EmployeeUpdateDTO employeeUpdateDTO);
    }
}

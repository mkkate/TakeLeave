using TakeLeave.Business.Models;

namespace TakeLeave.Business.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeInfoDTO>? EmployeeList();
        T? GetEmployeeById<T>(int id) where T : class;
        Tuple<HashSet<string>, List<string>> GetPositionTitlesAndSeniorityLevels();
        Task UpdateEmployeeAsync(EmployeeUpdateDTO employeeUpdateDTO);
    }
}

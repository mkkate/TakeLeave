using TakeLeave.Business.Interfaces;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IEmployeeRoleRepository _employeeRoleRepository;

        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository)
        {
            _employeeRoleRepository = employeeRoleRepository;
        }

        public Dictionary<int, string?> GetEmployeeRoles()
        {
            return _employeeRoleRepository.GetAll()
                .ToDictionary(er => er.Id, er => er.Name);
        }
    }
}

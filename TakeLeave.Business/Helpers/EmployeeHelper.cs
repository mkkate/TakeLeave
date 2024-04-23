using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TakeLeave.Business.Constants;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Helpers
{
    public class EmployeeHelper
    {
        public static async Task AssignRole(
            Employee employee,
            UserManager<Employee> userManager,
            IPositionRepository _positionRepository)
        {
            string roleName = GetRoleName(employee, _positionRepository);

            if (!await userManager.IsInRoleAsync(employee, roleName))
            {
                var oldRoleName = (await userManager.GetRolesAsync(employee)).FirstOrDefault();
                if (!oldRoleName.IsNullOrEmpty())
                    await userManager.RemoveFromRoleAsync(employee, oldRoleName);
            }

            await userManager.AddToRoleAsync(employee, roleName);
        }

        public static string GetRoleName(
            Employee employee,
            IPositionRepository _positionRepository)
        {
            string? positionTitle = _positionRepository
                .GetByCondition(p => p.ID.Equals(employee.PositionID))
                .FirstOrDefault()?
                .Title;

            switch (positionTitle)
            {
                case PositionTitleConstants.HrManager:
                    return EmployeeRoles.Admin;

                case PositionTitleConstants.Recruiter:
                    return EmployeeRoles.HR;

                case PositionTitleConstants.SoftwareDeveloper:
                    return EmployeeRoles.User;

                default:
                    throw new NotImplementedException();
            }
        }

        public static async Task RemoveRole(
            Employee employee,
            UserManager<Employee> _userManager,
            IPositionRepository _positionRepository)
        {
            string roleName = GetRoleName(employee, _positionRepository);

            if (await _userManager.IsInRoleAsync(employee, roleName))
                await _userManager.RemoveFromRoleAsync(employee, roleName);

        }
    }
}

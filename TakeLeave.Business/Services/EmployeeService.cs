using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
using TakeLeave.Data.Database.Employees;
using TakeLeave.Data.Database.Positions;
using TakeLeave.Data.Interfaces;
using SeniorityLevel = TakeLeave.Business.Models.SeniorityLevel;

namespace TakeLeave.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly UserManager<Employee> _userManager;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IPositionRepository positionRepository,
            UserManager<Employee> userManager)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _userManager = userManager;
        }

        public List<EmployeeDTO>? EmployeeList()
        {
            List<Employee> employees = _employeeRepository.GetAll()
                .Include(e => e.DaysOff)
                .Include(e => e.Position)
                .ToList();

            List<EmployeeDTO> employeeDTOs = employees
                .Select(employee => employee.MapEmployeeToEmployeeDto())
                .ToList();

            return employeeDTOs;
        }

        public T? GetEmployeeById<T>(int id) where T : class
        {
            Employee? employee = _employeeRepository
                .GetByCondition(e => e.Id.Equals(id))
                .Include(e => e.DaysOff)
                .Include(e => e.Position)
                .FirstOrDefault();

            switch (typeof(T).Name)
            {
                case nameof(EmployeeDTO):
                    return employee?.MapEmployeeToEmployeeDto() as T;

                case nameof(EmployeeUpdateDTO):
                    return employee?.MapEmployeeToEmployeeUpdateDto() as T;

                default:
                    throw new NotSupportedException($"Type {typeof(T).Name} is not supported.");
            }
        }

        public Tuple<List<string>, List<string>> GetPositionTitlesAndSeniorityLevels()
        {
            List<Position> positions = _positionRepository.GetAll().ToList();

            List<string> positionTitles = positions.Select(title => title.Title).ToList();

            List<string> seniorityLevels = Enum.GetNames(typeof(SeniorityLevel)).ToList();

            return Tuple.Create(positionTitles, seniorityLevels);
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateDTO employeeUpdateDTO)
        {
            Employee? employee = await _employeeRepository
                .GetByCondition(e => e.Id.Equals(employeeUpdateDTO.Id))
                .Include(p => p.Position)
                .Include(d => d.DaysOff)
                .FirstOrDefaultAsync();

            employeeUpdateDTO.MapEmployeeUpdateDtoToEmployee(employee, _userManager);

            _employeeRepository.Update(employee);
            _employeeRepository.Save();

            await EmployeeHelper.AssignRole(employee, _userManager);
        }
    }
}

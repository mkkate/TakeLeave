using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Helpers;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
using TakeLeave.Data.Database.DaysOffs;
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
        private readonly IDaysOffRepository _daysOffRepository;
        private readonly UserManager<Employee> _userManager;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IPositionRepository positionRepository,
            IDaysOffRepository daysOffRepository,
            UserManager<Employee> userManager)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _daysOffRepository = daysOffRepository;
            _userManager = userManager;
        }

        public List<EmployeeInfoDTO>? EmployeeList()
        {
            List<Employee> employees = _employeeRepository.GetAll()
                .Include(e => e.DaysOff)
                .Include(e => e.Position)
                .ToList();

            List<EmployeeInfoDTO> employeeInfoDTOs = employees
                .Select(employee => employee.MapEmployeeToEmployeeInfoDto())
                .ToList();

            return employeeInfoDTOs;
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
                case nameof(EmployeeInfoDTO):
                    return employee?.MapEmployeeToEmployeeInfoDto() as T;

                case nameof(EmployeeDTO):
                    return employee?.MapEmployeeToEmployeeDto() as T;

                default:
                    throw new NotSupportedException($"Type {typeof(T).Name} is not supported.");
            }
        }

        public Tuple<HashSet<string>, List<string>> GetPositionTitlesAndSeniorityLevels()
        {
            List<Position> positions = _positionRepository.GetAll().ToList();

            HashSet<string> positionTitles = positions.Select(position => position.Title).ToHashSet();

            List<string> seniorityLevels = Enum.GetNames(typeof(SeniorityLevel)).ToList();

            return Tuple.Create(positionTitles, seniorityLevels);
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee? employee = await _employeeRepository
                .GetByCondition(e => e.Id.Equals(employeeDTO.Id))
                .Include(d => d.DaysOff)
                .FirstOrDefaultAsync();

            int positionId = _positionRepository.GetByCondition(position =>
                position.Title.Equals(employeeDTO.Position.Title) &&
                position.SeniorityLevel.Equals(Enum.Parse<Data.Database.Positions.SeniorityLevel>(employeeDTO.Position.SeniorityLevel)))
                .FirstOrDefault()
                .ID;

            employeeDTO.MapEmployeeDtoToEmployeeForUpdate(employee, _userManager, positionId);

            _employeeRepository.Update(employee);
            _employeeRepository.Save();

            await EmployeeHelper.AssignRole(employee, _userManager, _positionRepository);
        }

        public async Task CreateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee();

            int positionId = _positionRepository.GetByCondition(position =>
                position.Title.Equals(employeeDTO.Position.Title) &&
                position.SeniorityLevel.Equals(Enum.Parse<Data.Database.Positions.SeniorityLevel>(employeeDTO.Position.SeniorityLevel)))
                .FirstOrDefault()
                .ID;

            DaysOff daysOff = new DaysOff
            {
                Vacation = employeeDTO.DaysOff.Vacation,
                Paid = employeeDTO.DaysOff.Paid,
                Unpaid = employeeDTO.DaysOff.Unpaid,
                SickLeave = employeeDTO.DaysOff.SickLeave
            };

            _daysOffRepository.Insert(daysOff);
            _daysOffRepository.Save();

            employeeDTO.MapEmployeeDtoToEmployeeForCreate(employee, _userManager, positionId, daysOff.ID);

            _employeeRepository.Insert(employee);
            _employeeRepository.Save();

            await EmployeeHelper.AssignRole(employee, _userManager, _positionRepository);
        }
    }
}

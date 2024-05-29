using Microsoft.EntityFrameworkCore;
using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Mappers;
using TakeLeave.Business.Models;
using TakeLeave.Data.Interfaces;

namespace TakeLeave.Business.Services
{
    public class ChatService : IChatService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ChatService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeChatDTO> GetEmployeesChatList(int logedEmployeeId)
        {
            List<EmployeeChatDTO>? employeeChatDTOs = _employeeRepository
                .GetCurrentlyEmployedEmployees(logedEmployeeId)
                .Include(employee => employee.Position)
                .Select(employee => employee.MapEmployeeToEmployeeChatDto())
                .ToList();

            return employeeChatDTOs;
        }
    }
}

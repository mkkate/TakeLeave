using TakeLeave.Business.Interfaces;
using TakeLeave.Business.Services;
using TakeLeave.Data.Interfaces;
using TakeLeave.Data.Repositories;

namespace TakeLeave.Web
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IDaysOffRepository, DaysOffRepository>();
        }

        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}

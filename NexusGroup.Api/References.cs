using NexusGroup.Data.BaseData;
using NexusGroup.Data.Repositories.AccessLevels;
using NexusGroup.Data.Repositories.Auth;
using NexusGroup.Data.Repositories.Candidates;
using NexusGroup.Data.Repositories.Employees;
using NexusGroup.Data.Repositories.JobOffers;
using NexusGroup.Data.Repositories.Position;
using NexusGroup.Service.Services.AccessLevels;
using NexusGroup.Service.Services.Auth;
using NexusGroup.Service.Services.Candidates;
using NexusGroup.Service.Services.Employees;
using NexusGroup.Service.Services.JobOffers;
using NexusGroup.Service.Services.Position;
namespace NexusGroup.Api
{
    public static class References
    {
        public static void AddDapperConnection(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DapperConnection");
            services.AddTransient<IDapperContext, DapperContext>(m => new DapperContext(connection));
        }
        public static void AddAccessLevelsServices(IServiceCollection services) 
        {
            services.AddScoped<IAccessLevelsServices, AccessLevelsServices>();
            services.AddTransient<IAccessLevelsRepositories, AccessLevelsRepositories>();
        }
        public static void AddPositionService(IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionService>();
            services.AddTransient<IPositionRepositories, PositionRepositories>();
        }
        public static void AddJobOffersService(IServiceCollection services)
        {
            services.AddScoped<IJobOffersService, JobOffersService>();
            services.AddTransient<IJobOffersRepositories, JobOffersRepositories>();
        }
        public static void AddCandidatesService(IServiceCollection services)
        {
            services.AddScoped<ICandidatesService, CandidatesService>();
            services.AddTransient<ICandidatesRepositories, CandidatesRepositories>();
        }
        public static void AddAuthService(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IAuthRepositories, AuthRepositories>();
        }
        public static void AddEmployeeService(IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddTransient<IEmployeesRepositories, EmployeesRepositories>();
        }
    }
}

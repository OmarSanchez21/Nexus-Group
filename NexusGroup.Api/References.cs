using NexusGroup.Data.BaseData;
using NexusGroup.Data.Repositories.AccessLevels;
using NexusGroup.Data.Repositories.Auth;
using NexusGroup.Data.Repositories.Candidates;
using NexusGroup.Data.Repositories.Department;
using NexusGroup.Data.Repositories.Employees;
using NexusGroup.Data.Repositories.EmployeesPermission;
using NexusGroup.Data.Repositories.JobOffers;
using NexusGroup.Data.Repositories.OverTime;
using NexusGroup.Data.Repositories.PayRoll;
using NexusGroup.Data.Repositories.PerformanceReview;
using NexusGroup.Data.Repositories.Position;
using NexusGroup.Data.Repositories.Training;
using NexusGroup.Service.Base;
using NexusGroup.Service.Services.AccessLevels;
using NexusGroup.Service.Services.Auth;
using NexusGroup.Service.Services.Candidates;
using NexusGroup.Service.Services.Department;
using NexusGroup.Service.Services.Employees;
using NexusGroup.Service.Services.EmployeesPermission;
using NexusGroup.Service.Services.JobOffers;
using NexusGroup.Service.Services.OverTime;
using NexusGroup.Service.Services.PayRoll;
using NexusGroup.Service.Services.PerformanceReview;
using NexusGroup.Service.Services.Position;
using NexusGroup.Service.Services.Training;
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
        public static void AddCandidatesService(IServiceCollection services)
        {
            services.AddScoped<ICandidatesService, CandidatesService>();
            services.AddTransient<ICandidatesRepositories, CandidatesRepositories>();
        }
        public static void AddDepartmentService(IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddTransient<IDepartmentRepositories, DepartmentRepositories>();
        }
        public static void AddEmployeeService(IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddTransient<IEmployeesRepositories, EmployeesRepositories>();
        }
        public static void AddEmployeePermissionService(IServiceCollection services)
        {
            services.AddScoped<IEmployeesPermissionService, EmployeesPermissionService>();
            services.AddTransient<IEmployeesPermissionRepositories, EmployeesPermissionRepositories>();
        }
        public static void AddJobOffersService(IServiceCollection services)
        {
            services.AddScoped<IJobOffersService, JobOffersService>();
            services.AddTransient<IJobOffersRepositories, JobOffersRepositories>();
        }
        public static void AddOverTimeService(IServiceCollection services)
        {
            services.AddScoped<IOverTimeService, OverTimeService>();
            services.AddTransient<IOverTimeRepositories, OverTimeRepositories>();
        }
        public static void AddPayRollService(IServiceCollection services)
        {
            services.AddScoped<IPayRollService, PayRollService>();
            services.AddTransient<IPayRollRepositories, PayRollRepositories>();
        }
        public static void AddPerformanceReviewService(IServiceCollection services)
        {
            services.AddScoped<IPerformanceReviewService, PerformanceReviewService>();
            services.AddTransient<IPerformanceReviewRepositories, PerformanceReviewRepositories>();
        }
        public static void AddPositionService(IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionService>();
            services.AddTransient<IPositionRepositories, PositionRepositories>();
        }
        public static void AddTrainingService(IServiceCollection services)
        {
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddTransient<ITrainingRepositories, TrainingRepositories>();
        }
        public static void AddAuthService(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IAuthRepositories, AuthRepositories>();

            services.AddScoped<IJwtTokenHelper, JwtTokenHelper>();
        }
    }
}

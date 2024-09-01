using NexusGroup.Data.BaseData;
using NexusGroup.Data.Repositories.AccessLevels;
using NexusGroup.Data.Repositories.JobOffers;
using NexusGroup.Data.Repositories.Position;
using NexusGroup.Service.Services.AccessLevels;
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
    }
}

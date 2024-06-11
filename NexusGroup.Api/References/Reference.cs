using NexusGroup.Data.Base;
using NexusGroup.Data.Repositories.Positions;
using NexusGroup.Service.Services.Positions;

namespace NexusGroup.Api.References
{
    public static class Reference
    {
        public static void AddPositionDepedency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPositionsRepositories, PositionsRepositories>();
            services.AddScoped<iPositionsService, PositionsService>();
        }
        public static void AddDBDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDapperDBConnection, DapperDBConnection>(provider =>
            {
                return new DapperDBConnection(configuration);
            });
        }
    }
}

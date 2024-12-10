using Mellow.BL.Managers.Abstract;
using Mellow.BL.Managers.Concrete;

namespace Mellow.RazorPage.Extensions
{
    public static class MellowServices
    {
        public static IServiceCollection AddMellowServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IManager<>), typeof(Manager<>));
            return services;
        }
    }
}

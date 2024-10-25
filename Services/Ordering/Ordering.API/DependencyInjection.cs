using System.Runtime.CompilerServices;

namespace Ordering.API
{
    /// <summary>
    /// pengggunaan dependency injection classpada masing2 library karena:
    /// 1. pemisahan berdasarkan tanggungjawab
    /// 2. maintanability. mudah dimaintain jika ada keslalahan mudah tracking error 
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //services.AddCarter()
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            //app.MarterCarter()
            return app;
        }
    }
}

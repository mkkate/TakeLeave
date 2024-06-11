using TakeLeave.Business.CustomSettings;

namespace TakeLeave.Web
{
    public static class CustomSettings
    {
        public static void ConfigureCustomSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<EmailSettings>(builder.Configuration.GetSection(EmailSettings.Email));
        }
    }
}

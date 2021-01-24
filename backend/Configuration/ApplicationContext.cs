using Microsoft.Extensions.Configuration;
using Process_Homebroker;

namespace Configuration
{
    public static class ApplicationContext
    {
        public static T GetConfigurationValue<T>(string key)
        {
            return Startup.Configuration.GetValue<T>(key);
        }
    }
}
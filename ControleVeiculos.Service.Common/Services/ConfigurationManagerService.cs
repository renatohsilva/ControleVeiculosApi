using ControleVeiculos.Service.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ControleVeiculos.Service.Common.Services
{
    public class ConfigurationManagerService : IConfigurationManagerService
    {
        private readonly IConfiguration configuration;
        public ConfigurationManagerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetSetting(string key)
        {
            return configuration[key];
        }

        public string GetSecurityKey()
        {
            return GetSetting("IsDevelopEnvironment") == "true" ? GetSetting("SecurityKeyDev") : GetSetting("SecurityKey");
        }
    }
}

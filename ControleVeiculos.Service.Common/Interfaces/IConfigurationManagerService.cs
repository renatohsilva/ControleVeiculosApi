namespace ControleVeiculos.Service.Common.Interfaces
{
    public interface IConfigurationManagerService
    {
        string GetSetting(string key);
        string GetSecurityKey();
    }
}

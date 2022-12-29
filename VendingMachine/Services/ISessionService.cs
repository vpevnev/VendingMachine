namespace VendingMachine.Services
{
    public interface ISessionService
    {
        void SetString(string key, string value);

        string GetString(string key);
    }
}

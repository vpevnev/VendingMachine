using Microsoft.AspNetCore.Http;

namespace VendingMachine.Services
{
    public class SessionService : ISessionService
    {
        ISession Session { get; set; }

        public SessionService(ISession session)
        {
            Session = session;
        }

        public void SetString(string key, string value)
        {
            Session.SetString(key, value);
        }

        public string GetString(string key)
        {
            return Session.GetString(key);
        }
    }
}

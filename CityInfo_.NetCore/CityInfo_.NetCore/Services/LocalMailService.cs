using System.Diagnostics;

namespace CityInfo_.NetCore.Services
{
    class LocalMailService : IMailService
    {
        private string _mailMessageFrom = Startup.Configuration["mailSettings:mailFromAdress"];
        private string _mailMessageTo = Startup.Configuration["mailSettings:mailToAdress"];

        public void Send(string message)
        {
            Debug.WriteLine($"Local message - {message} - from {_mailMessageFrom} to {_mailMessageTo}");
        }
    }
}

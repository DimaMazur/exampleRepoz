using System.Diagnostics;

namespace CityInfo_.NetCore.Services
{
    class LocalMailService : IMailService
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Local message - {message}");
        }
    }
}

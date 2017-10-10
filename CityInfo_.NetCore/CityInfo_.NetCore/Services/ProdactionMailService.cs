using System.Diagnostics;

namespace CityInfo_.NetCore.Services
{
    class ProdactionMailService : IMailService
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Production message - {message}");
        }
    }
}

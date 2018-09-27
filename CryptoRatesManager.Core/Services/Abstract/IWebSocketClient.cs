namespace CryptoRatesManager.Core.Services.Abstract
{
    public interface IWebSocketClient
    {
        void Subscribe();

        void Unsubscribe();

        void ProcessData();
    }
}

using CryptoRatesManager.Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoRatesManager.Core.Providers
{
    public class MainWebSocketProvider
    {
        private readonly IEnumerable<IWebSocketClient> webSocketClients;
        private readonly int updateFrequency;
        private readonly ManualResetEvent manualResetEvent;
        private readonly IList<Task> tasks;

        public MainWebSocketProvider(IEnumerable<IWebSocketClient> webSocketClients, int updateFrequency)
        {
            this.webSocketClients = webSocketClients;
            this.updateFrequency = updateFrequency * 1000;
            this.manualResetEvent = new ManualResetEvent(false);
            this.manualResetEvent.Reset();
            this.tasks = new List<Task>();
        }

        public async void StartExecution()
        {
            foreach (IWebSocketClient webSocketClient in this.webSocketClients)
            {
                IWebSocketClient tempWebSocketClient = webSocketClient;
                Task task = Task.Factory.StartNew(() => this.ExecuteWebSocketClient(tempWebSocketClient), creationOptions: TaskCreationOptions.LongRunning);
                this.tasks.Add(task);
            }

            await Task.WhenAll(this.tasks);
        }

        public void StopExecution()
        {
            this.manualResetEvent.Set();
        }

        private void ExecuteWebSocketClient(IWebSocketClient client)
        {
            try
            {
                client.Subscribe();
                while (true)
                {
                    if (this.manualResetEvent.WaitOne(this.updateFrequency))
                    {
                        client.Unsubscribe();
                        return;
                    }

                    client.ProcessData();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}


using Azure.Identity;
using BlogApp.Hubs;
using EasyModbus;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
namespace BlogApp.Worker
{




    public class bgWorker : IHostedService
    {
        PeriodicTimer _periodicTimer;
        ModbusClient modbusClient;
        private readonly IHubContext<PlcOkuHub> _hubContext;


        public bgWorker(IHubContext<PlcOkuHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            modbusClient = new ModbusClient("127.0.0.1", 502);
            modbusClient.Connect();

            _periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            plcOku();

            Console.WriteLine("Worker Başladı");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Uygulama Bitti");
            return Task.CompletedTask;
        }


        public async void plcOku()
        {


            while (await _periodicTimer.WaitForNextTickAsync())
            {

                Console.WriteLine(modbusClient.ReadHoldingRegisters(0, 1)[0].ToString());
                await _hubContext.Clients.All.SendAsync("plcDegerAl", modbusClient.ReadHoldingRegisters(0, 1)[0]);

            }


        }
    }
}
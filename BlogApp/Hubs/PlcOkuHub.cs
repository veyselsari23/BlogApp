using Microsoft.AspNetCore.SignalR;

namespace BlogApp.Hubs{

    public class PlcOkuHub:Hub
    {



            public async Task Gonder(string message)
            {

                await Clients.All.SendAsync("al",message);
            }

    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TwinCityCoders.Sockets.TestMessage;

namespace TwinCityCoders.Sockets
{
    public class MainHub: Hub
    {

        private readonly ITestMessageCounter testMessageCounter;
        public MainHub(ITestMessageCounter _testMessageCounter)
        {
            testMessageCounter = _testMessageCounter;
        }


        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}

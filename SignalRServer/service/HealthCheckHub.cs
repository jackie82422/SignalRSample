namespace SignalRServer.service;
using Microsoft.AspNetCore.SignalR;

public class HealthCheckHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync(user, message);
    }
}
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient.service;

public class MessageClient
{
    private readonly HubConnection _hubConnection;
    
    public MessageClient(string connectionString)
    {
        _hubConnection = new HubConnectionBuilder().WithUrl(connectionString,
            options =>
            {
                options.WebSocketConfiguration = conf =>
                {
                    conf.RemoteCertificateValidationCallback = (_, _, _, _) => true;
                };
                options.HttpMessageHandlerFactory = factory => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
                options.AccessTokenProvider = () => Task.FromResult(new string(""))!;
            }).Build();
    }
    
    public async Task SendMessageAsync(string message)
    {
        if (_hubConnection.State != HubConnectionState.Connecting)
        {
            await _hubConnection.StartAsync();
        }

        await _hubConnection.SendAsync("SendMessage",message);
    }
}
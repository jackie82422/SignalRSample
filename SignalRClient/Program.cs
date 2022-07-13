// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello, World!");

var url = "http://localhost:8110/HealthCheck";
var hubConnection = new HubConnectionBuilder().WithUrl(url).Build();
hubConnection.On<string>("ReceiveMessage",message=> Console.WriteLine($"Server message : {message}"));
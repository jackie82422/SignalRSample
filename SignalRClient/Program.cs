// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;
using SignalRClient.service;


var url = "https://localhost:7208/HealthCheck";
var client = new MessageClient(url);
await client.SendMessageAsync("Test");


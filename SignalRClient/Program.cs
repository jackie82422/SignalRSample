// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;
using SignalRClient.service;


var url = "http://localhost:5179/HealthCheck";
var client = new MessageClient(url);
await client.SendMessageAsync("Test");


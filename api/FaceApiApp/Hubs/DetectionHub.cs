using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FaceApiApp.Hubs;

public class DetectionHub : Hub
{
    // Método que será chamado para notificar todos os clientes
    public async Task SendDetectionUpdate(string gender, int age, string imageBase64)
    {
        await Clients.All.SendAsync("ReceiveDetectionUpdate", gender, age, imageBase64);
    }
}
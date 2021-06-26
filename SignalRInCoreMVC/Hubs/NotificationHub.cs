using Microsoft.AspNetCore.SignalR;
using SignalRInCoreMVC.Interfaces;
using System.Threading.Tasks;

namespace SignalRInCoreMVC.Hubs
{
    //Stringlyt types Hub
    public class NotificationHub :Hub<INotificationHub>
    {
        /// <summary>
        /// Send message to all client
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task SendMessageToAll(string data)
        {
            await Clients.All.AllReceiveMessage(data);
        }

        /// <summary>
        /// Subscribe client to category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task SubscribeToCategory(string category)
        {
             await Groups.AddToGroupAsync(Context.ConnectionId, category);
        }

        /// <summary>
        /// send message to category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task  SendMessageToCategory(string category, string data)
        {
            await Clients.Group(category).CategoryReceiveMessage(data);
        }

        /// <summary>
        /// Unsubscribe 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task UnSubscribeFromCategory(string category)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, category);
        }

        /// <summary>
        /// GetConnectedResponse 
        /// </summary>
        /// <returns></returns>
        public async override Task OnConnectedAsync()
        {
           await Clients.All.GetConnectedResponse(Context.ConnectionId);
        }
    }
}

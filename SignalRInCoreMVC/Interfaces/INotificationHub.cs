using SignalRInCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRInCoreMVC.Interfaces
{
    public interface INotificationHub
    {
        /// <summary>
        /// Send message to all  client
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task AllReceiveMessage(string message);
        /// <summary>
        /// send message to category
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task CategoryReceiveMessage(string message);
        /// <summary>
        /// Sending connected response to client
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        Task GetConnectedResponse(string connectionId);
    }
}

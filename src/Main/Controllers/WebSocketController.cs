using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers
{
    public class WebSocketController : Controller
    {
        private NotificationsMessageHandler _notificationsMessageHandler { get; set; }

        public WebSocketController(NotificationsMessageHandler notificationsMessageHandler)
        {
            _notificationsMessageHandler = notificationsMessageHandler;
        }

        [HttpGet]
        public async Task SendMessage([FromQueryAttribute]string message)
        {
            await _notificationsMessageHandler.InvokeClientMethodToAllAsync("receiveMessage", message);
        }
    }
}

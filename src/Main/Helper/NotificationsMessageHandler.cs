using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Helper
{
    public class NotificationsMessageHandler : WebSocketHandler
    {
        public NotificationsMessageHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }
    }
}

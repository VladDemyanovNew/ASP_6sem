using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;

namespace Lab1a.Handlers
{
    public class WSHandler : WebSocketHandler
    {
        public WSHandler() { }

        public override void OnOpen()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            while (true)
            {
                base.Send(serializer.Serialize("Time now is: " + DateTime.Now));
                Thread.Sleep(2000);
            }
        }
    }
}
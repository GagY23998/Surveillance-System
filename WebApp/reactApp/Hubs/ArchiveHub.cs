using AppCore.Requests;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reactApp.Hubs
{
    public class ArchiveHub: Hub
    {

        public Task SendArchive(LogDTO log)
        {
            return Clients.All.SendAsync("RecieveLog", log);
        }
    }
}

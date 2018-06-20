using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.API.Services
{
    public class LocalMainService
    {

      private  string mailFrom = Startup.Configuration["MailSettings.mailFromToAddress"];


        public LocalMainService()
        {
        }

        public void Send(string subject, string message)
        {
           
        }
       
    }
}

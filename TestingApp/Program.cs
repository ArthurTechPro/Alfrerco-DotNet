using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Arkivujo.Alfresco.Authentication;
using Arkivujo.Alfresco.Authentication.Model;
using Arkivujo.Alfresco.Core;
using Arkivujo.Alfresco.Search;
using Arkivujo.Alfresco.Discovery;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string authBase = "https://localhost/alfresco/api/-default-/public/authentication/versions/1";
            const string coreBase = "https://localhost/alfresco/api/-default-/public/alfresco/versions/1";

            var authClient = new Arkivujo.Alfresco.Authentication.Client.ApiClient(authBase);
            var authApi = new Arkivujo.Alfresco.Authentication.Api.AuthenticationApi(authClient);
            
            Console.WriteLine("Logging into Alfresco...");
            var ticket = authApi.CreateTicket(new TicketBody(){Password = "admin", UserId = "admin"});
            var coreClient = new Arkivujo.Alfresco.Core.Client.ApiClient(coreBase);
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(ticket.Entry.Id);
            coreClient.AddDefaultHeader("Authorization", "Basic "+ System.Convert.ToBase64String(bytes));
            var peopleApi = new Arkivujo.Alfresco.Core.Api.PeopleApi(coreClient);
            Console.WriteLine("Querying for details on current user");
            var result = peopleApi.GetPerson("-me-", null);
            Console.WriteLine("================ User Details =================");
            Console.WriteLine(result);
            Console.WriteLine("===============================================");

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Prepper_Manager.Controller.API
{
    public class RequestEmail
    {
        public static void postEmailRequestToEmailAPI(List<Model.Food> expiringFoodsList)
        {
            if (expiringFoodsList == null || expiringFoodsList.Count <= 0) return;

            var subject = "You have expiring Food items this week!";
            var content = "The following " + expiringFoodsList.Count + " items of your Prepper food supplies will expire this week: " + Environment.NewLine;

            var count = 1;
            foreach (var food in expiringFoodsList)
            {
                content += count + ". " + food.name + " at location: " + food.location + "." + Environment.NewLine;
                count++;
            }
                
            var client = new RestClient("https://api.mailgun.net/v3")
            {
                Authenticator =
                    new HttpBasicAuthenticator("api", "fcbda4b095841c1c994cd271d998a81c-b892f62e-60e41d9f")
            };

            var request = new RestRequest();
            request.AddParameter("domain", "sandbox270f1ec19f674117a2d93ff6c0029753.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox270f1ec19f674117a2d93ff6c0029753.mailgun.org>");
            request.AddParameter("to", "Lloyd Niebel <lloyd.niebel@gmail.com>");
            request.AddParameter("subject", subject);
            request.AddParameter("text", content);
            request.Method = Method.POST;
            client.Execute(request);
        }

        public static void postEmailRequestToEmailAPIWithHTMLBody()
        {
            var subject = "You have expiring Food items this week!";

            var client = new RestClient("https://api.mailgun.net/v3")
            {
                Authenticator =
                    new HttpBasicAuthenticator("api", "fcbda4b095841c1c994cd271d998a81c-b892f62e-60e41d9f")
            };

            var mailPath = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"Resources\EmailTemplate\PreppyMailImageUrl.html"));

            var request = new RestRequest();
            request.AddParameter("domain", "sandbox270f1ec19f674117a2d93ff6c0029753.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox270f1ec19f674117a2d93ff6c0029753.mailgun.org>");
            request.AddParameter("to", "Lloyd Niebel <lloyd.niebel@gmail.com>");
            request.AddParameter("subject", subject);
            request.AddParameter("html", File.ReadAllText(mailPath));
            request.Method = Method.POST;
            client.Execute(request);
        }
    }
}


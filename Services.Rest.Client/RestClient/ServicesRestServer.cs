using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Services.Rest.Client.Models;

namespace Services.Rest.Client.RestClient
{
    public class ServicesRestServer
    {
        public ServicesRestServer()
        {
            Client = new HttpClient {BaseAddress = new Uri("http://localhost:53301/api/")};
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Client { get; set; }

        public IList<Cliente> GetClientesAnonimo()
        {
            var response = Client.GetAsync("clientes/BuscarAnonimo").Result;
            if (!response.IsSuccessStatusCode) return new List<Cliente>();
            var clientesJson = response.Content.ReadAsStringAsync();
            return new JavaScriptSerializer().Deserialize<IList<Cliente>>(clientesJson.Result);
        }
    }
}
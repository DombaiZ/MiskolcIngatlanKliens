using MiskolciIngatlanKliens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiskolcIngatlanKliens.Services
{
    internal class IngatlanService
    {
        public async static Task<List<Ingatlan>> GetAll(HttpClient client)
        {
            List<Ingatlan> result = await client.GetFromJsonAsync<List<Ingatlan>>("Ingatlan");
            if (result is not null)
            {
                return result;
            }
            else
            {
                return new List<Ingatlan>();
            }
        }

        public async static Task<string> InsterNew(HttpClient client, Ingatlan ujIngatlan)
        {
            string uj = JsonSerializer.Serialize(ujIngatlan, JsonSerializerOptions.Default);
            string url = $"{client.BaseAddress}Ingatlan";
            var request = new StringContent(uj, Encoding.UTF8 , "application/json") ;
            var response = await client.PostAsync(url, request);
            var valasz = await response.Content.ReadAsStringAsync();
            return valasz;
        }

        public async Task DeleteIngatlanAsync(int id, HttpClient client)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/ingatlanok/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateIngatlanAsync(int id, Ingatlan updatedIngatlan, HttpClient client)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/ingatlanok/{id}", updatedIngatlan);
            response.EnsureSuccessStatusCode();
        }

    }
}

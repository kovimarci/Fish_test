using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace fishCs
{
    public class ServerConnection
    {
        HttpClient client = new();
        public ServerConnection(string url)
        {
            client.BaseAddress = new Uri(url);
        }

        public async Task<List<Fish>> Get()
        {
            try
            {
                return JsonSerializer.Deserialize<List<Fish>>(await (await client.GetAsync("/fish")).EnsureSuccessStatusCode().Content.ReadAsStringAsync());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }

        public async Task<bool> Post(string type, double weight)
        {
            try
            {
                await client.PostAsync("/fish", new StringContent(JsonSerializer.Serialize(new Fish(default, type, weight)), Encoding.UTF8, "application/json"));
                return true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return false;
        }
    }
}
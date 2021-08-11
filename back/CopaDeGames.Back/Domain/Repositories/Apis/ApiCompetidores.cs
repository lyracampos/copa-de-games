using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;
using Newtonsoft.Json;

namespace CopaDeGames.Back.Domain.Repositories.Apis
{
    public class ApiCompetidores : IApiCompetidores
    {
        public string UrlApi => "https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games";

        public async Task<IEnumerable<Competidor>> BuscarCompetidores()
        {
            var httpClient = new HttpClient();
            var result = new List<Competidor> { };

            HttpResponseMessage response = await httpClient.GetAsync(UrlApi);
            if (response.IsSuccessStatusCode)
                result = JsonConvert.DeserializeObject<List<Competidor>>(response.Content.ReadAsStringAsync().Result);
            return result;
        }
    }
}
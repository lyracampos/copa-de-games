using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Repositories.Data;
using CopaDeGames.Back.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace CopaDeGames.Back.Tests.IntegratedTests
{
    public class CampeonatoControllerTests
    {
        protected readonly HttpClient httpClient;
        private readonly ICampeonatoRepository _campeonatoRepository;

        public CampeonatoControllerTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            httpClient = factory.CreateClient();

            _campeonatoRepository = new CampeonatoRepository(new CampeonatoDataContext());
        }

        [Fact]
        public async Task DeveIniciarUmCampeonato()
        {
            var request = new string[]
            {
                "/nintendo-64/the-legend-of-zelda-ocarina-of-time",
                "/dreamcast/soulcalibur",
                "/xbox-360/grand-theft-auto-iv",
                "/xbox-one/grand-theft-auto-v",
                "/playstation-3/grand-theft-auto-v",
                "/switch/the-legend-of-zelda-breath-of-the-wild",
                "/nintendo-64/perfect-dark",
                "/playstation-4/grand-theft-auto-v"
            };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/campeonato", content);
            response.EnsureSuccessStatusCode();

            CampeonatoResult result = new CampeonatoResult();
            if (response.IsSuccessStatusCode)
                result = JsonConvert.DeserializeObject<CampeonatoResult>(response.Content.ReadAsStringAsync().Result);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result.Campeao);
            Assert.NotNull(result.ViceCampeao);
        }
    }
}

using System.Collections.Generic;
using System.IO;
using CopaDeGames.Back.Domain.Entities;
using Newtonsoft.Json;

namespace CopaDeGames.Back.Tests.UnitTests.Mocks
{
    public static class MockCompetidores
    {
        public static List<Competidor> Competidores()
        {
            var pathJsonMock = Path.GetFullPath(@"../../../Mocks/competidores.json");
            var competidores = new List<Competidor>();

            using (StreamReader r = new StreamReader(pathJsonMock))
            {
                string json = r.ReadToEnd();
                 competidores = JsonConvert.DeserializeObject<List<Competidor>>(json);
            }
            return competidores;
        }
    }
}

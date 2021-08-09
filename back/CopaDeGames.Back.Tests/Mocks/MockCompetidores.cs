using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CopaDeGames.Back.Domain.Entities;
using Newtonsoft.Json;

namespace CopaDeGames.Back.Tests.Mocks
{
    public static class MockCompetidores
    {
        public static List<Competidor> Competidores()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "competidores.json");
            var competidores = new List<Competidor>();

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                 competidores = JsonConvert.DeserializeObject<List<Competidor>>(json);
            }

            // var p = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "competidores.json");
            //string jsonFile = p;
            //string json = File.ReadAllText(jsonFile);
           // var competidores =  JsonConvert.DeserializeObject<List<Competidor>>(json);

            return competidores;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace FPL_Track_Test.FPLAPI
{
    public class APICallers
    {
        

        public static GameWeek GetCurrentGameWeek()
        {
            List<GameWeek> gws = new List<GameWeek>();

            using (WebClient wc = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var json = wc.DownloadString(@"https://fantasy.premierleague.com/drf/events/");


                JObject jObj = JObject.Parse(@"{""gameweeks"": " + json + @"}");
                JToken jT = jObj["gameweeks"];
                gws = jT.ToObject<List<GameWeek>>();

            }

            return gws.Where(g => g.is_current).FirstOrDefault();
        }

        public List<Fixture> GetFixtures()
        {
            List<Fixture> gws = new List<Fixture>();

            using (WebClient wc = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var json = wc.DownloadString(@"https://fantasy.premierleague.com/drf/fixtures/");


                JObject jObj = JObject.Parse(@"{""fixtures"": " + json + @"}");
                JToken jT = jObj["fixtures"];
                gws = jT.ToObject<List<Fixture>>() ;

            }

            return gws;
        }

        public Player GetPlayer(int id)
        {
            Player p = new Player();
            List<Player> players = new List<Player>();

            string json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Data/0.json"));

            JObject jObj = JObject.Parse(json);
            JToken jT = jObj["elements"];
            players = jT.ToObject<List<Player>>();

            p = players.Where(pl => pl.id == id).FirstOrDefault();
            return p;
        }

        public List<Team> GetTeams()
        {
            string json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Data/0.json"));

            JObject jObj = JObject.Parse(json);
            JToken jT = jObj["teams"];
            return jT.ToObject<List<Team>>();
        }

        public static Team GetTeam(int id)
        {
            string json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Data/0.json"));

            JObject jObj = JObject.Parse(json);
            JToken jT = jObj["teams"];
            return jT.ToObject<List<Team>>().Where(t => t.code == id).FirstOrDefault();
        }

        public static Team GetTeamById(int id)
        {
            string json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Data/0.json"));

            JObject jObj = JObject.Parse(json);
            JToken jT = jObj["teams"];
            return jT.ToObject<List<Team>>().Where(t => t.id == id).FirstOrDefault();
        }
    }
}
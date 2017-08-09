using FPL_Track_Test.FPLAPI;
using FPL_Track_Test.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FPL_Track_Test.Controllers
{
    public class FPLAPIController : Controller
    {
        [HttpGet]
        public JsonResult GetFixturesForTeam(int id)
        {
            APICallers ac = new APICallers();
            int team_id = APICallers.GetTeam(id).id;

            List<Fixture> fixtures = ac.GetFixtures().Where(f => f.team_a == team_id || f.team_h == team_id).OrderBy(f => f.event_).ToList();
            fixtures.ForEach(f => f.player_team = team_id);


            return Json(fixtures, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetPlayersForScatterChart(int id)
        {
            List<Player> players = new List<Player>();
            List<ScatterChartSeriesItem> result = new List<ScatterChartSeriesItem>();

            string json = System.IO.File.ReadAllText(Server.MapPath(@"~/Data/0.json"));

            JObject jObj = JObject.Parse(json);
            JToken jT = jObj["elements"];
            players = jT.ToObject<List<Player>>();

            TeamColours tc = new TeamColours();
            
            foreach(Player p in players.Where(p => p.element_type == id))
            {
                ScatterChartSeriesItem s = new ScatterChartSeriesItem() {
                    name = p.web_name,
                    x = p.now_cost / 10,
                    y = p.total_points,
                    key = p.id.ToString(),
                    color = tc.GetTeamColourByCode(p.team_code).colour,
                    marker = new Dictionary<string, string>()
                };
                Debug.WriteLine(p.web_name + p.team_code);
                result.Add(s);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public JsonResult GetTeams()
        {
            APICallers ac = new APICallers();
            List<Team> teams = ac.GetTeams();
            return Json(teams, JsonRequestBehavior.AllowGet);
        }





    }
}
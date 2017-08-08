using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPL_Track_Test.FPLAPI;
using System.IO;
using FPL_Track_Test.Helpers;

namespace FPL_Track_Test.Controllers
{
    public class HomeController : Controller
    {
        string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public ActionResult Index()
        {
            GameWeek currentGameWeek = new GameWeek();
            currentGameWeek = APICallers.GetCurrentGameWeek();
            int gameWeekId = currentGameWeek == null ? 0 : currentGameWeek.id;

            Session["CurrentGameWeek"] = currentGameWeek == null ? "Pre-Season" : currentGameWeek.name;


            if (System.IO.File.Exists(@"Data\" + gameWeekId.ToString() + @".json"))
            {
                ViewBag.name = name;
            }
            else
            {
                ViewBag.name = "No data file";
            }

            ViewBag.name = name;
            return View();
        }

        public ActionResult Premium()
        {

            //List<Player> players = TeamStandings.GetBootStrapPlayerData();

            ViewBag.name = name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Player(int id)
        {
            APICallers ac = new APICallers();
            Player p = ac.GetPlayer(id);
            TeamColours tc = new TeamColours();

            int teamId = APICallers.GetTeam(p.team_code).id;
            ViewBag.teamcolour = tc.GetTeamColourById(teamId);
     
            return View(p);
        }
    }
}
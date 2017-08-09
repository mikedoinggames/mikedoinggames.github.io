using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace FPL_Track_Test.Helpers
{
    public class TeamColours
    {
        public int id;
        public string colour;
        public string textColour { get { return PerceivedBrightness(colour) > 200 ? "#222222" : "#f5f5f5" ; } }

        static TeamColours FromCsv(string line)
        {
            string[] vals = line.Split(',');
            TeamColours tc = new TeamColours();
            tc.id = Convert.ToInt32(vals[0]);
            tc.colour = vals[1];
            return tc;
        }

        public List<TeamColours> GetTeamColours()
        {
            List<TeamColours> tc = new List<TeamColours>();
            tc = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(@"~/Data/Static/TeamColours.csv")).Select(v => TeamColours.FromCsv(v)).ToList();
            return tc;
        }

        public TeamColours GetTeamColourById(int id)
        {
            List<TeamColours> tc = new List<TeamColours>();
            tc = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(@"~/Data/Static/TeamColours.csv")).Select(v => TeamColours.FromCsv(v)).ToList();
            return tc.Where(t => Convert.ToInt32(t.id) == id).FirstOrDefault();
        }
        public TeamColours GetTeamColourByCode(int id)
        {
            List<TeamColours> tc = new List<TeamColours>();
            tc = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(@"~/Data/Static/TeamColoursbycode.csv")).Select(v => TeamColours.FromCsv(v)).ToList();
            return tc.Where(t => Convert.ToInt32(t.id) == id).FirstOrDefault();
        }

        int PerceivedBrightness(string sc)
        {
            ColorConverter cc = new ColorConverter();
            Color c = (Color)cc.ConvertFromString(sc);
            return (int)Math.Sqrt(
            c.R * c.R * .299 +
            c.G * c.G * .587 +
            c.B * c.B * .114);
        }
    }
}
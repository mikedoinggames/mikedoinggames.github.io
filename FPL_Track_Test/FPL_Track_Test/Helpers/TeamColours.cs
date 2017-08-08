using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPL_Track_Test.Helpers
{
    public class TeamColours
    {
        public int id;
        public string colour;

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

        public string GetTeamColourById(int id)
        {
            List<TeamColours> tc = new List<TeamColours>();
            tc = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath(@"~/Data/Static/TeamColours.csv")).Select(v => TeamColours.FromCsv(v)).ToList();
            return tc.Where(t => Convert.ToInt32(t.id) == id).FirstOrDefault().colour;
        }
    }
}
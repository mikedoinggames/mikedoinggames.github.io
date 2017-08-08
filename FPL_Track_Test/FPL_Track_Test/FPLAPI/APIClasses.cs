using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace FPL_Track_Test.FPLAPI
{


    public class Player
    {
        public int id;
        public string photo;
        public string web_name;
        public int team_code;
        public string status;
        public string code;
        public string first_name;
        public string second_name;
        public string squad_number;
        public string news;
        public float now_cost;
        public string chance_of_playing_this_round;
        public string chance_of_playing_next_round;
        public string value_form;
        public string value_season;
        public string cost_change_start;
        public string cost_change_event;
        public string cost_change_start_fall;
        public string cost_change_event_fall;
        public string in_dreamteam;
        public string dreamteam_count;
        public string selected_by_percent;
        public string form;
        public string transfers_out;
        public string transfers_in;
        public string transfers_out_event;
        public string transfers_in_event;
        public string loans_in;
        public string loans_out;
        public string loaned_in;
        public string loaned_out;
        public int total_points;
        public string event_points;
        public string points_per_game;
        public string ep_this;
        public string ep_next;
        public string special;
        public string minutes;
        public string goals_scored;
        public string assists;
        public string clean_sheets;
        public string goals_conceded;
        public string own_goals;
        public string penalties_saved;
        public string penalties_missed;
        public string yellow_cards;
        public string red_cards;
        public string saves;
        public string bonus;
        public string bps;
        public string influence;
        public string creativity;
        public string threat;
        public string ict_index;
        public string ea_index;
        public int element_type;
        public string team;

        public string image_url
        {
            get { return @"https://platform-static-files.s3.amazonaws.com/premierleague/photos/players/110x140/p" + photo.Replace("jpg", "png"); }
        }
        public string team_name
        {
            get
            {
                return new APICallers().GetTeams().Where(t => t.code == team_code).FirstOrDefault().name;
            }
        }
        public float inGameCost { get { return now_cost / 10; } }
    }

    public class GameWeek
    {
        public int id;
        public string name;
        public DateTime deadline_time;
        public float average_entry_score;
        public bool finished;
        public bool data_checked;
        public int? highest_scoring_entry;
        public int deadline_time_epoch;
        public int deadline_time_game_offset;
        public string deadline_time_formatted;
        public int? highest_score;
        public bool is_previous;
        public bool is_current;
        public bool is_next;
    }

    public class Fixture
    {
        public int? id;
        [JsonProperty("event")]
        public int? event_;
        public int? team_a;
        public int? team_h;
        public int? team_h_difficulty;
        public int? team_a_difficulty;
        public int? player_team;

        public string team_h_name { get { return APICallers.GetTeamById((int)team_h).name; } }
        public string team_a_name { get { return APICallers.GetTeamById((int)team_a).name; } }
        public int difficulty
        {
            get
            {
                if (player_team == team_h)
                {
                    return Math.Abs( (int)team_h_difficulty );
                }
                else
                {
                    return Math.Abs((int)team_a_difficulty);
                }


            }
        }
    }


    public class Team
    {
        public int id;
        //public Fixture current_event_fixture;
        //public Fixture next_event_fixture;
        public string name;
        public int code;
        public string short_name;
        public bool unavailable;
        public int strength;
        public int position;
        public int played;
        public int win;
        public int loss;
        public int draw;
        public int points;
        public string form;
        public string link_url;
        public int strength_overall_home;
        public int strength_overall_away;
        public int strength_attack_home;
        public int strength_attack_away;
        public int strength_defence_home;
        public int strength_defence_away;
        public int team_division;
    }

}

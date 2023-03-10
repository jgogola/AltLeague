using AltLeague.Areas.League.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.CelebrityDeathPool.Models
{
    public class Player_Celebrity_Roster_Summary
    {
        public int player_league_key { get; set; } = 0;

        public int user_key { get; set; } = 0;

        public string full_name { get; set; } = "";

        public int number_of_celebrities { get; set; } = 0;
        public int average_age { get; set; } = 0;
        public int number_of_deaths { get; set; } = 0;
        public int total_points_won { get; set; } = 0;
        public string player_rank { get; set; } = "0";
        public int player_rank_int { get; set; } = 0;


        public int league_key { get; set; } = 0;
        public string league_title { get; set; } = "";

        public Boolean is_active_league { get; set; } = true;

        public DateTime league_start_date { get; set; } = new DateTime();

        public DateTime league_end_date { get; set; } = new DateTime();

        public Boolean dues_collected { get; set; } = false;

        public int number_of_players { get; set; } = 0;

    }
}

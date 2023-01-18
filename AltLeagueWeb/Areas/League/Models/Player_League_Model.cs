
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AltFuture.Areas.League.Models
{
    public class Player_League_Model
    {

        public int player_league_key { get; set; } = 0;

        public int user_key { get; set; } = 0;

        public int league_key { get; set; } = 0;


        public Boolean dues_collected { get; set; } = false;

        public DateTime? last_viewed_date { get; set; }

        public string player_rank { get; set; } = "";

        public string league_lead_player { get; set; } = "";

        [ValidateNever]
        public App_User_Model user { get; set; } = new App_User_Model();

        [ValidateNever]
        public League_Model league { get; set; } = new League_Model();


    }

  
}

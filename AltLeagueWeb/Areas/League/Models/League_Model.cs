using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.League.Models
{
    public class League_Model
    {
        public int league_key { get; set; } = 0;

        public int lk_league_type_key { get; set; } = 0;

        public string league_title { get; set; } = "";

        public string league_desc { get; set; } = "";

        public string payout_desc { get; set; } = "";

        [Display(Name="League Status")]
        public Boolean is_active_league { get; set; } = true;

        public DateTime? league_start_date { get; set; }

        public DateTime? league_end_date { get; set; }

        public string league_lead_player { get; set; } = "";

        public LK_League_Type_Model lk_league_type { get; set; } = new LK_League_Type_Model();

    }

}

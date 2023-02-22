namespace AltLeague.Areas.SurvivorPool.Models.ViewModels
{
    public class LeagueSummaryViewModel
    {
        public string league_title { get; set; } = "";
        public Boolean is_active_league { get; set; } = false;
        public DateTime? league_start_date { get; set; }
        public DateTime? league_end_date { get; set; }

        public int number_of_players { get; set; } = 0;
        public int number_of_contestants { get; set; } = 0;
        public int number_of_active_contestants { get; set; } = 0;
        public Boolean has_winner { get; set; } = false;
        public string winning_contestant { get; set; } = "";
        public string winning_player { get; set; } = "";
        public string next_episode_num_title { get; set; } = "";
        public DateTime? next_air_date { get; set; }

    }
}

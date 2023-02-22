namespace AltLeague.Areas.SurvivorPool.Models.ViewModels
{
    public class PlayerRosterViewModel
    {
        public int user_key { get; set; } 
        public int player_league_key { get; set; } 
        public int player_roster_key { get; set; } 
        public int contestant_key { get; set; } 

        public string full_name { get; set; } = "";
        public string contestant_name { get; set; } = "";

        public int age { get; set; } = 0;

        public Boolean is_voted_out { get; set; } = false;

        public Boolean is_winner { get; set; } = false;
        public int day_voted_out { get; set; } = 0;
        public int voted_out_placement { get; set; } = 0;
        public int placement { get; set; } = 0;
        public int jury_placement { get; set; } = 0;

        public string thumb_url { get; set; } = "";
        public string tribe_name { get; set; } = "";

        public string tribe_color { get; set; } = "";

        public string tribe_bg_color { get; set; } = "";
        public string tribe_name_merge { get; set; } = "";

        public string tribe_color_merge { get; set; } = "";

        public string tribe_bg_color_merge { get; set; } = "";
        public string final_episode { get; set; } = "";


    }
}

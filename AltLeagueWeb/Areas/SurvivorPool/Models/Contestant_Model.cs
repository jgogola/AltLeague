namespace AltLeague.Areas.SurvivorPool.Models
{
    public class Contestant_Model
    {
        public int contestant_key { get; set; }

        public int league_key { get; set; }

        public string contestant_name { get; set; } = String.Empty;
        public int age { get; set; } = 0;
        public int tribe_key_orig { get; set; } 
        public int tribe_key_merge { get; set; }
        public int voted_out_placement { get; set; } = 0;
        public int day_voted_out { get; set; } = 0;
        public int episode_key_final { get; set; }
        public Boolean is_voted_out { get; set; } = false;
        public Boolean is_winner { get; set; } = false;
        public int jury_placement { get; set; } = 0;
        public string photo_url { get; set; } = String.Empty;
        public string thumb_url { get; set; } = String.Empty;

    }
}

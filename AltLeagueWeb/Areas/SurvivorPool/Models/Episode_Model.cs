namespace AltLeague.Areas.SurvivorPool.Models
{
    public class Episode_Model
    {
        public int episode_key { get; set; } 
        public int league_key { get; set; } 

        public string episode_title { get; set; } = "";

        public int num_in_season { get; set; } = 0;

        public DateOnly? air_date { get; set; }

        public Boolean has_aired { get; set; } = false;

        public string episode_num_title { get; set; } = "";
    }
}

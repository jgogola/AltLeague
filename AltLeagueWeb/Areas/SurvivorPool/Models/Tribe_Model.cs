namespace AltLeague.Areas.SurvivorPool.Models
{
    public class Tribe_Model
    {
        public int tribe_key { get; set; } 

        public int league_key { get; set; } 

        public string tribe_name { get; set; } = "";

        public Boolean is_merge_tribe { get; set; } = false;
    }
}

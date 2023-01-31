 
namespace AltLeague.Areas.League.Models.ViewModels
{
    public class LeagueAndPlayersViewModel
    {

        public League_Model league { get; set; } = new League_Model();

        public List<Player_League_Model> player_leagues { get; set; } = new List<Player_League_Model>();


    }
}

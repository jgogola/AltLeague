using AltFuture.Areas.League.Models;
using AltFuture.Areas.League.Models.ViewModels;

namespace AltFuture.Areas.CelebrityDeathPool.Models.ViewModels
{
    public class LeagueAndCelebrityRosters
    {

        public League_CDP_ViewModel league_CDP = new League_CDP_ViewModel();

        public List<Player_Celebrity_Roster_Summary> player_roster_summaries = new List<Player_Celebrity_Roster_Summary>();

        public List<Player_Celebrity_Roster> player_rosters = new List<Player_Celebrity_Roster>();
    }
}

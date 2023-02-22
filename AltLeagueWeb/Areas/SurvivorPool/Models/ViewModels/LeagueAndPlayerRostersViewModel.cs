using AltLeague.Areas.SurvivorPool.Models;
using AltLeague.Areas.SurvivorPool.Models.ViewModels;
using AltLeague.Areas.SurvivorPool.Models.ViewModels;

namespace AltLeague.Areas.SurvivorPool.Models.ViewModels
{
    public class LeagueAndPlayerRostersViewModel
    {

        public LeagueSummaryViewModel leagueSummary = new LeagueSummaryViewModel();

        public List<PlayerRosterSummaryViewModel> playerRosterSummary = new List<PlayerRosterSummaryViewModel>();

        public List<PlayerRosterViewModel> playerRoster = new List<PlayerRosterViewModel>();
    }
}

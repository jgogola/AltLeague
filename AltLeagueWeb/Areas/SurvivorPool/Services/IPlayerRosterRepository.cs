using AltLeague.Areas.SurvivorPool.Models;
using AltLeague.Areas.SurvivorPool.Models.ViewModels;
using AltLeague.Areas.SurvivorPool.Models.ViewModels;

namespace AltLeague.Areas.SurvivorPool.Services
{
    public interface IPlayerRosterRepository : IDisposable
    {
        List<PlayerRosterSummaryViewModel> PlayerRosterGetListSummaryByUser(int user_key);

        List<PlayerRosterSummaryViewModel> PlayerRosterGetListSummary(int league_key, int user_key = 0);

        LeagueSummaryViewModel LeagueSummaryGet(int league_key);

        List<PlayerRosterViewModel> PlayerRosterGetList(int league_key, int user_key = 0);


    }
}

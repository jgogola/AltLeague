using AltLeague.Areas.League.Models;
using AltLeague.Areas.League.Models.ViewModels;

namespace AltLeague.Areas.League.Services
{
    public interface ILeagueRepository : IDisposable
    {
        League_Model LeagueGet(int league_key);

        List<League_Model> LeagueGetList(int lk_league_type_key = 0, int is_active_league = -1);

        League_CDP_ViewModel LeagueGetCDPSummary(int league_key);


    }
}

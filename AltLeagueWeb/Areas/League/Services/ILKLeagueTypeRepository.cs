using AltLeague.Areas.League.Models;

namespace AltLeague.Areas.League.Services
{
    public interface ILKLeagueTypeRepository : IDisposable
    {
        LK_League_Type_Model LKLeagueTypeGet(int lk_league_type_key);

        List<LK_League_Type_Model> LKLeagueTypeGetList();

     
    }
}

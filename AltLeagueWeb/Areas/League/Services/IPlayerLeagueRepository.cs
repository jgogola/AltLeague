using AltLeague.Areas.League.Models;

namespace AltLeague.Areas.League.Services
{
    public interface IPlayerLeagueRepository : IDisposable
    {
        Player_League_Model PlayerLeagueGet(int player_league_key);

        List<Player_League_Model> PlayerLeagueGetList(int user_key = 0, int lk_league_type_key = 0, int league_key = 0, int is_active_league = -1);

     
    }
}

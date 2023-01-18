using AltFuture.Areas.League.Models;

namespace AltFuture.Areas.League.Services
{
    public interface IPlayerLeagueRepository : IDisposable
    {
        Player_League_Model PlayerLeagueGet(int player_league_key);

        List<Player_League_Model> PlayerLeagueGetList(int user_key = 0, int league_key = 0, int is_active_league = -1);

     
    }
}

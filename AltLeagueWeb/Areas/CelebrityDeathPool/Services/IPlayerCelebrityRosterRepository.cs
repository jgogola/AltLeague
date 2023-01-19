using AltFuture.Areas.CelebrityDeathPool.Models;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public interface IPlayerCelebrityRosterRepository : IDisposable
    {
        Player_Celebrity_Roster PlayerCelebrityRosterGet(int player_celebrity_roster_key);

        List<Player_Celebrity_Roster> PlayerCelebrityGetListByPlayer(int competition_key, int user_key);

        List<Player_Celebrity_Roster> PlayerCelebrityGetListByCompetition(int competition_key);

        int PlayerCelebrityRosterAdd(Player_Celebrity_Roster player_celebrity_roster);

        int PlayerCelebrityRosterUpd(int player_celebrity_roster_key, Boolean is_winner);

        int PlayerCelebrityRosterDel(int player_celebrity_roster_key);


    }
}

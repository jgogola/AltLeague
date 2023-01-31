using AltLeague.Areas.League.Models;
using AltLeague.Areas.League.Services;
using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.League.Services
{
    public class PlayerLeagueRepository : IPlayerLeagueRepository
    {
        private readonly SQLService _db;
        public PlayerLeagueRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Player_League_Model PlayerLeagueGet(int player_league_key)
        {
            DataTable dt = _db.GetDT("leag.usp_Player_League_Get", new List<Object> { player_league_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
               
                App_User_Model user = new App_User_Model
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active_user = (Boolean)dr["is_active_user"]
                };

                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };

                League_Model league = new League_Model
                {
                    league_key = (int)dr["lk_league_type_key"],
                    league_title = (string)dr["league_title"],
                    league_desc = (string)dr["league_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = (DateTime)dr["league_start_date"],
                    league_end_date = (DateTime)dr["league_end_date"],
                    lk_league_type = lk_league_type
                    
                };

                Player_League_Model league_player = new Player_League_Model
                {
                    player_league_key = (int)dr["player_league_key"],
                    dues_collected = (Boolean)dr["dues_collected"],
                    last_viewed_date = Convert.IsDBNull(dr["last_viewed_date"]) ? null : (DateTime)dr["last_viewed_date"],
                    player_rank = (string)dr["player_rank"],
                    league_lead_player = (string)dr["league_lead_player"],
                    user = user,
                    league = league
                };

                return league_player;
            }

            return new Player_League_Model();
        }

        public List<Player_League_Model> PlayerLeagueGetList(int user_key = 0, int lk_league_type_key = 0,  int league_key  = 0, int is_active_league = -1)
        {
            DataTable dt = _db.GetDT("leag.usp_Player_League_Get_List", new List<Object> {user_key, lk_league_type_key, league_key, is_active_league});
            List<Player_League_Model> player_leagues = new List<Player_League_Model>();

            foreach (DataRow dr in dt.Rows)
            {

                App_User_Model user = new App_User_Model
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active_user = (Boolean)dr["is_active_user"]
                };

                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };

                League_Model league = new League_Model
                {
                    league_key = (int)dr["league_key"],
                    league_title = (string)dr["league_title"],
                    league_desc = (string)dr["league_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = (DateTime)dr["league_start_date"],
                    league_end_date = (DateTime)dr["league_end_date"],
                    lk_league_type = lk_league_type

                };

                Player_League_Model player_league = new Player_League_Model
                {
                    player_league_key = (int)dr["player_league_key"],
                    dues_collected = (Boolean)dr["dues_collected"],
                    last_viewed_date = Convert.IsDBNull(dr["last_viewed_date"]) ? null : (DateTime)dr["last_viewed_date"],
                    player_rank = (string)dr["player_rank"],
                    league_lead_player = (string)dr["league_lead_player"],
                    user = user,
                    league = league
                };

                player_leagues.Add(player_league);
            }

            return player_leagues;
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}

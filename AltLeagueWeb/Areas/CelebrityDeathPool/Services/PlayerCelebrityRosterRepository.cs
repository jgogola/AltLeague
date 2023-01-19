using AltFuture.Areas.League.Models;
using AltFuture.Areas.CelebrityDeathPool.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public class PlayerCelebrityRosterRepository : IPlayerCelebrityRosterRepository
    {
        private readonly SQLService _db;
        public PlayerCelebrityRosterRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Player_Celebrity_Roster PlayerCelebrityRosterGet(int player_celebrity_roster_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Player_Celebrity_Repository_Get", new List<object> { player_celebrity_roster_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                Celebrity celebrity = new Celebrity
                {
                    celebrity_key = (int)dr["celebrity_key"],
                    celebrity_name = (string)dr["celebrity_name"],
                    birth_date = (DateTime)dr["birth_date"],
                    death_date = Convert.IsDBNull(dr["death_date"]) ? null : (DateTime?)dr["death_date"],
                    is_dead = (bool)dr["is_dead"],
                    age = (int)dr["age"],
                    points = (int)dr["points"],
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],

                    lk_celebrity_type = lk_celebrity_type

                };


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
                    last_viewed_date = (DateTime)dr["last_viewed_date"],
                    user = user,
                    league = league
                };

                Player_Celebrity_Roster player_celebrity_roster = new Player_Celebrity_Roster
                {
                    player_celebrity_roster_key = (int)dr["player_celebrity_roster_key"],
                    league_key = (int)dr["league_key"],
                    player_league_key = (int)dr["player_league_key"],
                    celebrity_key = (int)dr["celebrity_key"],
                    is_winner = (Boolean)dr["is_winner"],
                    player_league = player_league,
                    celebrity = celebrity

                };

                return player_celebrity_roster;
            }

            return new Player_Celebrity_Roster();
        }

        public List<Player_Celebrity_Roster> PlayerCelebrityGetListByPlayer(int competition_key, int user_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Player_Celebrity_Get_List", new List<object> { competition_key, user_key });
            List<Player_Celebrity_Roster> player_celebrities = new List<Player_Celebrity_Roster>();

            foreach (DataRow dr in dt.Rows)
            {


                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                Celebrity celebrity = new Celebrity
                {
                    celebrity_key = (int)dr["celebrity_key"],
                    celebrity_name = (string)dr["celebrity_name"],
                    birth_date = (DateTime)dr["birth_date"],
                    death_date = Convert.IsDBNull(dr["death_date"]) ? null : (DateTime?)dr["death_date"],
                    is_dead = (bool)dr["is_dead"],
                    age = (int)dr["age"],
                    points = (int)dr["points"],
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],

                    lk_celebrity_type = lk_celebrity_type

                };


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
                    league_key = (int)dr["lleague_key"],
                    league_title = (string)dr["league_title"],
                    league_desc = (string)dr["league_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active_league = (Boolean)dr["is_active_competition"],
                    league_start_date = (DateTime)dr["league_start_date"],
                    league_end_date = (DateTime)dr["league_end_date"],
                    lk_league_type = lk_league_type

                };

                Player_League_Model player_league = new Player_League_Model
                {
                    player_league_key = (int)dr["player_league_key"],
                    dues_collected = (Boolean)dr["dues_collected"],
                    last_viewed_date = Convert.IsDBNull(dr["last_viewed_date"]) ? null : (DateTime?)dr["last_viewed_date"],
                    user = user,
                    league = league
                };

                Player_Celebrity_Roster player_celebrity = new Player_Celebrity_Roster
                {
                    player_celebrity_key = (int)dr["player_celebrity_key"],
                    league_key = (int)dr["league_key"],
                    player_league_key = (int)dr["player_league_key"],
                    celebrity_key = (int)dr["celebrity_key"],
                    is_winner = (Boolean)dr["is_winner"],
                    player_league = player_league,
                    celebrity = celebrity

                };

                player_celebrities.Add(player_celebrity);
            }

            return player_celebrities;
        }

        public List<Player_Celebrity_Roster> PlayerCelebrityGetListByCompetition(int competition_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Player_Celebrity_Get_List", new List<object> { competition_key, 0 });
            List<Player_Celebrity_Roster> player_celebrities = new List<Player_Celebrity_Roster>();

            foreach (DataRow dr in dt.Rows)
            {


                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                Celebrity celebrity = new Celebrity
                {
                    celebrity_key = (int)dr["celebrity_key"],
                    celebrity_name = (string)dr["celebrity_name"],
                    birth_date = (DateTime)dr["birth_date"],
                    death_date = Convert.IsDBNull(dr["death_date"]) ? null : (DateTime?)dr["death_date"],
                    is_dead = (bool)dr["is_dead"],
                    age = (int)dr["age"],
                    points = (int)dr["points"],
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],

                    lk_celebrity_type = lk_celebrity_type

                };


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
                    last_viewed_date = (DateTime)dr["last_viewed_date"],
                    user = user,
                    league = league
                };

                Player_Celebrity_Roster player_celebrity = new Player_Celebrity_Roster
                {
                    player_celebrity_key = (int)dr["player_celebrity_key"],
                    league_key = (int)dr["league_key"],
                    player_league_key = (int)dr["player_league_key"],
                    celebrity_key = (int)dr["celebrity_key"],
                    is_winner = (Boolean)dr["is_winner"],
                    player_league = player_league,
                    celebrity = celebrity

                };

                player_celebrities.Add(player_celebrity);
            }

            return player_celebrities;
        }


        public int PlayerCelebrityRosterAdd(Player_Celebrity_Roster player_celebrity_roster)
        {
            return _db.GetRetVal("cdp.usp_Player_Celebrity_Roster_Add",
                                    new() {
                                        player_celebrity_roster.league_key,
                                        player_celebrity_roster.player_league_key,
                                        player_celebrity_roster.celebrity_key,
                                        player_celebrity_roster.is_winner 
                                    }
                                );
        }

        public int PlayerCelebrityRosterUpd(int player_celebrity_roster_key, Boolean is_winner)
        {
            return _db.GetRetVal("cdp.usp_Player_Celebrity_Roster_Upd",
                                    new() {
                                        player_celebrity_roster_key,
                                        is_winner
                                    }
                                );
        }

        public int PlayerCelebrityRosterDel(int player_celebrity_roster_key)
        {
            return _db.GetRetVal("cdp.usp_Player_Celebrity_Roster_Del",
                                    new() {
                                        player_celebrity_roster_key
                                    }
                                );
        }

        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}

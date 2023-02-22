using AltLeague.Areas.SurvivorPool.Models.ViewModels;

namespace AltLeague.Areas.SurvivorPool.Services
{
    public class PlayerRosterRepository : IPlayerRosterRepository
    {
        private readonly SQLService _db;

        public PlayerRosterRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;

        }

        public List<PlayerRosterSummaryViewModel> PlayerRosterGetListSummaryByUser(int user_key)
        {
            DataTable dt = _db.GetDT("surv.usp_Player_Roster_Get_List_Summary_by_User", new() { user_key });
            List<PlayerRosterSummaryViewModel> rosterSummaries = new List<PlayerRosterSummaryViewModel>();

            foreach (DataRow dr in dt.Rows)
            {


                PlayerRosterSummaryViewModel rosterSummary = new PlayerRosterSummaryViewModel
                {
                    player_league_key = (int)dr["player_league_key"],
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    league_key = (int)dr["league_key"],
                    league_title = (string)dr["league_title"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = Convert.IsDBNull(dr["league_start_date"]) ? null : (DateTime)dr["league_start_date"],
                    league_end_date = Convert.IsDBNull(dr["league_end_date"]) ? null : (DateTime)dr["league_end_date"],

                    has_winner = (Boolean)dr["has_winner"],
                    winning_contestant = (string)dr["winning_contestant"],
                    winning_player = (string)dr["winning_player"],

                    number_of_contestants = (int)dr["number_of_contestants"],
                    number_of_active_contestants = (int)dr["number_of_active_contestants"],
                    next_episode_num_title = (string)dr["next_episode_num_title"],
                    next_air_date = Convert.IsDBNull(dr["next_air_date"]) ? null : (DateTime)dr["next_air_date"],

                    player_rank = (string)dr["player_rank"],
                    player_rank_int = (int)dr["player_rank_int"],
                    number_of_players = (int)dr["number_of_players"]

                };

                rosterSummaries.Add(rosterSummary);
            }

            return rosterSummaries;
        }


        public List<PlayerRosterSummaryViewModel> PlayerRosterGetListSummary(int league_key, int user_key = 0)
        {
            DataTable dt = _db.GetDT("surv.usp_Player_Roster_Get_List_Summary", new() { league_key, user_key });
            List<PlayerRosterSummaryViewModel> rosterSummaries = new List<PlayerRosterSummaryViewModel>();

            foreach (DataRow dr in dt.Rows)
            {


                PlayerRosterSummaryViewModel rosterSummary = new PlayerRosterSummaryViewModel
                {
                    player_league_key = (int)dr["player_league_key"],
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    league_key = (int)dr["league_key"],

                    is_active_league = (Boolean)dr["is_active_league"],

                    number_of_contestants = (int)dr["number_of_contestants"],
                    number_of_active_contestants = (int)dr["number_of_active_contestants"],

                    player_rank = (string)dr["player_rank"],
                    player_rank_int = (int)dr["player_rank_int"],

                };

                rosterSummaries.Add(rosterSummary);
            }

            return rosterSummaries;
        }


        public LeagueSummaryViewModel LeagueSummaryGet(int league_key)
        {
            DataTable dt = _db.GetDT("surv.usp_League_Get_Summary", new() { league_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                LeagueSummaryViewModel leagueSummary = new LeagueSummaryViewModel
                {
                    league_title = (string)dr["league_title"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = Convert.IsDBNull(dr["league_start_date"]) ? null : (DateTime)dr["league_start_date"],
                    league_end_date = Convert.IsDBNull(dr["league_end_date"]) ? null : (DateTime)dr["league_end_date"],
                    number_of_players = (int)dr["number_of_players"],
                    number_of_contestants = (int)dr["number_of_contestants"],
                    number_of_active_contestants = (int)dr["number_of_active_contestants"],
                    has_winner = (Boolean)dr["has_winner"],
                    winning_contestant = (string)dr["winning_contestant"],
                    winning_player = (string)dr["winning_player"],
                    next_episode_num_title = (string)dr["next_episode_num_title"],
                    next_air_date = Convert.IsDBNull(dr["next_air_date"]) ? null : (DateTime)dr["next_air_date"]

                };

                return leagueSummary;
            }



            return new LeagueSummaryViewModel();
        }


        public List<PlayerRosterViewModel> PlayerRosterGetList(int league_key, int user_key = 0)
        {
            DataTable dt = _db.GetDT("surv.usp_Player_Roster_Get_List", new() { league_key, user_key });
            List<PlayerRosterViewModel> playerRosters = new List<PlayerRosterViewModel>();

            foreach (DataRow dr in dt.Rows)
            {


                PlayerRosterViewModel playerRoster = new PlayerRosterViewModel
                {
                    
                    user_key = (int)dr["user_key"],
                    player_league_key = (int)dr["player_league_key"],
                    player_roster_key = (int)dr["player_roster_key"],
                    contestant_key = (int)dr["contestant_key"],
                    full_name = (string)dr["full_name"],
                    contestant_name = (string)dr["contestant_name"],
                    age = (int)dr["age"],
                    is_voted_out = (Boolean)dr["is_voted_out"],
                    is_winner = (Boolean)dr["is_winner"],
                    day_voted_out = (int)dr["day_voted_out"],
                    voted_out_placement = (int)dr["voted_out_placement"],
                    placement = (int)dr["placement"],
                    jury_placement = (int)dr["jury_placement"],
                    thumb_url = (string)dr["thumb_url"],
                    tribe_name = (string)dr["tribe_name"],
                    tribe_color = (string)dr["tribe_color"],
                    tribe_bg_color = (string)dr["tribe_bg_color"],
                    tribe_name_merge = (string)dr["tribe_name_merge"],
                    tribe_color_merge = (string)dr["tribe_color_merge"],
                    tribe_bg_color_merge = (string)dr["tribe_bg_color_merge"],
                    final_episode = (string)dr["final_episode"],

                };

                playerRosters.Add(playerRoster);
            }

            return playerRosters;
        }


        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }

    }
}

using AltLeague.Areas.League.Models;
using AltLeague.Areas.League.Models.ViewModels;
using AltLeague.Areas.League.Services;
using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.League.Services
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly SQLService _db;
        public LeagueRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public League_Model LeagueGet(int league_key)
        {
            DataTable dt = _db.GetDT("leag.usp_League_Get", new List<Object> { league_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };

                League_Model league = new League_Model
                {
                    league_key = (int)dr["copmetition_key"],
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_title = (string)dr["league_title"],
                    league_desc = (string)dr["league_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = Convert.IsDBNull(dr["league_start_date"]) ? null : (DateTime)dr["league_start_date"],
                    league_end_date =  Convert.IsDBNull(dr["league_end_date"]) ? null : (DateTime)dr["league_end_date"],
                    league_lead_player = (string)dr["league_lead_player"],
                    lk_league_type = lk_league_type
                    
                };           

                return league;
            }

            return new League_Model();
        }

        public List<League_Model> LeagueGetList(int lk_league_type_key = 0, int is_active_league = -1)
        {
            DataTable dt = _db.GetDT("leag.usp_League_Get_List", new List<Object> { lk_league_type_key, is_active_league });
            List<League_Model> leagues = new List<League_Model>();

            foreach (DataRow dr in dt.Rows)
            {

                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };

                League_Model league = new League_Model
                {
                    league_key = (int)dr["copmetition_key"],
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_title = (string)dr["league_title"],
                    league_desc = (string)dr["league_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = Convert.IsDBNull(dr["league_start_date"]) ? null : (DateTime)dr["league_start_date"],
                    league_end_date = Convert.IsDBNull(dr["league_end_date"]) ? null : (DateTime)dr["league_end_date"],
                    league_lead_player = (string)dr["league_lead_player"],
                    lk_league_type = lk_league_type

                };

                leagues.Add(league);
            }

            return leagues;
        }


        public League_CDP_ViewModel LeagueGetCDPSummary(int league_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_League_Get_CDP_Summary", new List<Object> { league_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };

                League_Model league = new League_Model
                {
                    league_key = (int)dr["league_key"],
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_title = (string)dr["league_title"],
                    league_desc = (string)dr["league_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active_league = (Boolean)dr["is_active_league"],
                    league_start_date = Convert.IsDBNull(dr["league_start_date"]) ? null : (DateTime)dr["league_start_date"],
                    league_end_date = Convert.IsDBNull(dr["league_end_date"]) ? null : (DateTime)dr["league_end_date"],
                    league_lead_player = (string)dr["league_lead_player"],
                    lk_league_type = lk_league_type

                };

                League_CDP_ViewModel league_cdp = new League_CDP_ViewModel
                {
                    league = league,
                    number_of_players = (int)dr["number_of_players"],
                    number_of_celebrities = (int)dr["number_of_celebrities"],
                    average_age = (int)dr["average_age"],
                    total_points_available = (int)dr["total_points_available"],
                    number_of_deaths = (int)dr["number_of_deaths"],
                    total_points_won = (int)dr["total_points_won"],
                };

                return league_cdp;
            }

            return new League_CDP_ViewModel();
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}

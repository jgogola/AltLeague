using AltLeague.Areas.League.Models;
using AltLeague.Areas.League.Services;
using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.League.Services
{
    public class LKLeagueTypeRepository : ILKLeagueTypeRepository
    {
        private readonly SQLService _db;
        public LKLeagueTypeRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public LK_League_Type_Model LKLeagueTypeGet(int lk_league_type_key)
        {
            DataTable dt = _db.GetDT("leag.usp_LK_League_Type_Get", new List<Object> { lk_league_type_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };           

                return lk_league_type;
            }

            return new LK_League_Type_Model();
        }

        public List<LK_League_Type_Model> LKLeagueTypeGetList()
        {
            DataTable dt = _db.GetDT("leag.usp_LK_League_Type_Get_List");
            List<LK_League_Type_Model> lk_league_types = new List<LK_League_Type_Model>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_League_Type_Model lk_league_type = new LK_League_Type_Model
                {
                    lk_league_type_key = (int)dr["lk_league_type_key"],
                    league_type = (string)dr["league_type"]
                };

                lk_league_types.Add(lk_league_type);
            }

            return lk_league_types;
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}

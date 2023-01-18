using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.League.Models
{
    public class LK_League_Type_Model
    {
        public int lk_league_type_key { get; set; } = 0;
        public string league_type { get; set; } = "";

    }

    public enum League_Type_Enum
    {
        [Display(Name = "Football Pool")]
        Football_Pool = 1,
        [Display(Name = "Survivor Pool")]
        Survivor_Pool = 2,
        [Display(Name = "Celebrity Death Pool")]
        Celebrity_Death_Pool = 3
    };
}

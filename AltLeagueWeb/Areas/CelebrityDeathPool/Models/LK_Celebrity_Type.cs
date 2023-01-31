using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.CelebrityDeathPool.Models
{
    public class LK_Celebrity_Type
    {

        public int lk_celebrity_type_key { get; set; }

        [Required]
        [Display(Name = "Celebrity Type")]
        public string celebrity_type { get; set; } = "";

    }
}

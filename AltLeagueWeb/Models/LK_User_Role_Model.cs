
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Models
{
    public class LK_User_Role_Model
    {
        public int lk_user_role_key { get; set; } = 0;

        public string user_role { get; set; } = "";

    }

    public enum User_Roles
    {
        [Display(Name = "Site Admin")]
        Site_Admin = 1,
        [Display(Name = "League Admin")]
        League_Admin = 2,
        [Display(Name = "League Player")]
        League_Player = 3
    };
}

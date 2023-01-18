using AltFuture.Areas.League.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Models
{
    public class Player_Celebrity
    {
        public int player_celebrity_key { get; set; } = 0;

        [Required]
        [Display(Name = "League")]
        public int league_key { get; set; } = 0;

        [Required]
        [Display(Name = "Player")]
        public int player_league_key { get; set; } = 0;

        [Required]
        [Display(Name = "Celebrity")]
        public int celebrity_key { get; set; } = 0;

        public bool is_winner { get; set; } = false;

        [ValidateNever]
        public Player_League_Model player_league { get; set; } = new Player_League_Model();

        [ValidateNever]
        public Celebrity celebrity { get; set; } = new Celebrity();


    }
}

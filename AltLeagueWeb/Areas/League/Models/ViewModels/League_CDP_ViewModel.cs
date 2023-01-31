using System.ComponentModel.DataAnnotations;

namespace AltLeague.Areas.League.Models.ViewModels
{
    public class League_CDP_ViewModel
    {
        public League_Model league { get; set; } = new League_Model();

        [Display(Name = "Number of Players")]
        public int number_of_players { get; set; } = 0;

        public int number_of_celebrities { get; set; } = 0;

        public int average_age { get; set; } = 0;

        public int total_points_available { get; set; } = 0;

        public int number_of_deaths { get; set; } = 0;

        public int total_points_won { get; set; } = 0;

       



    }
}

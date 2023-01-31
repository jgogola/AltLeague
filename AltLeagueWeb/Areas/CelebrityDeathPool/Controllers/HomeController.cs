using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AltLeague.Areas.CelebrityDeathPool.Models.ViewModels;
using AltLeague.Areas.CelebrityDeathPool.Models;
using AltLeague.Areas.CelebrityDeathPool.Services;

namespace AltLeagueWeb.Areas.CelebrityDeathPool.Controllers
{
    [Area("CelebrityDeathPool")]
    [Authorize]
    [Authorize(Policy = "LeaguePlayerPolicy")]
    public class HomeController : Controller
    {
        private PlayerCelebrityRosterRepository _playerCelebrityRepository;


        public HomeController(
            IPlayerCelebrityRosterRepository playerCelebrityRepository
        )
        {
            _playerCelebrityRepository = (PlayerCelebrityRosterRepository)playerCelebrityRepository;
        }



        // GET: CelebrityController
        public ActionResult Index()
        {

            List<Player_Celebrity_Roster_Summary> player_roster_summeries = _playerCelebrityRepository.PlayerCelebrityRosterGetListSummaryByUser(User.UserKey());


            return View(player_roster_summeries);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AltLeague.Areas.SurvivorPool.Models.ViewModels;
using AltLeague.Areas.SurvivorPool.Services;


namespace AltLeague.Areas.SurvivorPool.Controllers
{
    [Area("SurvivorPool")]
    [Authorize]
    [Authorize(Policy = "LeaguePlayerPolicy")]
    public class HomeController : Controller
    {
        private PlayerRosterRepository _playerRosterRepository;

        public HomeController (IPlayerRosterRepository playerRosterRepository)
        {
            _playerRosterRepository = (PlayerRosterRepository)playerRosterRepository;
        }

        public IActionResult Index()
        {
            List<PlayerRosterSummaryViewModel> playerRosterSummeries = _playerRosterRepository.PlayerRosterGetListSummaryByUser(User.UserKey());


            return View(playerRosterSummeries);
        }
    }
}

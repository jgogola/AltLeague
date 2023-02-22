using AltLeague.Areas.CelebrityDeathPool.Models.ViewModels;
using AltLeague.Areas.SurvivorPool.Models.ViewModels;
using AltLeague.Areas.SurvivorPool.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AltLeagueWeb.Areas.SurvivorPool.Controllers
{

    [Area("SurvivorPool")]
    [Authorize]
    [Authorize(Policy = "LeaguePlayerPolicy")]
    public class LeagueMatchup : Controller
    {
        private PlayerRosterRepository _playerRosterRepository;
        public LeagueMatchup(IPlayerRosterRepository playerRosterRepository)
        {
            _playerRosterRepository = (PlayerRosterRepository)playerRosterRepository;
        }

        public IActionResult Index(int id)
        {
            LeagueSummaryViewModel leagueSummary = _playerRosterRepository.LeagueSummaryGet(id);
            List<PlayerRosterSummaryViewModel> playerRosterSummary = _playerRosterRepository.PlayerRosterGetListSummary(id,0);
            List<PlayerRosterViewModel> playerRoster = _playerRosterRepository.PlayerRosterGetList(id,0);

            LeagueAndPlayerRostersViewModel LeagueAndPlayerRosters = new LeagueAndPlayerRostersViewModel
            {
                leagueSummary = leagueSummary,
                playerRosterSummary = playerRosterSummary,
                playerRoster = playerRoster

            };

            return View(LeagueAndPlayerRosters);

        }

    }
}

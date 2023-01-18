using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltFuture.Areas.League.Services;
using AltFuture.Areas.League.Models;
using AltFuture.Areas.League.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AltFutureWeb.Areas.Competitions.Controllers
{
    [Area("League")]
    [Authorize]
    [Authorize(Policy = "LeaguePlayerPolicy")]
    public class HomeController : AltFuture.Controllers.BaseController
    {

        private LKLeagueTypeRepository _lkLeagueTypeRepository;
        private LeagueRepository _leagueRepository;
        private PlayerLeagueRepository _playerLeagueRepository;


        public HomeController(
            // ILogger<HomeController> logger,
            IConfiguration configuration,
            ISQLService sqlService,
            ILKLeagueTypeRepository lkLeagueTypeRepository,
            ILeagueRepository leagueRepository,
            IPlayerLeagueRepository playerLeagueRepository
            ) : base(configuration, sqlService)
        {
            //  _logger = logger;
            _lkLeagueTypeRepository = (LKLeagueTypeRepository)lkLeagueTypeRepository;
            _leagueRepository = (LeagueRepository)leagueRepository;
            _playerLeagueRepository = (PlayerLeagueRepository)playerLeagueRepository;
           
        }

        public ActionResult Index()
        {

            List<Player_League_Model> player_leagues = _playerLeagueRepository.PlayerLeagueGetList(User.UserKey(), 0, -1);
            return View(player_leagues);
        }

        
    }
}

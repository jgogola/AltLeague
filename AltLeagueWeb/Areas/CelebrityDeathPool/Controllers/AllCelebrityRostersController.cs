 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AltFuture.Areas.CelebrityDeathPool.Models;
using AltFuture.Areas.CelebrityDeathPool.Models.ViewModels;
using AltFuture.Areas.CelebrityDeathPool.Services;

namespace AltFuture.Areas.CelebrityDeathPool.Controllers
{
    [Area("CelebrityDeathPool")]
    [Authorize]
    [Authorize(Policy = "LeaguePlayerPolicy")]
    public class AllCelebrityRostersController : Controller
    {
        // private readonly IHttpContextAccessor _contextAccessor;

        private PlayerCelebrityRosterRepository  _playerCelebrityRepository;
        private League.Services.LeagueRepository _leagueRepository;


        public AllCelebrityRostersController(
            IPlayerCelebrityRosterRepository playerCelebrityRepository,
            League.Services.ILeagueRepository  leagueRepository
        )
        {
            _playerCelebrityRepository = (PlayerCelebrityRosterRepository)playerCelebrityRepository;
            _leagueRepository = (League.Services.LeagueRepository)leagueRepository;
        }



        // GET: CelebrityController
        public ActionResult Index(int id)
        {
            League.Models.ViewModels.League_CDP_ViewModel league_CDP = _leagueRepository.LeagueGetCDPSummary(id);
            List<Player_Celebrity_Roster_Summary> player_roster_summeries = _playerCelebrityRepository.PlayerCelebrityRosterGetListSummary(id, 0);
            List<Player_Celebrity_Roster> player_rosters = _playerCelebrityRepository.PlayerCelebrityRosterGetList(id, 0);
            LeagueAndCelebrityRosters leagueAndCelebrityRostesr = new LeagueAndCelebrityRosters
            {
                league_CDP = league_CDP,
                player_roster_summaries = player_roster_summeries,
                player_rosters = player_rosters

            };
            return View(leagueAndCelebrityRostesr);
        }

        //// GET: CelebrityController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: CelebrityController/Create
        //public ActionResult Create()
        //{
        //    ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
        //    return View();
        //}

        //// POST: CelebrityController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Celebrity celebrity)
        //{
        //    bool is_success = true;
        //    string userMsg = "";

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            int new_key = _celebrityRepository.CelebrityAdd(celebrity);
        //            userMsg = $"{celebrity.celebrity_name} was successfully added.";
        //        }
        //        catch
        //        {
        //            is_success = false;
        //            userMsg = "Save Canceled: Issue with saving to database.";
        //        }
        //    }
        //    else
        //    {
        //        is_success = false;
        //        userMsg = "Save Canceled: Please review your entries below.";
        //    }

        //    ViewBag.UserMsg = userMsg;

        //    if (is_success)
        //    {
        //        TempData["CelebrityUserMsg"] = $"{celebrity.celebrity_name} was successfully added.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
        //        return View(celebrity);
        //    }

        //}

        //// GET: CelebrityController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    Celebrity celebrity = _celebrityRepository.CelebrityGet(id);
        //    ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
        //    return View(celebrity);
        //}

        //// POST: CelebrityController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Celebrity celebrity)
        //{
        //    bool is_success = true;
        //    string userMsg = "";

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _celebrityRepository.CelebrityUpd(celebrity);
        //            userMsg = $"{celebrity.celebrity_name} was successfully added.";
        //        }
        //        catch
        //        {
        //            is_success = false;
        //            userMsg = "Save Canceled: Issue with saving to database.";
        //        }
        //    }
        //    else
        //    {
        //        is_success = false;
        //        userMsg = "Save Canceled: Please review your entries below.";
        //    }

        //    ViewBag.UserMsg = userMsg;

        //    if (is_success)
        //    {
        //        TempData["CelebrityUserMsg"] = $"{celebrity.celebrity_name} was successfully updated.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
        //        return View(celebrity);
        //    }

        //}

        //// GET: CelebrityController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CelebrityController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

     
    }
}

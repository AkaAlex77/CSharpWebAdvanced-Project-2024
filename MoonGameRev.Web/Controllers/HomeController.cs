﻿namespace MoonGameRev.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Web.ViewModels.Home;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IGameService gameService;

        public HomeController(IGameService gameService)
        {
           this.gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve last five upcoming games
            IEnumerable<IndexViewModel> upcomingGamesViewModel =
               await this.gameService.LastFiveUpcomingGamesAsync();

            // Retrieve last five trending games
            IEnumerable<IndexViewModel> trendingGamesViewModel =
               await this.gameService.LastFiveGamesAsync();

            // Pass the view models to the view
            ViewData["UpcomingGames"] = upcomingGamesViewModel;
            ViewData["TrendingGames"] = trendingGamesViewModel;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

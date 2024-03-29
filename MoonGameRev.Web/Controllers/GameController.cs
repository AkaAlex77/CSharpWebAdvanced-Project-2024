﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data.Models.Game;
using MoonGameRev.Web.ViewModels.Game;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGenreService genreService;
        private readonly IGameService gameService;

        public GameController(IGenreService genreService, IGameService gameService)
        {
            this.genreService = genreService;
            this.gameService = gameService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllGamesQueryModel queryModel)
        {
            AllGamesFilteredAndPagedServiceModel serviceModel =
                await this.gameService.AllAsync(queryModel);

            queryModel.Games = serviceModel.Games;
            queryModel.TotalGames = serviceModel.TotalGamesCount;
            queryModel.Genres = await this.genreService.AllGenresNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {


            GameFormModel formModel = new GameFormModel()
            {
                Genres = await this.genreService.AllGenresAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameFormModel model)
        {
            if (model.GenreIds == null || !model.GenreIds.Any())
            {
                ModelState.AddModelError(nameof(model.GenreIds), "Please select at least one genre!");
            }
            else
            {
                // Check if all selected genre IDs exist
                foreach (int genreId in model.GenreIds)
                {
                    bool genreExist = await this.genreService.ExistsByIdAsync(genreId);
                    if (!genreExist)
                    {
                        ModelState.AddModelError(nameof(model.GenreIds), $"Selected genre with ID {genreId} does not exist!");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await this.gameService.CreateAsync(model);
                    return RedirectToAction("Games", "Game");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An unexpected error occurred while trying to add a new game!");
                }
            }

            // If the model state is not valid, retrieve the genres again
            model.Genres = await this.genreService.AllGenresAsync();
            return View(model);
        }
    }
}

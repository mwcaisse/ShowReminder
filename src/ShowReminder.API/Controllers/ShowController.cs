﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShowReminder.API.Manager;
using ShowReminder.API.Models;
using ShowReminder.API.ViewModel;
using ShowReminder.Data;
using ShowReminder.TMDBFetcher.Model;
using ShowReminder.TMDBFetcher.Model.Search;
using ShowReminder.TMDBFetcher.Model.TV;
using ShowReminder.TVDBFetcher.Model.Authentication;

namespace ShowReminder.API.Controllers
{

    [Route("api/show")]
    public class ShowController : Controller
    {

        private readonly ShowManager _showManager;

        private readonly TMDBFetcher.Manager.ShowManager _tmdbShowManager;

        public ShowController(IOptions<AuthenticationParam> optionsAccessor, IOptions<TMDBSettings> settingsAccessor)
        {
            _showManager = new ShowManager(optionsAccessor.Value);
            _tmdbShowManager = new TMDBFetcher.Manager.ShowManager(settingsAccessor.Value);
        }

        [HttpGet]
        [Route("search")]
        public JsonResponse<IEnumerable<Show>> Search(string terms)
        {
            return new JsonResponse<IEnumerable<Show>>()
            {
                Data = _showManager.Search(terms),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("test/search")]
        public JsonResponse<SearchResult> TestSearch(string terms)
        {
            return new JsonResponse<SearchResult>()
            {
                Data = _tmdbShowManager.Search(terms),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("test/{id:int}")]
        public JsonResponse<TVShow> TestGet(int id)
        {
            return new JsonResponse<TVShow>()
            {
                Data = _tmdbShowManager.GetShow(id),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("test/{id:int}/next")]
        public JsonResponse<TVEpisode> TestNextEpisode(int id)
        {
            return new JsonResponse<TVEpisode>()
            {
                Data = _tmdbShowManager.GetNextEpisode(id),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("test/{id:int}/last")]
        public JsonResponse<TVEpisode> TestLastEpisode(int id)
        {
            return new JsonResponse<TVEpisode>()
            {
                Data = _tmdbShowManager.GetLastEpisode(id),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResponse<Show> Get(int id)
        {
            return new JsonResponse<Show>()
            {
                Data = _showManager.GetShow(id),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("{id}/episodes")]
        public JsonResponse<IEnumerable<Episode>> GetEpisodes(int id)
        {
            return new JsonResponse<IEnumerable<Episode>>()
            {
                Data = _showManager.GetAllEpisodesForShow(id),
                ErrorMessage = null
            };
        }

        [HttpGet]
        [Route("{id}/nextlast")]
        public JsonResponse<ShowNextLast> GetWithNextLast(int id)
        {
            return new JsonResponse<ShowNextLast>()
            {
                Data = _showManager.GetShowWithNextLast(id),
                ErrorMessage = null
            };
        }
    }
}

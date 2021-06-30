﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowReminder.TMDBFetcher.Model.TV;
using ShowReminder.TVDBFetcher.Model.Series;
using ShowReminder.Web.Models;


namespace ShowReminder.Web.Mapper
{
    public static class EpisodeMapper
    {

        public static Episode ToModel(this BasicEpisode episode)
        {
            return new Episode()
            {
                OverallNumber = episode.AbsoluteNumber,
                SeasonNumber = episode.AiredSeason,
                EpisodeNumber = episode.AiredEpisodeNumber,
                AirDate = episode.FirstAired,
                Name = episode.EpisodeName,
                Overview = episode.Overview
            };
        }

        public static IEnumerable<Episode> ToModel(this IEnumerable<BasicEpisode> episodes)
        {
            return episodes.Select(x => x.ToModel());
        }

        public static Episode ToModel(this TVEpisode episode)
        {
            return new Episode()
            {
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.EpisodeNumber,
                AirDate = episode.AirDate,
                Name = episode.Name,
                Overview = episode.Overview
            };
        }

        public static IEnumerable<Episode> ToModel(this IEnumerable<TVEpisode> episodes)
        {
            return episodes.Select(x => x.ToModel());
        }

    }
}
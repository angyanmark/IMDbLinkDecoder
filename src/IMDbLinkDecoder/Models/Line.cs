using IMDbLinkDecoder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbLinkDecoder.Models
{
    public class Line
    {
        private readonly char[] digits = "0123456789".ToCharArray();
        private readonly string dateFormat = "yyyy-MM-dd";

        private string Text { get; }

        public Line(string line)
        {
            Text = line;
        }

        public async Task<string> GetOutputAsync(OutputOptions options, int filmCount)
        {
            var id = GetId();

            if (string.IsNullOrWhiteSpace(id))
            {
                return string.Empty;
            }

            var findContainer = await TMDbService.FindAsync(id);

            var elements = new List<string>();

            var link = GetLink();

            if (options.Counter)
            {
                elements.Add(filmCount.ToString());
            }

            if (findContainer.MovieResults.Any())
            {
                var searchMovie = findContainer.MovieResults.First();

                if (options.Title)
                {
                    elements.Add(searchMovie.Title);
                }
                if (options.Date)
                {
                    elements.Add(searchMovie.ReleaseDate.Value.ToString(dateFormat));
                }
                if (options.TMDb)
                {
                    elements.Add(searchMovie.VoteAverage.ToString());
                }
                if (options.Link)
                {
                    elements.Add(link);
                }
            }
            else if (findContainer.TvResults.Any())
            {
                var searchTv = findContainer.TvResults.First();

                if (options.Title)
                {
                    elements.Add(searchTv.Name);
                }
                if (options.Date)
                {
                    elements.Add(searchTv.FirstAirDate.Value.ToString(dateFormat));
                }
                if (options.TMDb)
                {
                    elements.Add(searchTv.VoteAverage.ToString());
                }
                if (options.Link)
                {
                    elements.Add(link);
                }
            }
            else if (findContainer.TvEpisode.Any())
            {
                var searchTvEpisode = findContainer.TvEpisode.First();

                if (options.Title)
                {
                    elements.Add(searchTvEpisode.Name);
                }
                if (options.Date)
                {
                    elements.Add(searchTvEpisode.AirDate.Value.ToString(dateFormat));
                }
                if (options.TMDb)
                {
                    elements.Add(searchTvEpisode.VoteAverage.ToString());
                }
                if (options.Link)
                {
                    elements.Add(link);
                }
            }
            else if (findContainer.PersonResults.Any())
            {
                var findPerson = findContainer.PersonResults.First();

                if (options.Title)
                {
                    elements.Add(findPerson.Name);
                }
                if (options.Date)
                {
                    elements.Add(findPerson.Gender.ToString());
                }
                if (options.TMDb)
                {
                    elements.Add(findPerson.KnownForDepartment);
                }
                if (options.Link)
                {
                    elements.Add(link);
                }
            }
            else if (findContainer.TvSeason.Any())
            {
                var findTvPerson = findContainer.TvSeason.First();

                if (options.Title)
                {
                    elements.Add(findTvPerson.Name);
                }
                if (options.Date)
                {
                    elements.Add(findTvPerson.AirDate.Value.ToString(dateFormat));
                }
                if (options.TMDb)
                {
                    elements.Add(findTvPerson.SeasonNumber.ToString());
                }
                if (options.Link)
                {
                    elements.Add(link);
                }
            }
            else
            {
                elements.Add($"Not found on TMDb: {link}");
            }

            return $"{string.Join(options.Separator, elements)}{Environment.NewLine}";
        }

        private string GetId() =>
            GetIdPretag() + GetIdDigits();

        private string GetIdPretag()
        {
            var idStartIndex = Text.IndexOfAny(digits) - 2;
            try
            {
                var pretag = Text.Substring(idStartIndex, 2);
                return pretag;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        private string GetIdDigits()
        {
            var idStartIndex = Text.IndexOfAny(digits);
            try
            {
                var idDigits = Text.Substring(idStartIndex, 7);
                return idDigits;
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Empty;
            }
        }

        private string GetLink()
        {
            var id = GetId();
            return id.Length == 9
                ? $"imdb.com/{GetLinkPretag()}/{id}/"
                : Text;
        }

        private string GetLinkPretag()
        {
            var idPretag = GetIdPretag();
            switch (idPretag)
            {
                case "tt":
                    return "title";
                case "nm":
                    return "name";
                default:
                    return string.Empty;
            }
        }
    }
}

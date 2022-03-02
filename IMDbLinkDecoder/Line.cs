using IMDbLinkDecoder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDbLinkDecoder
{
    public class Line
    {
        private readonly char[] digits = "0123456789".ToCharArray();
        private readonly string dateFormat = "yyyy-MM-dd";

        public Line(string line)
        {
            Text = line;
        }

        private string Text { get; }

        private string IdPretag
        {
            get
            {
                int idStartIndex = Text.IndexOfAny(digits) - 2;
                try
                {
                    string pretag = Text.Substring(idStartIndex, 2);
                    return pretag;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        private string IdDigits
        {
            get
            {
                int idStartIndex = Text.IndexOfAny(digits);
                try
                {
                    string idDigits = Text.Substring(idStartIndex, 7);
                    return idDigits;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        private string Id => IdPretag + IdDigits;

        private string Link
        {
            get
            {
                if (Id.Length == 9)
                {
                    return $"imdb.com/{LinkPretag}/{Id}/";
                }
                else
                {
                    return Text;
                }
            }
        }

        private string LinkPretag
        {
            get
            {
                switch (IdPretag)
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

        public async Task<string> GetOutputAsync(OutputOptions options, int filmCount)
        {
            var findContainer = await TMDbService.FindAsync(Id);

            var elements = new List<string>();

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
                    elements.Add(Link);
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
                    elements.Add(Link);
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
                    elements.Add(Link);
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
                    elements.Add(Link);
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
                    elements.Add(Link);
                }
            }
            else
            {
                elements.Add($"Not found on TMDb: {Link}");
            }

            return $"{string.Join(options.Separator, elements)}{Environment.NewLine}";
        }
    }
}

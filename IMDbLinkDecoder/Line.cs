using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDbLinkDecoder
{
    class Line
    {
        private readonly char[] digits = "0123456789".ToCharArray();

        public Line(string line)
        {
            Text = line;
        }

        public string Text { get; }

        public string IdPretag
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

        public string IdDigits
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

        public string Id => IdPretag + IdDigits;

        public string Link
        {
            get
            {
                if (Id.Length == 9)
                {
                    return "imdb.com/" + LinkPretag + "/" + Id + "/";
                }
                else
                {
                    return Text;
                }
            }
        }

        public string LinkPretag
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
            Film f = await TMDbService.GetFilmByIdAsync(Id);

            List<string> elements = new List<string>();

            if (options.Counter)
            {
                elements.Add(filmCount.ToString());
            }

            if(f == null || (
                f.movie_results.Count == 0 &&
                f.tv_results.Count == 0 &&
                f.tv_episode_results.Count == 0 &&
                f.person_results.Count == 0 &&
                f.tv_season_results.Count == 0 ))
            {
                elements.Add("Not found on TMDb: " + Link);
            }
            else if (f.movie_results.Count > 0)
            {
                Movie_Results mr = f.movie_results[0];

                if (options.Title)
                {
                    elements.Add(mr.title);
                }
                if (options.Date)
                {
                    elements.Add(mr.release_date);
                }
                if (options.TMDb)
                {
                    elements.Add(mr.vote_average.ToString());
                }
                if (options.Link)
                {
                    elements.Add(Link);
                }
            }
            else if (f.tv_results.Count > 0)
            {
                Tv_Results tr = f.tv_results[0];

                if (options.Title)
                {
                    elements.Add(tr.name);
                }
                if (options.Date)
                {
                    elements.Add(tr.first_air_date);
                }
                if (options.TMDb)
                {
                    elements.Add(tr.vote_average.ToString());
                }
                if (options.Link)
                {
                    elements.Add(Link);
                }
            }
            else if (f.tv_episode_results.Count > 0)
            {
                Tv_Episode_Results ter = f.tv_episode_results[0];

                if (options.Title)
                {
                    elements.Add(ter.name);
                }
                if (options.Date)
                {
                    elements.Add(ter.air_date);
                }
                if (options.TMDb)
                {
                    elements.Add(ter.vote_average.ToString());
                }
                if (options.Link)
                {
                    elements.Add(Link);
                }
            }
            else if (f.person_results.Count > 0)
            {
                Person_Results pr = f.person_results[0];

                if (options.Title)
                {
                    elements.Add(pr.name);
                }
                if (options.Date)
                {
                    elements.Add(pr.known_for_department);
                }
                if (options.Link)
                {
                    elements.Add(Link);
                }
            }
            else if (f.tv_season_results.Count > 0)
            {
                if (options.Link)
                {
                    elements.Add(Link);
                }
            }

            return string.Join(options.Separator, elements) + Environment.NewLine;
        }
    }
}

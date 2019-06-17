using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDbLinkDecoder
{

    public class Film
    {
        public List<Movie_Results> movie_results { get; set; }
        public List<Person_Results> person_results { get; set; }
        public List<Tv_Results> tv_results { get; set; }
        public List<Tv_Episode_Results> tv_episode_results { get; set; }
        public List<object> tv_season_results { get; set; }
    }

    public class Movie_Results
    {
        public int id { get; set; }
        public bool video { get; set; }
        public int vote_count { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public string release_date { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public float popularity { get; set; }
    }

    public class Tv_Results
    {
        public string original_name { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int vote_count { get; set; }
        public float vote_average { get; set; }
        public string first_air_date { get; set; }
        public string poster_path { get; set; }
        public List<int> genre_ids { get; set; }
        public string original_language { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public List<string> origin_country { get; set; }
        public float popularity { get; set; }
    }

    public class Tv_Episode_Results
    {
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string production_code { get; set; }
        public int season_number { get; set; }
        public int show_id { get; set; }
        public string still_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Person_Results
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public List<Known_For> known_for { get; set; }
        public string known_for_department { get; set; }
        public string profile_path { get; set; }
        public float popularity { get; set; }
    }

    public class Known_For
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public float popularity { get; set; }
        public string media_type { get; set; }
    }

}

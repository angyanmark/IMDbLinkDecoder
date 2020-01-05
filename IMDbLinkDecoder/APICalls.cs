using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDbLinkDecoder
{
    class APICalls
    {
        private static readonly string API_KEY = "5e9bcb638329a15acf75c1b2d85ae67e";

        private static RestClient client = new RestClient("https://api.themoviedb.org/3");

        public static Film GetFilmById(string id)
        {
            Film data = new Film();

            RestRequest request = new RestRequest("/find/{external_id}");

            request.AddParameter("api_key", API_KEY);
            request.AddParameter("language", "en-US");
            request.AddParameter("external_source", "imdb_id");
            request.AddUrlSegment("external_id", id);

            var result = client.Execute<Film>(request).Data;

            if (result != null)
            {
                data = result;
            }

            return data;
        }
    }
}

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
        private static readonly string ApiKey = "5e9bcb638329a15acf75c1b2d85ae67e";

        private static readonly RestClient Client = new RestClient("https://api.themoviedb.org/3");

        public static Film GetFilmById(string id)
        {
            RestRequest request = new RestRequest("/find/{external_id}");

            request.AddParameter("api_key", ApiKey);
            request.AddParameter("language", "en-US");
            request.AddParameter("external_source", "imdb_id");
            request.AddUrlSegment("external_id", id);

            return Client.Execute<Film>(request).Data;
        }
    }
}

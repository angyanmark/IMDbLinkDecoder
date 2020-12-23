using RestSharp;
using System.Threading.Tasks;

namespace IMDbLinkDecoder
{
    public static class TMDbService
    {
        private static readonly string ApiKey = "5e9bcb638329a15acf75c1b2d85ae67e";

        private static readonly RestClient Client = new RestClient("https://api.themoviedb.org/3");

        public static async Task<Film> GetFilmByIdAsync(string id)
        {
            RestRequest request = new RestRequest("/find/{external_id}");
            request.AddParameter("api_key", ApiKey);
            request.AddParameter("language", "en-US");
            request.AddParameter("external_source", "imdb_id");
            request.AddUrlSegment("external_id", id);

            return await Client.GetAsync<Film>(request);
        }
    }
}

using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.Find;

namespace IMDbLinkDecoder.Services
{
    public static class TMDbService
    {
        private static readonly TMDbClient client = new TMDbClient("5e9bcb638329a15acf75c1b2d85ae67e");

        public static async Task<FindContainer> FindAsync(string id) =>
            await client.FindAsync(FindExternalSource.Imdb, id);
    }
}

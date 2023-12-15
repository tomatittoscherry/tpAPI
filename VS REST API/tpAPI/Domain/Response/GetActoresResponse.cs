using System.IO;
using System.Text.Json.Serialization;

namespace tpAPI.Domain.Response
{
    public class GetActoresResponse
    {
        public List<Entities.Actores>? Actores { get; set; }

        [JsonPropertyName("total_actores")]

        public int Total { get; set; }
    }
}

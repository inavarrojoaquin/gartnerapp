using Newtonsoft.Json;

namespace Domain.DTOs
{
    public class SoftwareAdviceItemDTO
    {
        [JsonProperty("categories")]
        public List<string> Tags { get; set; }

        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }
    }
}
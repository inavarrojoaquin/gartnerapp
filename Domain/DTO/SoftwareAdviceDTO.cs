using Newtonsoft.Json;

namespace Domain.DTOs
{
    public class SoftwareAdviceDTO
    {
        [JsonProperty("products")]
        public List<SoftwareAdviceItemDTO> Products { get; set; }
    }
}
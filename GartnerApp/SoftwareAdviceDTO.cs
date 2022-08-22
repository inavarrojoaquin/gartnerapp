using Newtonsoft.Json;

public class SoftwareAdviceDTO
{
    [JsonProperty("products")]
    public List<SoftwareAdviceItemDTO> Products { get; set; }
}
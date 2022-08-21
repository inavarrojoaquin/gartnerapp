using Newtonsoft.Json;

public class SoftwareAdvice
{
    [JsonProperty("products")]
    public List<SoftwareAdviceItem> Products { get; set; }
}
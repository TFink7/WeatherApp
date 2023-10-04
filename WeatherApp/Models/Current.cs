using Newtonsoft.Json;
public class Current
{
    [JsonProperty("last_updated")]
    public string? LastUpdated { get; set; }

    [JsonProperty("temp_c")]
    public double? TempC { get; set; }
    public int? Humidity { get; set; }
    public int? Cloud { get; set; }

    [JsonProperty("feelslike_c")]
    public double? FeelsLikeC { get; set; }
}
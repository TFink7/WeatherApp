using Newtonsoft.Json;
public class Location
{
    public string? Name { get; set; }
    public string? Region { get; set; }
    public string? Country { get; set; }
    public double? Lat { get; set; }
    public double? Lon { get; set; }

    [JsonProperty("tz_id")]
    public string? TzId { get; set; }

    [JsonProperty("localtime_epoch")]
    public long? LocaltimeEpoch { get; set; }

    public string? Localtime { get; set; }
}

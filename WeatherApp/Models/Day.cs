using Newtonsoft.Json;
public class Day
{
    [JsonProperty("maxtemp_c")]
    public double? MaxTempC { get; set; }

    [JsonProperty("mintemp_c")]
    public double? MinTempC { get; set; }

    [JsonProperty("totalsnow_cm")]
    public double? TotalSnowCm { get; set; }

    [JsonProperty("daily_will_it_rain")]
    public int? DailyWillItRain { get; set; }

    [JsonProperty("daily_will_it_snow")]
    public int? DailyWillItSnow { get; set; }

}
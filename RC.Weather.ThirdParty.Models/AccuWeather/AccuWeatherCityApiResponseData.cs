namespace RC.Weather.ThirdParty.Models.AccuWeather
{
    public class AccuWeatherCityApiResponseData
	{
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public AdministrativeArea Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
    }

    public class AdministrativeArea
    {
        public string Id { get; set; }
        public string LocalizedName { get; set; }
    }
}

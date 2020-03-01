using System;

namespace RC.Weather.ThirdParty.Models.AccuWeather
{
    public class AccuWeatherWeatherApiResponseData
    {
        public string Link { get; set; }

        public long EpochTime { get; set; }

        public bool IsDayTime { get; set; }

        public int WeatherIcon { get; set; }

        public string MobileLink { get; set; }

        public string WeatherText { get; set; }

        public bool HasPrecipitation { get; set; }

        public Temperature Temperature { get; set; }

        public string PrecipitationType { get; set; }

        public string LocalObservationDateTime { get; set; }
    }

    public class Temperature
    {
        public TemperatureItem Metric { get; set; }

        public TemperatureItem Imperial { get; set; }
    }

    public class TemperatureItem
    {
        public string Unit { get; set; }

        public int UnitType { get; set; }

        public double Value { get; set; }
    }
}

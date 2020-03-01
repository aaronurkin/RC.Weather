using System.ComponentModel.DataAnnotations;

namespace RC.Weather.Presentation.Models.Requests
{
    public class PresentationWeatherRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string CityCode { get; set; }
    }
}

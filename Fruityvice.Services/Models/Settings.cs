namespace Fruityvice.Services.Models
{
    public class Settings
    {
        public ApiOptions ApiURL { get; set; }
    }

    public class ApiOptions
    {
        public string BaseUrl { get; set; }
    }
}

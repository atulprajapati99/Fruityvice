using System.ComponentModel.DataAnnotations;

namespace Fruityvice.API.Requests
{
    public class FruiteRequest
    {
        [Required]
        public string FruiteFamily { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace GiphyAPI.Models
{
    public class GifRating
    {
        public string? gif_id { get; set; }
        public int rating { get; set; }
        public IdentityUser? user { get; set; }
    }
}

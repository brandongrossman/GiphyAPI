using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GiphyAPI.Models
{
    [PrimaryKey(nameof(GifId),nameof(UserId))]
    public class GifRating
    {
        public string? GifId { get; set; }
        public string? UserId { get; set; }
        public int Rating { get; set; }
    }
}

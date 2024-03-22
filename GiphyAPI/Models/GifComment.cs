using GiphyAPI.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GiphyAPI.Models
{
    public class GifComment
    {
        [Key]
        public int Id { get; set; }
        public string? GifId { get; set; }
        public string? UserId { get; set; }
        public string? Content { get; set; }
    }
}

using GiphyAPI.Data;
using GiphyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GiphyAPI.Controllers
{
    [Route("ratings")]
    [ApiController]
    public class RatingController : Controller
    {
        private readonly DataContext _context;
        public RatingController(DataContext context)
        {
            _context = context;
        }

        /*
         * Returns Gif Ratings by GifId
         */
        [HttpGet("gif/{gifId}")]
        public Object GetGifRatings(string gifId)
        {
            var gifRatings = from User in _context.Users
                               from Ratings in _context.GifRatings

                               where (Ratings.GifId == gifId && User.Id == Ratings.UserId)

                               select new
                               {
                                   GifId = Ratings.GifId,
                                   UserId = User.Id,
                                   Username = User.UserName,
                                   Rating = Ratings.Rating
                               };

            return gifRatings;
        }

        /*
         * Creates or Updates Gif Rating depending if the rating already exists
         */
        [HttpPost("gif/update/{gifId}/{userId}/{rating}")]
        public async Task<ActionResult> UpdateGifRating(string gifId, string userId, int rating)
        {
            var existingGifRating = _context.GifRatings.Where(x => (x.GifId == gifId) && (x.UserId == userId));
            if (existingGifRating.Count() == 0)
            {
                await _context.GifRatings.AddAsync(new GifRating { GifId = gifId, UserId = userId, Rating = rating });
                await _context.SaveChangesAsync();
                return Ok();
            }
            _context.GifRatings.Update(new GifRating { GifId = gifId, UserId = userId, Rating = rating });
            await _context.SaveChangesAsync();
            return Ok();
        }

        /*
         * Deletes a Gif Rating
         */
        [HttpDelete("gif/delete/{gifId}/{userId}")]
        public async Task<ActionResult> DeleteGifRating(string gifId, string userId)
        {
            _context.GifRatings.Remove(new GifRating { GifId = gifId, UserId = userId });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

using Azure;
using GiphyAPI.Data;
using GiphyAPI.Models;
using GiphyAPI.Models.GiphyAPIResponses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;

namespace GiphyAPI.Controllers
{
    [Route("comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly DataContext _context;
        public CommentController(DataContext context)
        {
            _context = context;
        }

        /*
         * Returns Gif Comments by GifId
         */
        [HttpGet("gif/{gifId}")]
        public Object GetGifComments(string gifId)
        {
            var gifComments = from User in _context.Users
                               from Comments in _context.GifComments

                               where (Comments.GifId == gifId && User.Id == Comments.UserId)

                               select new
                               {
                                   Id = Comments.Id,
                                   GifId = Comments.GifId,
                                   UserId = User.Id,
                                   Username = User.UserName,
                                   Content = Comments.Content
                               };

            return gifComments;
        }

        /*
         * Creates Gif Comment by GifId, UserId, request body Comment-Content
         */
        [HttpPost("gif/create/{gifId}/{userId}")]
        public async Task<ActionResult> CreateGifComment(string gifId, string userId)
        {
            JObject gifCommentContent;
            using (StreamReader reader = new StreamReader(HttpContext.Request.Body))
            {
                gifCommentContent = JObject.Parse(await reader.ReadToEndAsync());
            }
            string? content = gifCommentContent["Comment-Content"].Value<string>();
            await _context.GifComments.AddAsync(new GifComment { GifId = gifId, UserId = userId, Content = content });
            await _context.SaveChangesAsync();
            return Ok();
        }

        /*
         * Updates Gif Comment by GifId, UserId, CommentId, and request body Comment-Content
         */
        [HttpPost("gif/update/{gifId}/{userId}/{commentId}")]
        public async Task<ActionResult> UpdateGifComment(string gifId, string userId, string commentId)
        {
            JObject gifCommentContent;
            using (StreamReader reader = new StreamReader(HttpContext.Request.Body))
            {
                gifCommentContent = JObject.Parse(await reader.ReadToEndAsync());
            }
            string? content = gifCommentContent["Comment-Content"].Value<string>();
            if (Int32.TryParse(commentId, out int id))
            {
                _context.GifComments.Update(new GifComment { Id = id, GifId = gifId, UserId = userId, Content = content});
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        /*
         * Deletes a Gif Comment by CommentId
         */
        [HttpDelete("gif/delete/{commentId}")]
        public async Task<ActionResult> DeleteGifComment(string commentId)
        {
            if(Int32.TryParse(commentId, out int id))
            {
                _context.GifComments.Remove(new GifComment { Id = id });
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
            
        }
    }
}

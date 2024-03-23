using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using GiphyAPI.Models.GiphyAPIResponses;
using Microsoft.AspNetCore.Authorization;

namespace GiphyAPI.Controllers
{
    /*
     * API: Giphy API
     * Documentation: https://developers.giphy.com/explorer/
     */
    [Route("giphy")]
    [ApiController]
    public class GiphyController : Controller
    {
        //sets URL for Giphy API Path and API Key for Giphy API
        private const string URL = "https://api.giphy.com/v1/";
        private const string APIKEY = "?api_key=saMQVcoYx6lbNc21aDGpl86wwZVKm5cm";
        //private const string RATING = "&rating=g";

        [HttpGet("gifs/search/{search}/{offset}")]
        public async Task<ActionResult<GifsBySearch>> GetGifsBySearch(string search, string offset)
        {
            GifsBySearch gifs;
            string path = "gifs/search";
            string parameters = "&q=" + search + "&limit=20&offset=" + offset + "&rating=g&lang=en&bundle=messaging_non_clips";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL + path);

            //adds an accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //lists data response
            HttpResponseMessage response = client.GetAsync(APIKEY + parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                //sets successfull response to object to be returned
                gifs = await response.Content.ReadAsAsync<GifsBySearch>();
            }
            else
            {
                //returns not found response
                return NotFound();
            }

            client.Dispose();
            return gifs;
        }

        [HttpGet("gifs/{id}")]
        public async Task<ActionResult<GifByID>> GetGifsById(string id)
        {
            GifByID gif;
            string path = "gifs/" + id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL + path);

            //adds an accept header for JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //lists data response
            HttpResponseMessage response = client.GetAsync(APIKEY).Result;
            if (response.IsSuccessStatusCode)
            {
                //sets successfull response to object to be returned
                gif = await response.Content.ReadAsAsync<GifByID>();
            }
            else
            {
                //returns not found response
                return NotFound();
            }

            client.Dispose();
            return gif;
        }
    }
}

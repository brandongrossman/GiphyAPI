namespace GiphyAPI.Models.GiphyAPIResponses
{
    public class GifRatingAPI
    {
        public GifRatingAPIData[]? GifRatingAPIData { get; set; }
    }

    public class GifRatingAPIData
    {
        public string? GifId { get; set; }
        public string? Username { get; set; }
        public int Rating { get; set; }
    }
}

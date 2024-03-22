using Newtonsoft.Json;

namespace GiphyAPI.Models.GiphyAPIResponses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class _480wStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class Analytics2
    {
        public Onload2? onload { get; set; }
        public Onclick2? onclick { get; set; }
        public Onsent2? onsent { get; set; }
    }

    public class Data2
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? url { get; set; }
        public string? slug { get; set; }
        public string? bitly_gif_url { get; set; }
        public string? bitly_url { get; set; }
        public string? embed_url { get; set; }
        public string? username { get; set; }
        public string? source { get; set; }
        public string? title { get; set; }
        public string? rating { get; set; }
        public string? content_url { get; set; }
        public string? source_tld { get; set; }
        public string? source_post_url { get; set; }
        public int is_sticker { get; set; }
        public string? import_datetime { get; set; }
        public string? trending_datetime { get; set; }
        public Images2? images { get; set; }
        public string? analytics_response_payload { get; set; }
        public Analytics2? analytics { get; set; }
    }

    public class Downsized2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class DownsizedLarge2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class DownsizedMedium2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class DownsizedSmall2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
    }

    public class DownsizedStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class FixedHeight2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
    }

    public class FixedHeightDownsampled2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
    }

    public class FixedHeightSmall2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
    }

    public class FixedHeightSmallStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class FixedHeightStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class FixedWidth2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
    }

    public class FixedWidthDownsampled2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
    }

    public class FixedWidthSmall2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
    }

    public class FixedWidthSmallStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class FixedWidthStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class Images2
    {
        public Original2? original { get; set; }
        public Downsized2? downsized { get; set; }
        public DownsizedLarge2? downsized_large { get; set; }
        public DownsizedMedium2? downsized_medium { get; set; }
        public DownsizedSmall2? downsized_small { get; set; }
        public DownsizedStill2? downsized_still { get; set; }
        public FixedHeight2? fixed_height { get; set; }
        public FixedHeightDownsampled2? fixed_height_downsampled { get; set; }
        public FixedHeightSmall2? fixed_height_small { get; set; }
        public FixedHeightSmallStill2? fixed_height_small_still { get; set; }
        public FixedHeightStill2? fixed_height_still { get; set; }
        public FixedWidth2? fixed_width { get; set; }
        public FixedWidthDownsampled2? fixed_width_downsampled { get; set; }
        public FixedWidthSmall2? fixed_width_small { get; set; }
        public FixedWidthSmallStill2? fixed_width_small_still { get; set; }
        public FixedWidthStill2? fixed_width_still { get; set; }
        public Looping2? looping { get; set; }
        public OriginalStill2? original_still { get; set; }
        public OriginalMp42? original_mp4 { get; set; }
        public Preview2? preview { get; set; }
        public PreviewGif2? preview_gif { get; set; }
        public PreviewWebp2? preview_webp { get; set; }

        [JsonProperty("480w_still")]
        public _480wStill2? _480w_still { get; set; }
    }

    public class Looping2
    {
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
    }

    public class Meta2
    {
        public int status { get; set; }
        public string? msg { get; set; }
        public string? response_id { get; set; }
    }

    public class Onclick2
    {
        public string? url { get; set; }
    }

    public class Onload2
    {
        public string? url { get; set; }
    }

    public class Onsent2
    {
        public string? url { get; set; }
    }

    public class Original2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
        public string? webp_size { get; set; }
        public string? webp { get; set; }
        public string? frames { get; set; }
        public string? hash { get; set; }
    }

    public class OriginalMp42
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
    }

    public class OriginalStill2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class Preview2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? mp4_size { get; set; }
        public string? mp4 { get; set; }
    }

    public class PreviewGif2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class PreviewWebp2
    {
        public string? height { get; set; }
        public string? width { get; set; }
        public string? size { get; set; }
        public string? url { get; set; }
    }

    public class GifByID
    {
        public Data2? data { get; set; }
        public Meta2? meta { get; set; }
    }

}

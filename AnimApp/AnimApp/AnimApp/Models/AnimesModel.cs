using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.Models
{
    class AnimesModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        [JsonProperty("data")]
        public List<Datum> data { get; set; }
        public Meta meta { get; set; }
        public Links links { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("type")]
            public string type { get; set; }

            [JsonProperty("links")]
            public Links links { get; set; }

            [JsonProperty("attributes")]
            public Attributes attributes { get; set; }
            public Relationships relationships { get; set; }
        }


        public class Titles
        {
            public string en { get; set; }

            [JsonProperty("en_jp")]
            public string en_jp { get; set; }

            [JsonProperty("ja_jp")]
            public string ja_jp { get; set; }
            public string en_us { get; set; }
        }

        public class RatingFrequencies
        {
            public string _2 { get; set; }
            public string _3 { get; set; }
            public string _4 { get; set; }
            public string _5 { get; set; }
            public string _6 { get; set; }
            public string _7 { get; set; }
            public string _8 { get; set; }
            public string _9 { get; set; }
            public string _10 { get; set; }
            public string _11 { get; set; }
            public string _12 { get; set; }
            public string _13 { get; set; }
            public string _14 { get; set; }
            public string _15 { get; set; }
            public string _16 { get; set; }
            public string _17 { get; set; }
            public string _18 { get; set; }
            public string _19 { get; set; }
            public string _20 { get; set; }
        }

        public class Tiny
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Large
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Small
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Medium
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Dimensions
        {
            public Tiny tiny { get; set; }
            public Large large { get; set; }
            public Small small { get; set; }
            public Medium medium { get; set; }
        }



        public class PosterImage
        {
            public string tiny { get; set; }
            public string large { get; set; }
            public string small { get; set; }
            public string medium { get; set; }

            [JsonProperty("original")]
            public string original { get; set; }
            public Meta meta { get; set; }
        }

        public class CoverImage
        {
            public string tiny { get; set; }
            public string large { get; set; }
            public string small { get; set; }

            [JsonProperty("original")]
            public string original { get; set; }
            public Meta meta { get; set; }
        }

        public class Attributes
        {
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string slug { get; set; }
            public string synopsis { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }
            public int coverImageTopOffset { get; set; }
            public Titles titles { get; set; }

            [JsonProperty("canonicalTitle")]
            public string canonicalTitle { get; set; }
            public List<string> abbreviatedTitles { get; set; }

            [JsonProperty("averageRating")]
            public string averageRating { get; set; }
            public RatingFrequencies ratingFrequencies { get; set; }
            public int userCount { get; set; }
            public int favoritesCount { get; set; }

            [JsonProperty("startDate")]
            public string startDate { get; set; }

            [JsonProperty("endDate")]
            public string endDate { get; set; }
            public object nextRelease { get; set; }
            public int popularityRank { get; set; }
            public int ratingRank { get; set; }
            public string ageRating { get; set; }
            public string ageRatingGuide { get; set; }
            public string subtype { get; set; }
            public string status { get; set; }
            public string tba { get; set; }

            [JsonProperty("posterImage")] 
            public PosterImage posterImage { get; set; }

            [JsonProperty("coverImage")]
            public CoverImage coverImage { get; set; }

            [JsonProperty("episodeCount")]
            public int episodeCount { get; set; }
            public int? episodeLength { get; set; }
            public int totalLength { get; set; }

            [JsonProperty("youtubeVideoId")]
            public string youtubeVideoId { get; set; }
            public string showType { get; set; }
            public bool nsfw { get; set; }
        }

        public class Genres
        {
            public Links links { get; set; }
        }

        public class Categories
        {
            public Links links { get; set; }
        }

        public class Castings
        {
            public Links links { get; set; }
        }

        public class Installments
        {
            public Links links { get; set; }
        }

        public class Mappings
        {
            public Links links { get; set; }
        }

        public class Reviews
        {
            public Links links { get; set; }
        }

        public class MediaRelationships
        {
            public Links links { get; set; }
        }

        public class Characters
        {
            public Links links { get; set; }
        }

        public class Staff
        {
            public Links links { get; set; }
        }

        public class Productions
        {
            public Links links { get; set; }
        }

        public class Quotes
        {
            public Links links { get; set; }
        }

        public class Episodes
        {
            public Links links { get; set; }
        }

        public class StreamingLinks
        {
            public Links links { get; set; }
        }

        public class AnimeProductions
        {
            public Links links { get; set; }
        }

        public class AnimeCharacters
        {
            public Links links { get; set; }
        }

        public class AnimeStaff
        {
            public Links links { get; set; }
        }

        public class Relationships
        {
            public Genres genres { get; set; }
            public Categories categories { get; set; }
            public Castings castings { get; set; }
            public Installments installments { get; set; }
            public Mappings mappings { get; set; }
            public Reviews reviews { get; set; }
            public MediaRelationships mediaRelationships { get; set; }
            public Characters characters { get; set; }
            public Staff staff { get; set; }
            public Productions productions { get; set; }
            public Quotes quotes { get; set; }
            public Episodes episodes { get; set; }
            public StreamingLinks streamingLinks { get; set; }
            public AnimeProductions animeProductions { get; set; }
            public AnimeCharacters animeCharacters { get; set; }
            public AnimeStaff animeStaff { get; set; }
        }

        public class Meta
        {
            public Dimensions dimensions { get; set; }
            public int count { get; set; }
        }


        public class Links
        {
            public string self { get; set; }
            public string related { get; set; }
            public string first { get; set; }
            public string next { get; set; }
            public string last { get; set; }
        }
    }
}

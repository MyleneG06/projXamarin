using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimApp.Models
{
    public class MangasModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Links
        {
            public string self { get; set; }
            public string related { get; set; }
            public string first { get; set; }
            public string next { get; set; }
            public string last { get; set; }
        }

        public class Titles
        {
            public string en { get; set; }
            public string en_jp { get; set; }
            public string en_us { get; set; }
            public string ja_jp { get; set; }
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
            public TinyWebp tiny_webp { get; set; }
            public LargeWebp large_webp { get; set; }
            public SmallWebp small_webp { get; set; }
        }

        public class Meta
        {
            public Dimensions dimensions { get; set; }
            public int count { get; set; }
        }

        public class PosterImage
        {
            public string tiny { get; set; }
            public string large { get; set; }
            public string small { get; set; }
            public string medium { get; set; }
            public string original { get; set; }
            public Meta meta { get; set; }
        }

        public class TinyWebp
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class LargeWebp
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class SmallWebp
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class CoverImage
        {
            public string tiny { get; set; }
            public string large { get; set; }
            public string small { get; set; }
            public string tiny_webp { get; set; }
            public string large_webp { get; set; }
            public string small_webp { get; set; }
            public string original { get; set; }
            public Meta meta { get; set; }
        }

        public class Attributes
        {
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string slug { get; set; }
            public string synopsis { get; set; }
            public string description { get; set; }
            public int coverImageTopOffset { get; set; }
            public Titles titles { get; set; }
            public string canonicalTitle { get; set; }
            public List<string> abbreviatedTitles { get; set; }
            public string averageRating { get; set; }
            public RatingFrequencies ratingFrequencies { get; set; }
            public int userCount { get; set; }
            public int favoritesCount { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public object nextRelease { get; set; }
            public int popularityRank { get; set; }
            public int? ratingRank { get; set; }
            public string ageRating { get; set; }
            public string ageRatingGuide { get; set; }
            public string subtype { get; set; }
            public string status { get; set; }
            public string tba { get; set; }
            public PosterImage posterImage { get; set; }
            public CoverImage coverImage { get; set; }
            public int? chapterCount { get; set; }
            public int volumeCount { get; set; }
            public string serialization { get; set; }
            public string mangaType { get; set; }
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

        public class Chapters
        {
            public Links links { get; set; }
        }

        public class MangaCharacters
        {
            public Links links { get; set; }
        }

        public class MangaStaff
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
            public Chapters chapters { get; set; }
            public MangaCharacters mangaCharacters { get; set; }
            public MangaStaff mangaStaff { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public string type { get; set; }
            public Links links { get; set; }
            public Attributes attributes { get; set; }
            public Relationships relationships { get; set; }
        }

        public class Root
        {
            public List<Datum> data { get; set; }
            public Meta meta { get; set; }
            public Links links { get; set; }
        }


    }
}

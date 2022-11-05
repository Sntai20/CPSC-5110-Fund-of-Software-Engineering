namespace ContosoCrafts.WebSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class ArticleModel
    {
        /// <summary>
        /// Define attributes of Article Model. 
        /// </summary>
        // Properties: Unique Identifier, Author(s), Publish Date, URL, Image, Title, Tags, Article Text/Body.
        public string Id { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Url { get; set; }

        [StringLength(maximumLength: 128, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and up to {1} characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        public int[] Ratings { get; set; }

        public ArticleTypeEnum ArticleType { get; set; } = ArticleTypeEnum.Undefined;

        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        // Store the Comments entered by the users on this article.
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        public override string ToString() => JsonSerializer.Serialize<ArticleModel>(this);
    }
}

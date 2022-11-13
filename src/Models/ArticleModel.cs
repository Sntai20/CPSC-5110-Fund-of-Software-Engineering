namespace ContosoCrafts.WebSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using static System.Net.WebRequestMethods;

    public class ArticleModel
    {
        /// <summary>
        /// Define attributes of Article Model. 
        /// </summary>
        // Properties: Unique Identifier, Author(s), Publish Date, URL, Image, Title, Tags, Article Text/Body.

        // Regex URL validation string
        private const string urlRegEx = "^(http(s?)\\:\\/\\/)";
        
        // Unique identifier for the article
        public string Id { get; set; }

        // Author Name
        [RegularExpression(@"^[a-zA-Z_\s-]{1,40}$", ErrorMessage = "Only upper case letters, lower case letters, spaces, and dashes are permitted.")]
        public string Author { get; set; }
        
        // Date article was published
        public string PublishDate { get; set; }

        // A link to the image file to display in article preview
        [JsonPropertyName("img")]
        [Required(ErrorMessage = "Image field is required.")]
        [RegularExpression(urlRegEx, ErrorMessage = "Invalid URL format.")]
        public string Image { get; set; }

        // Web location for the article
        [Required(ErrorMessage = "URL field is required.")]
        [RegularExpression(urlRegEx, ErrorMessage = "Invalid URL format.")]
        public string Url { get; set; }

        // Article title
        [Required(ErrorMessage = "Title field is required.")]
        [StringLength(maximumLength: 40, MinimumLength = 1, ErrorMessage = "The Title should have a length of at least {2} and up to {1} characters")]
        public string Title { get; set; }

        // Brief description of article content
        [Required(ErrorMessage = "Description field is required.")]
        [StringLength(maximumLength: 700 , MinimumLength = 1, ErrorMessage = "The Description should have a length of more than {2} and up to {1} characters")]
        public string Description { get; set; }

        // ratings for the article (remnant from Contoso Crafts site)
        public int[] Ratings { get; set; }

        // An enum to decription the article category (tag)
        public ArticleTypeEnum ArticleType { get; set; } = ArticleTypeEnum.Undefined;

        // Product price (remnant from the Contose Crafts site)
        [Range(0, 10000, ErrorMessage = "Value for {0} must be at least {1} and no more than {2}.")]
        public int Price { get; set; }

        // Store the Comments entered by the users on this article.
        [StringLength(maximumLength: 1024, MinimumLength = 1, ErrorMessage = "Comments must have a length of more than {2} and up to {1} characters")]
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        // To string method to display article as a text stirng
        public override string ToString() => JsonSerializer.Serialize<ArticleModel>(this);
    }
}

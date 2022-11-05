﻿namespace ContosoCrafts.WebSite.Models
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
       
        // Unique identifier for the article
        public string Id { get; set; }

        // Author Name
        public string Author { get; set; }
        
        // Date article was published
        public string PublishDate { get; set; }

        // A link to the image file to display in article preview
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // Web location for the article
        public string Url { get; set; }

        // Article title
        [StringLength(maximumLength: 128, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and up to {1} characters")]
        public string Title { get; set; }

        // Brief description of article content
        public string Description { get; set; }

        // ratings for the article (remnant from Contoso Crafts site)
        public int[] Ratings { get; set; }

        // An enum to decription the article category (tag)
        public ArticleTypeEnum ArticleType { get; set; } = ArticleTypeEnum.Undefined;

        // Product price (remnant from the Contose Crafts site)
        [Range(0, 10000, ErrorMessage = "Value for {0} must be at least {1} and no more than {2}.")]
        public int Price { get; set; }

        // Store the Comments entered by the users on this article.
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        // To string method to display article as a text stirng
        public override string ToString() => JsonSerializer.Serialize<ArticleModel>(this);
    }
}

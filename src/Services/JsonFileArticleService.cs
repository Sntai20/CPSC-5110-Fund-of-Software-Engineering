namespace ContosoCrafts.WebSite.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using ContosoCrafts.WebSite.Models;

    using Microsoft.AspNetCore.Hosting;

    public class JsonFileArticleService
    {
        public JsonFileArticleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "articles.json");

        public IEnumerable<ArticleModel> GetAllData()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<ArticleModel[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the article ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string articleId, int rating)
        {
            // If the ArticleID is invalid, return
            if (string.IsNullOrEmpty(articleId))
            {
                return false;
            }

            var articles = GetAllData();

            // Look up the article, if it does not exist, return
            var data = articles.FirstOrDefault(x => x.Id.Equals(articleId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            data.Ratings ??= new int[] { };

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(articles);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ArticleModel UpdateData(ArticleModel data)
        {
            var articles = GetAllData();
            var articleData = articles.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (articleData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            articleData.Title = data.Title;
            articleData.Author = data.Author;
            articleData.Description = data.Description.Trim();
            articleData.Url = data.Url;
            articleData.Image = data.Image;

            articleData.PublishDate = data.PublishDate;
            articleData.Price = data.Price;

            articleData.CommentList = data.CommentList;

            SaveData(articles);

            return articleData;
        }

        /// <summary>
        /// Save All articles data to storage
        /// </summary>
        private void SaveData(IEnumerable<ArticleModel> articles)
        {

            using var outputStream = File.Create(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<ArticleModel>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                articles
            );
        }

        /// <summary>
        /// Create a new article using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ArticleModel CreateData()
        {
            var data = new ArticleModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = "",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ArticleModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

    }
}

namespace ContosoCrafts.WebSite.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using ContosoCrafts.WebSite.Models;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// The JsonFileArticleService class is responsible for interacting with the
    /// datastore. The datastore for this project is the articles.json file.
    /// </summary>
    public class JsonFileArticleService
    {
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="webHostEnvironment">Provides the information about the web hosting environment an application is running in.</param>
        public JsonFileArticleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Store the information about the web hosting environment an application is running in.
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// The full path of the json file, starting from the web root path.
        /// </summary>
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "articles.json");

        /// <summary>
        /// Gets all the data from the json file and creates an instance of the ArticleModel.
        /// </summary>
        /// <returns>An Enumerable ArticleModel.</returns>
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
        /// <param name="articleId">The unique article Id number.</param>
        /// <param name="rating">The article rating integer value.</param>
        /// <returns>Returns true if ratings are added, otherwise return false.</returns>
        public bool AddRating(string articleId, int rating)
        {
            // If the ArticleID is invalid, return
            if (string.IsNullOrEmpty(articleId))
            {
                return false;
            }

            var articles = GetAllData();

            // Look up the article, if it does not exist, return.
            var data = articles.FirstOrDefault(x => x.Id.Equals(articleId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, 
            // then create the array.
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
        /// <param name="data">The ArticleModel.</param>
        public ArticleModel UpdateData(ArticleModel data)
        {
            var articles = GetAllData();
            var articleData = articles.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (articleData == null)
            {
                return null;
            }

            // Update the data to the new passed in values.
            articleData.Title = data.Title;
            articleData.Description = data.Description.Trim();
            articleData.Url = data.Url;
            articleData.Image = data.Image;
            articleData.Author = data.Author;
            articleData.PublishDate = data.PublishDate;
            articleData.Price = data.Price;
            articleData.CommentList = data.CommentList;

            SaveData(articles);

            return articleData;
        }

        /// <summary>
        /// Save All articles data to storage.
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
        /// Create a new article using default values.
        /// After create the user can update to set values.
        /// </summary>
        /// <returns>The ArticleModel.</returns>
        public ArticleModel CreateData()
        {
            var data = new ArticleModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Default title",
                Description = "Article description",
                Url = "Article URL",
                Image = "No image specified",
            };

            // Get the current set, and append the new record to it because IEnumerable does not have Add.
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system.
        /// </summary>
        /// <returns>The ArticleModel.</returns>
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

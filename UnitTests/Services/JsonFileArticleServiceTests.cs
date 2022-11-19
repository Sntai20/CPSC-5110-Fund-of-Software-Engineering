namespace UnitTests.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json
    using Bunit.Extensions
    using ContosoCrafts.WebSite.Models
    using NUnit.Framework;
    
    /// <summary>
    /// This class holds the tests for the main JsonFileArticleService class.
    /// </summary>
    public class JsonFileArticleServiceTests
    {

        #region TestSetup

        /// <summary>
        /// Initialize tests for JsonFileArticleService class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region GetAllData

        /// <summary>
        /// Test of invalid state for GetAllData method
        /// </summary>
        [Test]
        public void GetAllData_Invalid_Does_Not_Return_Null_Or_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.GetAllData();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }

        /// <summary>
        /// Test for valid result of GetAllData method
        /// </summary>
        [Test]
        public void GetAllData_Valid_Returns_Contents_Of_Json_File_Should_Return_True()
        {
            // Arrange

            // read JSON file directly and convert to a string for comparison
            var jsonFileReader = File.OpenText("..\\..\\..\\..\\src\\wwwroot\\data\\articles.json");

            IEnumerable<ArticleModel> expected = JsonSerializer.Deserialize<ArticleModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            // Act
            var result = TestHelper.ArticleService.GetAllData();

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion GetAllData

        #region AddRating
        /// <summary>
        /// Testing invalid null input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Article_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid empty string input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Data_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.AddRating("Does not exist", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid megatove rating value for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Negative_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ArticleService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ArticleService.AddRating(productID, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing invalid, too high rating value for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Too_High_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ArticleService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ArticleService.AddRating(productID, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Testing for creation of ratings array when a first rating is provided to AddRating method
        /// </summary>
        [Test]
        public void AddRating_Valid_Create_Data_Ratings_Array_Should_Return_True()
        {
            // Arrange
            // create a ProductModel with no ratings
            var data = TestHelper.ArticleService.CreateData();

            // Act
            var result = TestHelper.ArticleService.AddRating(data.Id, 4);

            // Assert
            Assert.AreEqual(true, result);

        }

        /// <summary>
        /// Testing typical, valid usage of AddRating method
        /// </summary>
        [Test]
        public void AddRating_Valid_Article_Rating_5_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ArticleService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ArticleService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ArticleService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }
        #endregion AddRating

        #region CreateData

        /// <summary>
        /// Testing typical, valid usage of CreateData method
        /// </summary>
        [Test]
        public void CreateData_Valid_Last_Value_Matches_Created_Values_Should_Return_True()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.CreateData();
            var last = TestHelper.ArticleService.GetAllData().Last();

            // Assert
            Assert.AreEqual("Default title", result.Title);
            Assert.AreEqual("Article description", result.Description);
            Assert.AreEqual("Article URL", result.Url);
            Assert.AreEqual("No image specified", result.Image);
            Assert.AreEqual(result.Id, last.Id);
        }
        #endregion CreateData

        #region UpdateData
        
        /// <summary>
        /// Testing typical, valid usage of UpdateData method
        /// </summary>
        [Test]
        public void UpdateData_Valid_Updated_Value_Matches_Should_Return_True()
        {
            // Arrange
            var data = TestHelper.ArticleService.GetAllData().FirstOrDefault();
            var data2 = data;
            data2.Title = "Test";

            // Act
            var result = TestHelper.ArticleService.UpdateData(data2);

            // Reset
            _ = TestHelper.ArticleService.UpdateData(data);

            // Assert
            Assert.AreEqual(data2.Title, result.Title);
        }
        #endregion UpdateData
    }
}

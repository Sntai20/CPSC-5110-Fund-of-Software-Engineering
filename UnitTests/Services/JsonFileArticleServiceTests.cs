using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Article.AddRating
{
    public class JsonFileArticleServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        [Test]
        public void AddRating_InValid_Article_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Data_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.AddRating("Does not exist", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

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

        [Test]
        public void AddRating_Valid_Article_Valid_Rating_Valid_Should_Return_True()
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

    }
}
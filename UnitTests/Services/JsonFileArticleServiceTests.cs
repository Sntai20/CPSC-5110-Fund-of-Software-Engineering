using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using System.Text.Json;
using Bunit.Extensions;
using System.IO;
using System.Collections.Generic;
using System;

namespace UnitTests.Pages.Article
{
    public class JsonFileArticleServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        
        #region GetAllData

        [Test]
        public void GetAllData_Invalid_Does_Not_Return_Null_Or_Empty_Should_Return_False()
        {
            // Arrange
            
            // Act
            var result = TestHelper.ArticleService.GetAllData();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }

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
            IEnumerable<ArticleModel> result = TestHelper.ArticleService.GetAllData();
            
            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion GetAllData

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
        public void AddRating_InValid_Too_High_Rating_Should_Return_False()
        {
            // Arrange
            var productID = TestHelper.ArticleService.GetAllData().First().Id;

            // Act
            var result = TestHelper.ArticleService.AddRating(productID, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

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

        [Test]
        public void CreateData_Valid_Last_Value_Matches_Created_Values_Should_Return_True()
        {
            // Arrange

            // Act
            var result = TestHelper.ArticleService.CreateData();
            var last = TestHelper.ArticleService.GetAllData().Last();

            // Assert
            Assert.AreEqual("Enter Title", result.Title);
            Assert.AreEqual("Enter Description", result.Description);
            Assert.AreEqual("Enter URL", result.Url);
            Assert.AreEqual("", result.Image);
            Assert.AreEqual(result.Id, last.Id);
        }
        #endregion CreateData

        #region UpdateData
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
            data = TestHelper.ArticleService.UpdateData(data);

            // Assert
            Assert.AreEqual(data2.Title, result.Title);
        }



        #endregion UpdateData


    }
}
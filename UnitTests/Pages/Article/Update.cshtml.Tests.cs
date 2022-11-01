namespace UnitTests.Pages.Article
{

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Pages.Article;

    using Microsoft.AspNetCore.Mvc;

    using NUnit.Framework;
    /// <summary>
    /// This class holds the tests for the Update.cshtml.Tests.cs.
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ArticleService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Articles()
        {
            // Arrange

            // Act
            pageModel.OnGet("selinazawacki-shirt");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Floppy Crop", pageModel.Article.Title);
        }
        #endregion OnGet

        #region OnPostAsync
        [Test]
        public void OnPostAsync_Valid_Should_Return_Articles()
        {
            // Arrange
            pageModel.Article = new ArticleModel
            {
                Id = "selinazawacki-moon",
                Title = "title",
                Description = "description",
                Url = "url",
                Image = "image"
            };

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Article = new ArticleModel
            {
                Id = "bogus",
                Title = "bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            _ = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}

namespace UnitTests.Pages.Article;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.Article;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

/// <summary>
/// This class holds the tests for the Delete.cshtml.Tests.cs.
/// </summary>
public class DeleteTests
{
    #region TestSetup
 
    // Data field to hold page model specific to the Delete function
    public static DeleteModel pageModel;

    /// <summary>
    /// Setup test prior to execution.
    /// </summary>
    [SetUp]
    public void TestInitialize()
    {
        pageModel = new DeleteModel(TestHelper.ArticleService)
        {
        };
    }

    #endregion TestSetup

    #region OnGet

    /// <summary>
    /// Test a valid result for OnGet method
    /// </summary>
    [Test]
    public void OnGet_Valid_Should_Return_Articles()
    {
        // Arrange

        // Act
        pageModel.OnGet("selinazawacki-shirt");

        // Assert
        Assert.That(Equals(true, pageModel.ModelState.IsValid));
        Assert.That(Equals("Floppy Crop", pageModel.Article.Title));
    }
    #endregion OnGet

    #region OnPostAsync

    /// <summary>
    /// Test a valid result for OnPost method
    /// </summary>
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
        Assert.That(Equals(true, pageModel.ModelState.IsValid));
        Assert.That(Equals(true, result.PageName.Contains("Index")));
    }

    /// <summary>
    /// Test an invalid result for OnPost method
    /// </summary>
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
        Assert.That(Equals(false, pageModel.ModelState.IsValid));
    }
    #endregion OnPostAsync
}

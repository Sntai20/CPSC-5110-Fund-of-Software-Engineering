namespace UnitTests.Controllers;

using System.Linq;
using ContosoCrafts.WebSite.Controllers;
using NUnit.Framework;

/// <summary>
/// Unit tests for the ArticleController class.
/// </summary>
internal class ArticleControllerTests
{
    #region TestSetup

    // controller instance to test
    public static ArticlesController controller;

    /// <summary>
    /// SetUp for the tests
    /// </summary>
    [SetUp]
    public void TestInitialize()
    {
        // Create a new controller instance
        controller = new ArticlesController(TestHelper.ArticleService);
    }

    #endregion TestSetup

    #region Get

    /// <summary>
    /// Test the API Get Http request method
    /// </summary>
    [Test]
    public void Get_Valid_Should_Returns_All_Article()
    {
        // Arrange
        var expected = TestHelper.ArticleService.GetAllData().Count();

        // Act
        var actual = controller.Get().Count();

        // Assert
        Assert.AreEqual(true, controller.ModelState.IsValid);
        Assert.AreEqual(expected, actual);
    }

    #endregion Get
}

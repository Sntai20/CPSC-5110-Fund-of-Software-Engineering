using System.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Article;

namespace UnitTests.Pages.Index
{
    public class IndexTests
    {
        #region TestSetup

        public static IndexModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            pageModel = new IndexModel(TestHelper.ArticleService)
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
            pageModel.OnGet();
            var result = pageModel.Articles;


            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Articles.ToList().Any());
        }
        #endregion OnGet
    }
}
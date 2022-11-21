namespace UnitTests.Pages.Article
{
    using ContosoCrafts.WebSite.Pages.Article;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// This class holds the tests for the Create.cshtml.Tests.cs
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        // A factory for creating IUrlHelper instances.
        public static IUrlHelperFactory urlHelperFactory;

        // Represents an implementation of the HTTP Context class.
        public static DefaultHttpContext httpContextDefault;

        // Provides information about the web hosting environment an application is running in.
        public static IWebHostEnvironment webHostEnvironment;

        // Represents the state of an attempt to bind a posted form to an action method, which includes validation information.
        public static ModelStateDictionary modelState;

        // Context object for execution of action which has been selected as part of an HTTP request.
        public static ActionContext actionContext;

        // Represents an empty model metadata provider.
        public static EmptyModelMetadataProvider modelMetadataProvider;

        // Represents a container that is used to pass data between a controller and a view.
        public static ViewDataDictionary viewData;

        // Represents a set of data that persists only from one request to the next.
        public static TempDataDictionary tempData;

        // The SharePoint page context object.
        public static PageContext pageContext;

        // Data field for page model
        public static CreateModel pageModel;

        /// <summary>
        /// Setup test prior to execution.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            httpContextDefault = new DefaultHttpContext()
            {
                //RequestServices = serviceProviderMock.Object,
            };

            modelState = new ModelStateDictionary();

            actionContext = new ActionContext(httpContextDefault, httpContextDefault.GetRouteData(), new PageActionDescriptor(), modelState);

            modelMetadataProvider = new EmptyModelMetadataProvider();
            viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            tempData = new TempDataDictionary(httpContextDefault, Mock.Of<ITempDataProvider>());

            pageContext = new PageContext(actionContext)
            {
                ViewData = viewData,
            };

            var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            _ = mockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            _ = mockWebHostEnvironment.Setup(m => m.WebRootPath).Returns("../../../../src/bin/Debug/net6.0/wwwroot");
            _ = mockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns("./data/");

            var MockLoggerDirect = Mock.Of<ILogger<CreateModel>>();
            JsonFileArticleService articleService;

            articleService = new JsonFileArticleService(mockWebHostEnvironment.Object);

            pageModel = new CreateModel(articleService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Confirm valid operation of OnGet method.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_True()
        {
            // Arrange

            // Act
            _ = pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}

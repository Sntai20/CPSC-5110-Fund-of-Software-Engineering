namespace UnitTests
{

    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Routing;

    using Moq;

    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    /// 
    /// Action Contect
    /// 
    /// The View Data and Teamp Data
    /// 
    /// The Article Service
    /// </summary>
    public static class TestHelper
    {
        // URLHelperFactory defines the contract for the helper to build URLs fo ASP.NET MVC within an application
        public static IUrlHelperFactory UrlHelperFactory;

        // WebHostEnvironment proivdes infomration about he web hosting environment an application is running in.
        public static IWebHostEnvironment WebHostEnvironment;

        // MockWebHostEnvironment simulates the web hosting environment
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;

        // HttpContextDefault represents an implemetation of the HTTP Context class.
        public static DefaultHttpContext HttpContextDefault;

        // ModelState represents the staet of an attempt ot bind a posted form to an action mehtod, which includes validation information
        public static ModelStateDictionary ModelState;

        // ActionContext is a context object for execution of action which has been selected as apart of an HTTP request.
        public static ActionContext ActionContext;

        // ModelMetdataProvider is a MicrosoftAspNetCor.Mvc.ModelBinding.Metdata.DefaultBindingMetadataProvider that represents an empty model.
        public static EmptyModelMetadataProvider ModelMetadataProvider;

        // ViewData represents a container that is used to pass data between a controller and a view.
        public static ViewDataDictionary ViewData;

        // TempData represents a set of data that persistes only from one request to the next.
        public static TempDataDictionary TempData;

        // PageContext is the context associated with the currenet request for a Razor page.
        public static PageContext PageContext;

        // ArticleService is an instance of the JsonFileArticleService class holding the details of the Json file "database"
        public static JsonFileArticleService ArticleService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            _ = MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            _ = MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);
            _ = MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            HttpContextDefault = new DefaultHttpContext()
            {
                TraceIdentifier = "trace",
            };
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            ModelState = new ModelStateDictionary();

            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            ModelMetadataProvider = new EmptyModelMetadataProvider();
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            PageContext = new PageContext(ActionContext)
            {
                ViewData = ViewData,
                HttpContext = HttpContextDefault
            };

            ArticleService = new JsonFileArticleService(MockWebHostEnvironment.Object);

            JsonFileArticleService articleService;

            articleService = new JsonFileArticleService(TestHelper.MockWebHostEnvironment.Object);
        }
    }
}
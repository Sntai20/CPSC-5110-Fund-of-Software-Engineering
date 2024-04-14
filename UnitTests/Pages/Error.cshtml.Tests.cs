namespace UnitTests.Pages;

using System.Diagnostics;
using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

/// <summary>
/// Test class for the Error page
/// </summary>
public class ErrorTests
{
    
    #region TestSetup

    // data field to hold the Error page
    public static ErrorModel pageModel;

    /// <summary>
    /// Setup test prior to execution
    /// </summary>
    [SetUp]
    public void TestInitialize()
    {
        var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

        pageModel = new ErrorModel(MockLoggerDirect)
        {
            PageContext = TestHelper.PageContext,
            TempData = TestHelper.TempData,
        };
    }

    #endregion TestSetup

    #region OnGet

    /// <summary>
    /// Test successful execution of the OnGet method.
    /// </summary>
    [Test]
    public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
    {

        // Arrange

        var activity = new Activity("activity");
        _ = activity.Start();

        // Act
        pageModel.OnGet();

        // Reset
        activity.Stop();

        // Assert
        Assert.That(Equals(true, pageModel.ModelState.IsValid));
        Assert.That(Equals(activity.Id, pageModel.RequestId));
    }

    /// <summary>
    /// Test an invalid, null input to the OnGet method
    /// </summary>
    [Test]
    public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
    {

        // Arrange

        // Act
        pageModel.OnGet();

        // Reset

        // Assert
        Assert.That(Equals(true, pageModel.ModelState.IsValid));
        Assert.That(Equals("trace", pageModel.RequestId));
        Assert.That(Equals(true, pageModel.ShowRequestId));
    }
    #endregion OnGet
}

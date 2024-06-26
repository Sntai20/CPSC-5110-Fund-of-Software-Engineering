﻿namespace UnitTests;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

/// <summary>
/// Set of initial tests.
/// </summary>
public class StartupTests
{
    #region TestSetup

    /// <summary>
    /// Initialize the test.
    /// </summary>
    [SetUp]
    public void TestInitialize()
    {
    }

    /// <summary>
    /// Start up the Contoso crafts website.
    /// </summary>
    public class Startup(IConfiguration config) : ContosoCrafts.WebSite.Startup(config)
    {
    }
    #endregion TestSetup

    #region ConfigureServices

    /// <summary>
    /// Configure services after Start up.
    /// </summary>
    [Test]
    public void Startup_ConfigureServices_Valid_Default_Should_Pass()
    {
        var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
        Assert.That(webHost, Is.Not.Null);
    }
    #endregion ConfigureServices

    #region Configure

    /// <summary>
    /// Using default startup configuration should pass.
    /// </summary>
    [Test]
    public void Startup_Configure_Valid_Default_Should_Pass()
    {
        var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
        Assert.That(webHost, Is.Not.Null);
    }
    #endregion Configure
}

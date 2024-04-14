namespace UnitTests;

using System.IO;
using NUnit.Framework;

[SetUpFixture]
public class TestFixture
{

    // Path to the Web Root
    public static string DataWebRootPath = "./wwwroot";

    // Path to the data folder for the content
    public static string DataContentRootPath = "./data/";

    /// <summary>
    /// Configure test prior to execution.
    /// </summary>
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {

        // Run this code once when the test harness starts up.

        // This will copy over the latest version of the database files

        // C:\repos\5110\ClassBaseline\UnitTests\bin\Debug\net5.0\wwwroot\data
        // C:\repos\5110\ClassBaseline\src\wwwroot\data
        // C:\repos\5110\ClassBaseline\src\bin\Debug\net5.0\wwwroot\data

        // path to data
        var DataWebPath = "../../../../src/bin/Debug/net6.0/wwwroot/data";
        
        // path to unit test directory
        var DataUTDirectory = "wwwroot";

        // path to unit test data
        var DataUTPath = DataUTDirectory + "/data";

        // Delete the Destination folder
        if (Directory.Exists(DataUTDirectory))
        {
            Directory.Delete(DataUTDirectory, true);
        }

        // Make the directory
        _ = Directory.CreateDirectory(DataUTPath);

        // Copy over all data files
        var filePaths = Directory.GetFiles(DataWebPath);
        foreach (var filename in filePaths)
        {
            var OriginalFilePathName = filename.ToString();
            var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

            File.Copy(OriginalFilePathName, newFilePathName);
        }
    }

    /// <summary>
    /// Ensures a clean state after test execution.
    /// </summary>
    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}

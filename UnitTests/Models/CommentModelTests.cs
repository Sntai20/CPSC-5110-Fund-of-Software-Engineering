namespace UnitTests.Models;

using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

/// <summary>
/// Test class for CommentModelTests
/// </summary>
public class CommentModelTests
{

    [Test]
    public void CommentModel_Valid_Null_ID_Should_Return_True()
    {

        // Arrange
        CommentModel result = new CommentModel();

        // Act
        result.Id = "a1feba95-561f-46c1-8e88-db0ef2f8a2a4";
        result.Comment = "Test comment";

        // Assert
        Assert.AreEqual("a1feba95-561f-46c1-8e88-db0ef2f8a2a4", result.Id);
        Assert.AreEqual("Test comment", result.Comment.ToString());
    }
}

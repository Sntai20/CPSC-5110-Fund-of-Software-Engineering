namespace UnitTests.Models;

using ContosoCrafts.WebSite.Models;
using NUnit.Framework;


/// <summary>
/// Test class for ArticleTypeEnumExtensions
/// </summary>
public class ArticleTypeEnumExtensions
{
    [Test]
    public void ArticleTypeEnum_Valid_Null_ID_Should_Return_True()
    {
        // Arrange

        // Act
        var result1 = ArticleTypeEnumModel.Undefined.DisplayName();
        var result2 = ArticleTypeEnumModel.Travel.DisplayName();
        var result3 = ArticleTypeEnumModel.Books.DisplayName();
        var result4 = ArticleTypeEnumModel.News.DisplayName();
        var result5 = ArticleTypeEnumModel.Music.DisplayName();
        var result6 = ArticleTypeEnumModel.Food.DisplayName();

        // Assert
        Assert.That(Equals("", result1));
        Assert.That(Equals("Travel", result2));
        Assert.That(Equals("Books", result3));
        Assert.That(Equals("News", result4));
        Assert.That(Equals("Music", result5));
        Assert.That(Equals("Food", result6));
    }
}

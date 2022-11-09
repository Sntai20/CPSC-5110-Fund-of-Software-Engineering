using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    /// <summary>
    /// Test class for ArticleTypeEnumExtensions
    /// </summary>
    public class ArticleTypeEnumExtensions
    {

        [Test]
        public void ArticleTyepEnum_Valid_Null_ID_Should_Return_True()
        {
            // Arrange

            // Act
            var result1 = ArticleTypeEnum.Undefined.DisplayName();
            var result2 = ArticleTypeEnum.Travel.DisplayName();
            var result3 = ArticleTypeEnum.Books.DisplayName();
            var result4 = ArticleTypeEnum.News.DisplayName();
            var result5 = ArticleTypeEnum.Music.DisplayName();
            var result6 = ArticleTypeEnum.Food.DisplayName();

            // Assert
            Assert.AreEqual("", result1);
            Assert.AreEqual("Travel", result2);
            Assert.AreEqual("Books", result3);
            Assert.AreEqual("News", result4);
            Assert.AreEqual("Music", result5);
            Assert.AreEqual("Food", result6);

        }
    }
}

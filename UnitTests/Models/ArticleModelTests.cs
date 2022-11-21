using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTests.Models
{

    /// <summary>
    /// Test class for ArticleModel
    /// </summary>
    public class ArticleModelTests
    {

        /// <summary>
        /// Method to test valid input of an article
        /// </summary>
        [Test]
        public void ToString_Valid_Null_ID_Should_Return_True()
        {
            // Arrange
            var data = TestHelper.ArticleService.GetAllData().First(x => x.Id == "jenlooper-cactus");

            // Act
            var result = TestHelper.ArticleService.GetAllData().First();

            // Assert
            Assert.AreEqual(data.ToString(), result.ToString());

        }
    }
}

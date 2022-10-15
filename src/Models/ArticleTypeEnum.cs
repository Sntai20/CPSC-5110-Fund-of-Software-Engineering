using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public enum ArticleTypeEnum
    {
        Undefined = 0,
        Amature = 1,
        Antique = 5,
        Collectable = 130,
        Commercial = 55,
    }

    public static class ArticleTypeEnumExtensions
    {
        public static string DisplayName(this ArticleTypeEnum data)
        {
            return data switch
            {
                ArticleTypeEnum.Amature => "Hand Made Items",
                ArticleTypeEnum.Antique => "Antiques",
                ArticleTypeEnum.Collectable => "Collectables",
                ArticleTypeEnum.Commercial => "Commercial goods",
 
                // Default, Unknown
                _ => "",
            };
        }
    }
}
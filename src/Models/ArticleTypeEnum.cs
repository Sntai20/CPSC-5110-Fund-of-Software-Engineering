using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public enum ArticleTypeEnum
    {
        Undefined = 0,
        Travel = 1,
        Books = 5,
        News = 130,
        Music = 55,
        Food = 63,
    }

    public static class ArticleTypeEnumExtensions
    {
        public static string DisplayName(this ArticleTypeEnum data)
        {
            return data switch
            {
                ArticleTypeEnum.Travel => "Hand Made Items",
                ArticleTypeEnum.Books => "Books",
                ArticleTypeEnum.News => "News",
                ArticleTypeEnum.Music => "Music",
                ArticleTypeEnum.Food => "Food",
 
                // Default, Unknown
                _ => "",
            };
        }
    }
}
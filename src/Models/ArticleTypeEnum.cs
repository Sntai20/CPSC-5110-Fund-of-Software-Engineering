namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Define an enum for type Article. 
    /// </summary>
    public enum ArticleTypeEnum
    {
        Undefined = 0,
        Travel = 1,
        Books = 5,
        News = 130,
        Music = 55,
        Food = 63,
    }
    /// <summary>
    /// Define Article Type enum extensions. 
    /// </summary>
    public static class ArticleTypeEnumExtensions
    {
        /// <summary>
        /// Display name of the Article type enum. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DisplayName(this ArticleTypeEnum data)
        {
            return data switch
            {
                ArticleTypeEnum.Travel => "Travel",
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

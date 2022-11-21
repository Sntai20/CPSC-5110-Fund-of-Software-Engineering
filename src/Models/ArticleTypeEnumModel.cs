namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Define an enum for type Article. 
    /// </summary>
    public enum ArticleTypeEnumModel
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
        /// <returns>An article type as a string.</returns>
        public static string DisplayName(this ArticleTypeEnumModel data)
        {
            return data switch
            {
                ArticleTypeEnumModel.Travel => "Travel",
                ArticleTypeEnumModel.Books => "Books",
                ArticleTypeEnumModel.News => "News",
                ArticleTypeEnumModel.Music => "Music",
                ArticleTypeEnumModel.Food => "Food",

                // Default, Unknown
                _ => "",
            };
        }
    }
}

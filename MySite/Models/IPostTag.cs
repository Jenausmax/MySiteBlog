using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public interface IPostTag
    {
        /// <summary>
        /// Коллекция тегов которые присутствуют у поста.
        /// </summary>
        List<Tag> Tags { get; }
        
        
        /// <summary>
        /// Коллекция тегов из базы.(Все теги из базы).
        /// </summary>
        List<Tag> OldTags { get; set; }
        
        
        /// <summary>
        /// Кеш для сохранения тега, при добавлении к несохраненному посту.
        /// </summary>
        static List<string> TempTag { get; set; }
        

        /// <summary>
        /// Метод поиска тегов у выбранного поста.
        /// </summary>
        /// <param name="id">ID поста.</param>
        void GetTagString(int id);
        

        /// <summary>
        /// Метод добавления тега в кеш коллекцию тегов.
        /// </summary>
        /// <param name="tag">Строка тега.</param>
        void SetTempTag(string tag);
    }
}

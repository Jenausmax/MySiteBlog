using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class PostTag : IPostTag
    {
        /// <summary>
        /// Теги которые присутствуют у поста.
        /// </summary>
        public List<Tag> Tags { get; } = new List<Tag>();//что есть сейчас у поста
        /// <summary>
        /// Коллекция тегов из базы.(Все теги из базы)
        /// </summary>
        public List<Tag> OldTags { get; set; } = new List<Tag>();//все теги из базы

        /// <summary>
        /// Кеш для сохранения тега, при добавлении к несохраненному посту.
        /// </summary>
        public static List<string> TempTag { get; set; } = new List<string>();

        private readonly IPost _repository;
        public PostTag(IPost repository)
        {
            _repository = repository;
            OldTags = _repository.Tags.ToList();
        }

        /// <summary>
        /// Метод поиска тегов у выбранного поста.
        /// </summary>
        /// <param name="id">ID поста.</param>
        public void GetTagString(int id)
        {
            
            var post = _repository.Posts.Include(t => t.Tags).ToList().FirstOrDefault(p => p.Id == id);
            if(post != null)
            {
                
                string resultString = null;
                foreach (var item in post.Tags.ToList())
                {
                    resultString = $"{resultString}, {item.TitleTag}";
                    Tags.Add(item);
                }
                
            }

        }

        /// <summary>
        /// Метод добавления тега в кеш коллекцию.
        /// </summary>
        /// <param name="tag">Строка тега.</param>
        public void SetTempTag(string tag)
        {
            TempTag.Add(tag);
        }


        

    }
}

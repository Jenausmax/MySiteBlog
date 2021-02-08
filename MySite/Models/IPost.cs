using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public interface IPost
    {
        /// <summary>
        /// Коллекция постов из базы.
        /// </summary>
        IQueryable<Post> Posts { get; }
        
        
        /// <summary>
        /// Коллекция тегов из базы.
        /// </summary>
        IQueryable<Tag> Tags { get; }

        /// <summary>
        /// Метод сохранения поста.
        /// </summary>
        /// <param name="post">Сущность пост.</param>
        /// <param name="tags">Коллекцию строк тегов.</param>
        void SavePost(Post post, List<string> tags);
        
        
        /// <summary>
        /// Метод удаления поста.
        /// </summary>
        /// <param name="postId">ID поста.</param>
        /// <returns>Сущность пост.</returns>
        Post DeletePost(int postId);
        
        
        /// <summary>
        /// Метод добавления первоначальных данных в базу.
        /// </summary>
        void SeedDataBase();
        
    }
}

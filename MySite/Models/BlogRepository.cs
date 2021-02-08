using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MySite.Models
{
    public class BlogRepository : IPost
    {
        private BlogDbContext _blogDb;

        public BlogRepository(BlogDbContext blogDb)
        {
            _blogDb = blogDb;
        }

        /// <summary>
        /// Коллекция всех постов.
        /// </summary>
        public IQueryable<Post> Posts => _blogDb.Posts;//выгрузка постов
        /// <summary>
        /// Коллекция всех тегов.
        /// </summary>
        public IQueryable<Tag> Tags => _blogDb.Tags;//выгрузка тегов
       

        /// <summary>
        /// Метод сохранения поста.
        /// </summary>
        /// <param name="post">Сущность пост.</param>
        /// <param name="tags">Коллекция строк тегов.</param>
        public void SavePost(Post post, List<string> tags)
        {
            var tempTag = new List<Tag>();
            foreach (var item in tags)
            {
                tempTag.Add(new Tag() { TitleTag = item });
            }

            if (post.Id == 0)
            {
                foreach (var item in tempTag)
                {
                    post.Tags.Add(item);
                }

                _blogDb.Posts.Add(post);
                PostTag.TempTag.Clear();
            }
            else
            {
                
                var dbEntry = _blogDb.Posts.FirstOrDefault(p => p.Id == post.Id);
                if (dbEntry != null)
                {
                    dbEntry.NamePost = post.NamePost;
                    dbEntry.DescriptionPost = post.DescriptionPost;
                    dbEntry.Time = post.Time;
                    dbEntry.ImagePatch = post.ImagePatch;
                    foreach (var item in tempTag)
                    {
                        dbEntry.Tags.Add(item);
                    }
                }
                PostTag.TempTag.Clear();
            }

            Save();
        }

        
        private void Save()
        {
            _blogDb.SaveChanges();
        }

        
        /// <summary>
        /// Метод удаления поста из базы.
        /// </summary>
        /// <param name="postId">ID поста.</param>
        /// <returns>Возвращение удаленного поста.</returns>
        public Post DeletePost(int postId)
        {
            var postRemove = _blogDb.Posts.FirstOrDefault(p => p.Id == postId);

            if(postRemove != null)
            {
                _blogDb.Remove(postRemove);
                Save();
            }

            return postRemove;
        }

        /// <summary>
        /// Метод загрузки первоначальных данных в базу
        /// </summary>
        public void SeedDataBase()
        {
            var tagSeed = new Tag();
            tagSeed.TitleTag = "Seed";
            var tagSeed2 = new Tag();
            tagSeed2.TitleTag = "Seed2";
            _blogDb.Tags.Add(tagSeed);
            _blogDb.Tags.Add(tagSeed2);
            var postSeed = new Post();
            postSeed.NamePost = "Lorem Ipsum";
            postSeed.DescriptionPost = "Lorem Ipsum to do..";
            postSeed.Tags.Add(tagSeed);
            postSeed.Tags.Add(tagSeed2);
            postSeed.Time = "20.02.2020";
            postSeed.ImagePatch = "/image/Unknown.png";
            _blogDb.Posts.Add(postSeed);

            Save();
        }

        /// <summary>
        /// Метод сохранения и создания из строки тега в базу.
        /// </summary>
        /// <param name="tag">Строка тег</param>
        public void SaveTag(string tag)
        {
            var temp = new Tag() { TitleTag = tag };
            var tempResult = _blogDb.Tags.FirstOrDefault(x => x.TitleTag == temp.TitleTag);
            if(tempResult != null)
            {
                return;
                
            }
            else
            {
                _blogDb.Tags.Add(temp);
            }
            
            Save();

        }
    }
}

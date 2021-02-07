using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class PostTag : IPostTag
    {
        public List<Tag> Tags { get; } = new List<Tag>();//что есть сейчас у поста
        public List<Tag> OldTags { get; set; } = new List<Tag>();//все теги из базы

        public static List<string> TempTag { get; set; } = new List<string>();//кеш для сохранения

        private readonly IPost _repository;
        public PostTag(IPost repository)
        {
            _repository = repository;
            OldTags = _repository.Tags.ToList();
        }

       
        public string GetTagString(int id)
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
                
                return resultString;
            }
            else
            {
               
                return "no tags...";
            }
        }

        public void SetTempTag(string tag)
        {
            TempTag.Add(tag);
        }


        

    }
}

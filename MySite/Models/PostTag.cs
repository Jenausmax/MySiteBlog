using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class PostTag
    {
        public List<Tag> Tags { get; } 
        public List<Post> Posts { get; }
        public Post Post { get; }
        public string StringTag { get; }
        private readonly BlogRepository _repository;
        public PostTag(BlogRepository repository)
        {
            _repository = repository;
            Tags = new List<Tag>();
            Posts = new List<Post>();
            Posts = _repository.Posts.ToList();
            GetTag();
            
        }

        public void GetTag()
        {
            string StringTag = null;
            foreach (var itemTPost in Posts)
            {
                foreach (var tagItem in itemTPost.Tags)
                {
                    StringTag = $"{StringTag}, {tagItem.TitleTag}";
                }
                
            }

            
        }
    }
}

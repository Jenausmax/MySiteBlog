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
        //public ICollection<Post> Posts { get; }

        public BlogRepository(BlogDbContext blogDb)
        {
            _blogDb = blogDb;
        }
        IQueryable<Post> IPost.Posts()
        {

            return _blogDb.Posts.ToList().AsQueryable();
        }

        public void SavePost(Post post, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}

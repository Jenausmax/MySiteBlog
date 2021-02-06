using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public interface IPost
    {
        IQueryable<Post> Posts { get; }
        IQueryable<Tag> Tags { get; }

        void SavePost(Post post);
        Post DeletePost(int postId);
        void SeedDataBase();

    }
}

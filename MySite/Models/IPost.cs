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
        IQueryable<HelpPost> HelpPosts { get; }
        void SavePost(Post post, List<Tag> tag);
        void SaveHelpPost(HelpPost helpPost);
        Post DeletePost(int postId);
        
    }
}

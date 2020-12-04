using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public interface IPost
    {
        IQueryable<Post> Posts();
        IQueryable<Tag> Tags();
        void SavePost(Post post, List<Tag> tag);
        
    }
}

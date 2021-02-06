using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models.ViewModel
{
    public class CreatePostModel
    {
        public Post Post { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}

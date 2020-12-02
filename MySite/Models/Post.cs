using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string NamePost { get; set; }
        public string DescriptionPost { get; set; }
        public string Time { get; set; }
        public object Image { get; set; }

    }
}

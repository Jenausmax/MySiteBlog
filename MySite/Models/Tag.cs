using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TitleTag { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        
    }
}

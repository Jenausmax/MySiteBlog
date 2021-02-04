using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public interface ITagsLogic
    {
        public List<Tag> GetTags(string stringTag);
    }
}

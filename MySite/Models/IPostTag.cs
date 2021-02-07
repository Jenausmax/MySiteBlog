using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public interface IPostTag
    {
        List<Tag> Tags { get; }
        List<Tag> OldTags { get; set; }
        static List<string> TempTag { get; set; }
        string GetTagString(int id);
        void SetTempTag(string tag);
    }
}

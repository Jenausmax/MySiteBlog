using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class PostLogic : ITagsLogic
    {
        private IPost _postRepository;
        public PostLogic(IPost postRepo)
        {
            _postRepository = postRepo;
        }

        public List<Tag> GetTags(string stringTag)
        {
            string[] strTag = stringTag.Split(',');
            List<Tag> tags = new List<Tag>();
            foreach (var itemStringTag in strTag)
            {
                tags.Add(new Tag(itemStringTag));
            }

            List<Tag> repoTags = _postRepository.Tags.ToList(); //коллекция получена из базы
            List<Tag> resultTags = new List<Tag>();//выходная коллекция которая будет добавляться в базу

            foreach (var itemTag in repoTags)
            {
                var res = tags.FirstOrDefault(t => t.TitleTag == itemTag.TitleTag);
                if(res == null)
                {
                    resultTags.Add(itemTag);
                }
            }

            return resultTags;
        }
    }
}

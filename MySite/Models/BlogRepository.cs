﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MySite.Models
{
    public class BlogRepository : IPost
    {
        private BlogDbContext _blogDb;


        public BlogRepository(BlogDbContext blogDb)
        {
            _blogDb = blogDb;
        }
        public IQueryable<Post> Posts => _blogDb.Posts;

        public IQueryable<Tag> Tags => _blogDb.Tags;
        public IQueryable<HelpPost> HelpPosts => _blogDb.HelpPosts;


        public void SavePost(Post post, List<Tag> tags)
        {
            if (post != null)
            {
                _blogDb.Posts.Add(post);

                if (tags != null)
                {
                    foreach (var item in tags)
                    {
                        var tag = _blogDb.Tags.Where(i => i.TitleTag != item.TitleTag);
                        if (tag != null)
                        {
                            _blogDb.Tags.Add(item);
                        }

                        post.Tags.Add(item);

                    }
                }
            }

            Save();
        }

        private void Save()
        {
            _blogDb.SaveChanges();
        }

        public void SaveHelpPost(HelpPost helpPost)
        {
            if(helpPost != null)
            {
                _blogDb.Add(helpPost);
                Save();
            }
        }

        public Post DeletePost(int postId)
        {
            var postRemove = _blogDb.Posts.FirstOrDefault(p => p.Id == postId);

            if(postRemove != null)
            {
                _blogDb.Remove(postRemove);
                Save();
            }

            return postRemove;
        }
    }
}

using System;
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
       


        public void SavePost(Post post)
        {
            if (post.Id == 0)
            {
                _blogDb.Posts.Add(post);
            }
            else
            {
                
                var dbEntry = _blogDb.Posts.FirstOrDefault(p => p.Id == post.Id);
                if (dbEntry != null)
                {
                    dbEntry.NamePost = post.NamePost;
                    dbEntry.DescriptionPost = post.DescriptionPost;
                    dbEntry.Time = post.Time;
                    dbEntry.ImagePatch = post.ImagePatch;
                }
            }

            Save();
        }

        private void Save()
        {
            _blogDb.SaveChanges();
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

        public void SeedDataBase()
        {
            var tagSeed = new Tag("Seed");
            _blogDb.Tags.Add(tagSeed);
            var postSeed = new Post();
            postSeed.NamePost = "Lorem Ipsum";
            postSeed.DescriptionPost = "Lorem Ipsum to do..";
            postSeed.Tags.Add(tagSeed);
            postSeed.Time = "20.02.2020";
            postSeed.ImagePatch = "/image/";
            _blogDb.Posts.Add(postSeed);
            Save();
        }
    }
}

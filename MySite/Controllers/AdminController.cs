using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models;
using Microsoft.AspNetCore.Http;

namespace MySite.Controllers
{
    public class AdminController : Controller
    {
        private IPost _postRepository;
        private ITagsLogic _tagsLogic;

        public AdminController(IPost repo, ITagsLogic logic)
        {
            _postRepository = repo;
            _tagsLogic = logic;
        }
        
        [HttpGet]
        [Route("Admin/List")]
        public IActionResult List()
        {
            return View(_postRepository.Posts);
        }

        [Route("Admin/Create")]
        public IActionResult Create() => View("Edit", new Post());

        [Route("Admin/Edit")]
        public IActionResult Edit(int id)
        {
            return View(_postRepository.Posts.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [Route("Admin/Edit")]
        public IActionResult Edit(Post post, IFormFile uploadedFile = null)
        {
            if (ModelState.IsValid)
            {

                _postRepository.SavePost(post);
                TempData["message"] = $"{post.NamePost} has been saved.";
                return RedirectToAction("List");
            }
            else
            {
                return View(post);
            }
        }

        [Route("Admin/Delete")]
        public IActionResult Delete(int postId)
        {
            var deletePost = _postRepository.DeletePost(postId);
            if (deletePost != null)
            {
                TempData["message"] = $"{deletePost.NamePost} was deleted.";
            }

            return RedirectToAction("List");
        }

        [Route("Admin/SeedDataBase")]
        public IActionResult SeedDataBase()
        {
            _postRepository.SeedDataBase();
            return RedirectToAction(nameof(List));
        }
    }
}

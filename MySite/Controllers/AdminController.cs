using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models;

namespace MySite.Controllers
{
    public class AdminController : Controller
    {
        private IPost _postRepository;

        public AdminController(IPost repo)
        {
            _postRepository = repo;
        }
        
        [HttpGet]
        [Route("Admin/List")]
        public IActionResult List()
        {
            return View(_postRepository.Posts());
        }

        public IActionResult Create() => View("Edit", new Post());

        public IActionResult Edit(Post post, string tag)
        {
            if (ModelState.IsValid)
            {
                string[] strTag = tag.Split(',');
                List<Tag> tags = new List<Tag>();
                foreach (var itemStringTag in strTag)
                {
                    tags.Add(new Tag(itemStringTag));
                }

                List<Tag> repoTags = _postRepository.Tags().ToList();
                
                
                _postRepository.SavePost(post);
                TempData["message"] = $"{post.NamePost} has been saved.";
                return RedirectToAction("List");
            }
            else
            {
                return View(post);
            }
        }
    }
}

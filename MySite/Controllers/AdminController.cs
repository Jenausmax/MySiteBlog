using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace MySite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPost _postRepository;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IPostTag _postTag;

        public AdminController(IPost repo, IWebHostEnvironment appEnvironment, IPostTag post)
        {
            _postRepository = repo;
            _appEnvironment = appEnvironment;
            _postTag = post;
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
        public async Task<IActionResult> Edit(Post post, IFormFile uploadedFile = null)
        {
            if (ModelState.IsValid)
            {
                var postFileURL = post;
                if (uploadedFile != null)
                {
                    // путь к папке Files
                    string path = "/image/" + uploadedFile.FileName;
                    
                    // сохраняем файл в папку image в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    postFileURL.ImagePatch = path;
                }
                else
                {
                    //заглушка если нет файла
                    postFileURL.ImagePatch = "/image/Unknown.png";
                }
                
                _postRepository.SavePost(postFileURL, PostTag.TempTag ); //сохранение обновленного поста в базе
                
                TempData["message"] = $"{post.NamePost} has been saved.";
                return RedirectToAction("List");
            }
            else
            {
                return View(post);
            }
        }



        [HttpPost]
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
            //метод загрузки первоначальных данных в базу если база пуста
            _postRepository.SeedDataBase();
            return RedirectToAction(nameof(List));
        }



        [HttpPost]
        [Route("Admin/AddTag")]
        public IActionResult AddTag(string tag)
        {
            _postTag.SetTempTag(tag);
            _postRepository.SaveTag(tag);
            return View();
        }
    }
}

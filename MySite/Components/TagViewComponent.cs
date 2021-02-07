using Microsoft.AspNetCore.Mvc;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Components
{
    public class TagViewComponent : ViewComponent
    {
        private IPostTag _postTag;

        public TagViewComponent(IPostTag post)
        {
            _postTag = post;
        }

        public IViewComponentResult Invoke(int Id)
        {
            _postTag.GetTagString(Id);
            return View(_postTag);
        }
    }
}

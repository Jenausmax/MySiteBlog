using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a post name.")]
        public string NamePost { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        public string DescriptionPost { get; set; }
        [Required(ErrorMessage = "Please enter a time.")]
        public string Time { get; set; }
        public string ImagePatch { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();

    }
}

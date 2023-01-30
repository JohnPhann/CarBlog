using CarBlog2.Models;
using System.Collections.Generic;

namespace CarBlog2.ModelView
{
    public class HomeViewModel
    {
        public List<Post> Populars { get; set; }
        public List<Post> Inspiration { get; set; }
        public List<Post> Recents { get; set; }
        public Post Feature { get; set; }
    }
}

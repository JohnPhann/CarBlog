using System;
using System.Collections.Generic;

#nullable disable

namespace CarBlog2.Models
{
    public partial class Category
    {
        public int CastId { get; set; }
        public string CastName { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public string Thumb { get; set; }
        public bool Published { get; set; }
        public int? Ordering { get; set; }
        public int? Parent { get; set; }
        public int? Levels { get; set; }
        public string Icon { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
    }
}

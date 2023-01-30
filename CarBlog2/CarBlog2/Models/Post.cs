using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CarBlog2.Models
{
    public partial class Post
    {
        
        public int? PostId { get; set; }
        public string Tite { get; set; }
        public string Contents { get; set; }
        public string Thumb { get; set; }
        public string Thumb1 { get; set; }
        public string Thumb2 { get; set; }
        public bool Published { get; set; }
        public string Alias { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Author { get; set; }
        public int? AccountId { get; set; }
        public string ShortContent { get; set; }
        public string Tag { get; set; }
        public int? CastId { get; set; }
        public bool IsHot { get; set; }
        public bool IsNewfeed { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Cast { get; set; }
    }
}

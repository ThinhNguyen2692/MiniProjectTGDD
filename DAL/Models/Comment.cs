using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string ProductId { get; set; } = null!;
        public string? CommentDescription { get; set; }
        public int? Rating { get; set; }
        public string? CustomerName { get; set; }
        public string? UserPhone { get; set; }
        public string? UserCity { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}

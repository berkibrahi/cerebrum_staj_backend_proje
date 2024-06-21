using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int UserId { get; set; }

        

        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}



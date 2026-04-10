using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCForumApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int TopicId { get; set; }
        [ForeignKey("TopicId")] 
        public virtual Topic? Topic { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }


        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}

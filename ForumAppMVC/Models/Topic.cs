using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCForumApp.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Created at")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]

        [Display(Name = "Author")]
        public virtual User? User { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public int RepliesCount { get; set; }
        public void IncrementReplies()
        {
            RepliesCount++;
        }

    }

}

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

        [Display(Name = "Author")]

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User? User { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }

    }

}

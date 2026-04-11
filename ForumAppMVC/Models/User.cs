using System.ComponentModel.DataAnnotations;

namespace MVCForumApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Login { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Password { get; set; }

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}

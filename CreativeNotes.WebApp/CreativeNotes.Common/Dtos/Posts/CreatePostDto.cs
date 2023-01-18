using System.ComponentModel.DataAnnotations;

namespace CreativeNotes.Common.Dtos.Posts
{
    public class CreatePostDto
    {
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
    }
}

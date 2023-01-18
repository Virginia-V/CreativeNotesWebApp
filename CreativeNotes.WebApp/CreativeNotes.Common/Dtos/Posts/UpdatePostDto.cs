using System.ComponentModel.DataAnnotations;

namespace CreativeNotes.Common.Dtos.Posts
{
    public class UpdatePostDto
    {
        [StringLength(300)]
        public string Description { get; set; }
    }
}

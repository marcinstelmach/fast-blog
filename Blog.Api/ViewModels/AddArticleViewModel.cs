using System.ComponentModel.DataAnnotations;

namespace Blog.Api.ViewModels
{
    public class AddArticleViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
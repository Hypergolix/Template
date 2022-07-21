using System.ComponentModel.DataAnnotations;

namespace WebAPITemplate.Api.Models
{
    public class InputWebAPIClass
    {
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}

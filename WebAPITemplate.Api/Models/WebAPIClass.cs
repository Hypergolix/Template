using System.ComponentModel.DataAnnotations;

namespace WebAPITemplate.Api.Models
{
    public class WebAPIClass
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}

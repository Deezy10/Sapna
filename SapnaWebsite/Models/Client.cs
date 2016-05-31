using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [Required]
        public string Address { get; set; }

        public IFormFile Logo { get; set; }

        public ICollection<ProjectClient> ProjectClients { get; set; } = new HashSet<ProjectClient>();
    }
}

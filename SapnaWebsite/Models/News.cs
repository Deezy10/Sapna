using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class News
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        
        public string details { get; set; }

        public IFormFile photo { get; set; }
    }
}

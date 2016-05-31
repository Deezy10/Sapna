using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        public string Name { get; set; }

        public IFormFile Ducument { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
    }
}

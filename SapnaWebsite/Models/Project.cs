using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }
        
        public string Description { get; set; }
        
        public string TechnologiesUsed { get; set; }
        
        public string Title { get; set; }

        public ICollection<ProjectSkill> ProjectSkills { get; set; } = new HashSet<ProjectSkill>();

        public ICollection<ProjectClient> ProjectClients { get; set; } = new HashSet<ProjectClient>();

        public ICollection<ProjectMember> ProjectMembers { get; set; } = new HashSet<ProjectMember>();
    }
}

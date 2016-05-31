using SapnaWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.ViewModels.Projects
{
    public class EditProjectViewModel
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string TechnologiesUsed { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }

        public int[] SkillIds { get; set; }

        public List<Skill> SkillsList { get; set; }

        public int[] Members { get; set; }

        public List<Member> MembersList { get; set; }
    }
}

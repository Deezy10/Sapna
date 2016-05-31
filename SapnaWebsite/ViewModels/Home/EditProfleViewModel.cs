using SapnaWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.ViewModels.Home
{
    public class EditProfleViewModel
    {
        [Required]
        public int MemberId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public DateTime SapnaStartYear { get; set; }

        [Required]
        public DateTime? SchoolGraduationDate { get; set; }
        
        public byte[] ProfilePicture { get; set; }
        
        public int[] Skills { get; set; }
        
        public List<Skill> SkillList{ get; set; }
        
        public int[] Specializations { get; set; }

        public List<Specialization> SpecializationList {get;set; }
        
        public int[] Projects { get; set; }
        
        public List<Project> ProjectList { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        
        public int UserId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Major { get; set; }

        public DateTime SapnaStartYear { get; set; }

        public DateTime? SchoolGraduationDate { get; set; }

        public bool? IsApprove { get; set; }

        public IFormFile ProfilePicture { get; set; }
        
        public User User {get;set;}

        public ICollection<MemberSkill> MemberSkills{ get; set; } = new HashSet<MemberSkill>();

        public ICollection<MemberSpecialization> MemberSpecialization {get;set; } = new HashSet<MemberSpecialization>();

        public ICollection<ProjectMember> ProjectMembers { get; set; } = new HashSet<ProjectMember>();
    }
}

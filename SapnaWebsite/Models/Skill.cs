using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class Skill
    {
        public int SkillId { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        public IFormFile Logo { get; set; }

        public ICollection<ProjectSkill> ProjectSkills { get; set; } = new HashSet<ProjectSkill>();

        public ICollection<MemberSkill> MemberSkills { get; set; } = new HashSet<MemberSkill>();
    }
}

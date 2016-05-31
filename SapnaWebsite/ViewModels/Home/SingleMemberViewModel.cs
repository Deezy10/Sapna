using System.Collections.Generic;
using SapnaWebsite.Models;

namespace SapnaWebsite.ViewModels.Home
{
    public class SingleMemberViewModel
    {
        public Member Member {get;set;}
        
        public IEnumerable<Project> Projects { get; set; }
        
        public IEnumerable<Skill> Skills { get; set; }
        
        public IEnumerable<Specialization> Specializations { get; set; }
    }
}

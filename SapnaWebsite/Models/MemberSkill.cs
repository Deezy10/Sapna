namespace SapnaWebsite.Models
{
    public class MemberSkill
    {
        public int MemberId { get; set; }
        
        public Member Member { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}

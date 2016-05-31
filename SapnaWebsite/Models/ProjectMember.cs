namespace SapnaWebsite.Models
{
    public class ProjectMember
    {
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}

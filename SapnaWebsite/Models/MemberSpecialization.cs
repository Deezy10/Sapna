namespace SapnaWebsite.Models
{
    public class MemberSpecialization
    {
        public int MemberId { get; set; }

        public Member Member { get; set; }

        public int SpecializationId { get; set; }

        public Specialization Specialization { get; set; }
    }
}

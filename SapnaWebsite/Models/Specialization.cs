using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SapnaWebsite.Models
{
    public class Specialization
    {
        public int SpecializationId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string SchoolOrSapna { get; set; }

        public ICollection<MemberSpecialization> MemberSpecialization { get; set; } = new HashSet<MemberSpecialization>();
    }
}

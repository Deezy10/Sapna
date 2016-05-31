using SapnaWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace SapnaWebsite.Repositories
{
    public class SkillRepository
    {
        private EFDbContext _context;

        public SkillRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Skill> GetAll()
        {
            return _context.Skills.ToList();
        }
    }
}

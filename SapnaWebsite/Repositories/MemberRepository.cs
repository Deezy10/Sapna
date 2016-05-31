using SapnaWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace SapnaWebsite.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private EFDbContext _context;

        public MemberRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }
    }
}

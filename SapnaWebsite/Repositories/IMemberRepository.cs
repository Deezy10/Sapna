using System.Collections.Generic;
using SapnaWebsite.Models;

namespace SapnaWebsite.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
    }
}
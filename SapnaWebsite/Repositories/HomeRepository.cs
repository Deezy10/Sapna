using System.Linq;
using SapnaWebsite.Models;
using SapnaWebsite.ViewModels.Home;

namespace SapnaWebsite.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private EFDbContext _context;
        
        public HomeRepository(EFDbContext context)
        {
            _context = context;
        }
        
        public HomeViewModel GetHomeData()
        {
            var data = new HomeViewModel();
            
            data.Projects = _context.Projects.OrderByDescending(x => x.DateCompleted).Take(3);
            data.Events = _context.Events.OrderByDescending(x => x.DatePosted).Take(3);
            data.News = _context.News.OrderByDescending(x => x.DatePosted).Take(3);
            
            return data;
        }
    }
}
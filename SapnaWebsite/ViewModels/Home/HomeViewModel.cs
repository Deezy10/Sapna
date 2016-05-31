using System.Collections.Generic;
using SapnaWebsite.Models;

namespace SapnaWebsite.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}

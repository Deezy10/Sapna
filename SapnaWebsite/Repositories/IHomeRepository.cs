using SapnaWebsite.ViewModels.Home;

namespace SapnaWebsite.Repositories
{
    public interface IHomeRepository
    {
        HomeViewModel GetHomeData();
    }
}
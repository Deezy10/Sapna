using System.Threading.Tasks;

namespace SapnaWebsite.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

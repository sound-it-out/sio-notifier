using System.Threading.Tasks;

namespace SIO.Domain.Notifications.Builders
{
    public interface IRazorViewBuilder
    {
        Task<string> BuildAsync(string template, object model);
    }
}

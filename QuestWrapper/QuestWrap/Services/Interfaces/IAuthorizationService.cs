using System.Threading.Tasks;
using QuestWrap.Models;

namespace QuestWrap.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResult> Authorize(AuthorizationInfo authInfo);
    }
}

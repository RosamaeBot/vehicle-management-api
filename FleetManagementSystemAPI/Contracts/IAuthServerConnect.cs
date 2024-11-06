using System.Threading.Tasks;

namespace FleetManagementAPI.Contracts
{
    public interface IAuthServerConnect
    {
        Task<string> RequestClientCredentialsTokenAsync();
    }
}

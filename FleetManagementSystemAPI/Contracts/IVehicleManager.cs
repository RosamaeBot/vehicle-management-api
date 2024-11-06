using FleetManagementAPI.Data;
using FleetManagementAPI.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagementAPI.Contracts
{
    public interface IFleetManager : IRepository<Fleet>
    {

        //Add more class specific methods here when neccessary
    }
}

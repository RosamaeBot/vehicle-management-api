using FleetManagementAPI.Contracts;
using FleetManagementAPI.Data.Entity;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FleetManagementAPI.Data.DataManager
{
    public class FleetManager : DbFactoryBase, IFleetManager
    {

        private readonly ILogger<FleetManager> _logger;
        public FleetManager(IConfiguration config, ILogger<FleetManager> logger) : base(config)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Fleet>> GetAllAsync()
        {
            return await DbQueryAsync<Fleet>("SELECT * FROM Fleet");
        }

        public async Task<Fleet> GetByIdAsync(object id)
        {
            return await DbQuerySingleAsync<Fleet>("SELECT * FROM Fleet WHERE ID = @ID;", new { id });
        }

        public async Task<long> CreateAsync(Fleet Fleet)
        {
            string sqlQuery = $@"INSERT INTO Fleet (Make, Model, Price) 
                                     VALUES (@Make, @Model, @Price)
                                     SELECT CAST(SCOPE_IDENTITY() as bigint);";

            return await DbQuerySingleAsync<long>(sqlQuery, Fleet);
        }
        public async Task<bool> UpdateAsync(Fleet Fleet)
        {
            string sqlQuery = $@"IF EXISTS (SELECT 1 FROM Fleet WHERE ID = @ID) 
                                            UPDATE Fleet SET Make = @Make, Model = @Model, Price = @Price
                                            WHERE ID = @ID";

            return await DbExecuteAsync<bool>(sqlQuery, Fleet);
        }
        public async Task<bool> DeleteAsync(object id)
        {
            string sqlQuery = $@"IF EXISTS (SELECT 1 FROM Fleet WHERE ID = @ID)
                                        DELETE Fleet WHERE ID = @ID";

            return await DbExecuteAsync<bool>(sqlQuery, new { id });
        }
        public async Task<bool> ExistAsync(object id)
        {
            return await DbExecuteScalarAsync("SELECT COUNT(1) FROM Fleet WHERE ID = @ID", new { id });
        }

    }
}
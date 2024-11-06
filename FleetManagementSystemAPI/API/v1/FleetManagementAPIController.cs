using FleetManagementAPI.Contracts;
using FleetManagementAPI.Data;
using FleetManagementAPI.Data.Entity;
using FleetManagementAPI.DTO.Request;
using FleetManagementAPI.DTO.Response;
using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace FleetManagementAPI.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FleetsController : ControllerBase
    {
        private readonly ILogger<FleetsController> _logger;
        private readonly IFleetManager _FleetManager;
        private readonly IMapper _mapper;

        public FleetsController(IFleetManager FleetManager, IMapper mapper, ILogger<FleetsController> logger)
        {
            _FleetManager = FleetManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FleetQueryResponse>), Status200OK)]
        public async Task<IEnumerable<FleetQueryResponse>> Get()
        {
            var data = await _FleetManager.GetAllAsync();
            var Fleets = _mapper.Map<IEnumerable<FleetQueryResponse>>(data);

            return Fleets;
        }

        [Route("{id:long}")]
        [HttpGet]
        [ProducesResponseType(typeof(FleetQueryResponse), Status200OK)]
        [ProducesResponseType(typeof(FleetQueryResponse), Status404NotFound)]
        public async Task<FleetQueryResponse> Get(long id)
        {
            var Fleet = await _FleetManager.GetByIdAsync(id);
            return Fleet != null ? _mapper.Map<FleetQueryResponse>(Fleet)
                                  : throw new ApiProblemDetailsException($"Record with id: {id} does not exist.", Status404NotFound);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Post([FromBody] CreateFleetRequest createRequest)
        {
            if (!ModelState.IsValid) { throw new ApiProblemDetailsException(ModelState); }

            var Fleet = _mapper.Map<Fleet>(createRequest);
            return new ApiResponse("Record successfully created.", await _FleetManager.CreateAsync(Fleet), Status201Created);
        }

        [Route("{id:long}")]
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
        public async Task<ApiResponse> Put(long id, [FromBody] UpdateFleetRequest updateRequest)
        {
            if (!ModelState.IsValid) { throw new ApiProblemDetailsException(ModelState); }

            var Fleet = _mapper.Map<Fleet>(updateRequest);
            Fleet.Id = id;

            if (await _FleetManager.UpdateAsync(Fleet))
            {
                return new ApiResponse($"Record with Id: {id} sucessfully updated.", true);
            }
            else
            {
                throw new ApiProblemDetailsException($"Record with Id: {id} does not exist.", Status404NotFound);
            }
        }
        [Route("{id:long}")]
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse), Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), Status404NotFound)]
        public async Task<ApiResponse> Delete(long id)
        {
            if (await _FleetManager.DeleteAsync(id))
            {
                return new ApiResponse($"Record with Id: {id} sucessfully deleted.", true);
            }
            else
            {
                throw new ApiProblemDetailsException($"Record with id: {id} does not exist.", Status404NotFound);
            }
        }
    }
}
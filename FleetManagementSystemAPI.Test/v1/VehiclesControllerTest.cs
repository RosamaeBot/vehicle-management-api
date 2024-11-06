using FleetManagementAPI.API.v1;
using FleetManagementAPI.Contracts;
using FleetManagementAPI.Data.Entity;
using FleetManagementAPI.DTO.Response;
using FleetManagementAPI.DTO.Request;
using FleetManagementAPI.Infrastructure.Configs;
using AutoMapper;
using AutoWrapper.Wrappers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FleetManagementAPI.Test.v1
{
    public class FleetsControllerTests
    {
        private readonly Mock<IFleetManager> _mockDataManager;
        private readonly FleetsController _controller;

        public FleetsControllerTests()
        {
            var logger = Mock.Of<ILogger<FleetsController>>();

            var mapperProfile = new MappingProfileConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
            var mapper = new Mapper(configuration);

            _mockDataManager = new Mock<IFleetManager>();

            _controller = new FleetsController(_mockDataManager.Object, mapper, logger);
        }
        private CreateFleetRequest FakeCreateRequestObject()
        {
            return new CreateFleetRequest()
            {
                Make = "Toyota",
                Model = "Camry",
                Price = 100.00
            };
        }
        private IEnumerable<Fleet> GetFakeFleetLists()
        {
            return new List<Fleet>
                {
                    new Fleet()
                    {
                        Id = 1,
                        Make = "Toyota",
                        Model = "Camry",
                        Price = 100.00,
                        FleetType = new FleetType()
                        {
                            Id = 1,
                            FleetName = "Car"
                        }
                    },
                    new Fleet()
                    {
                        Id = 2,
                        Make = "Toyota",
                        Model = "Camry",
                        Price = 100.00,
                        FleetType = new FleetType()
                        {
                            Id = 2,
                            FleetName = "Car"
                        }
                    }
                };
        }

        private UpdateFleetRequest FakeUpdateRequestObject()
        {
            return new UpdateFleetRequest()
            {
                Make = "Toyota",
                Model = "Camry",
                Price = 100.00,
            };
        }
        [Fact]
        public async Task GET_All_RETURNS_OK()
        {

            // Arrange
            _mockDataManager.Setup(manager => manager.GetAllAsync())
               .ReturnsAsync(GetFakeFleetLists());

            // Act
            var result = await _controller.Get();

            // Assert
            var Fleets = Assert.IsType<List<FleetQueryResponse>>(result);
            Assert.Equal(2, Fleets.Count);
        }

        [Fact]
        public async Task GET_ById_RETURNS_OK()
        {
            long id = 1;

            _mockDataManager.Setup(manager => manager.GetByIdAsync(id))
               .ReturnsAsync(GetFakeFleetLists().Single(p => p.Id.Equals(id)));

            var Fleet = await _controller.Get(id);
            Assert.IsType<FleetQueryResponse>(Fleet);
        }

        [Fact]
        public async Task POST_Create_RETURNS_OK()
        {

            _mockDataManager.Setup(manager => manager.CreateAsync(It.IsAny<Fleet>()))
                .ReturnsAsync(It.IsAny<long>());

            var Fleet = await _controller.Post(FakeCreateRequestObject());

            var response = Assert.IsType<ApiResponse>(Fleet);
            Assert.Equal(201, response.StatusCode);
        }
        [Fact]
        public async Task PUT_ById_RETURNS_OK()
        {
            _mockDataManager.Setup(manager => manager.UpdateAsync(It.IsAny<Fleet>()))
                 .ReturnsAsync(true);

            var Fleet = await _controller.Put(1, FakeUpdateRequestObject());

            var response = Assert.IsType<ApiResponse>(Fleet);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task PUT_ById_RETURNS_NOTFOUND()
        {
            var apiException = await Assert.ThrowsAsync<ApiProblemDetailsException>(() => _controller.Put(10, FakeUpdateRequestObject()));
            Assert.Equal(404, apiException.StatusCode);
        }

        [Fact]
        public async Task PUT_ById_RETURNS_BADREQUEST()
        {
            _controller.ModelState.AddModelError("DateOfBirth", "Required");

            var apiException = await Assert.ThrowsAsync<ApiProblemDetailsException>(() => _controller.Put(10, FakeUpdateRequestObject()));
            Assert.Equal(422, apiException.StatusCode);
        }

        [Fact]
        public async Task PUT_ById_RETURNS_SERVERERROR()
        {

            _mockDataManager.Setup(manager => manager.UpdateAsync(It.IsAny<Fleet>()))
                .Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(() => _controller.Put(10, FakeUpdateRequestObject()));
        }
        [Fact]
        public async Task DELETE_ById_RETURNS_OK()
        {
            long id = 1;

            _mockDataManager.Setup(manager => manager.DeleteAsync(id))
                 .ReturnsAsync(true);

            var result = await _controller.Delete(id);

            var response = Assert.IsType<ApiResponse>(result);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task DELETE_ById_RETURNS_NOTFOUND()
        {
            var apiException = await Assert.ThrowsAsync<ApiProblemDetailsException>(() => _controller.Delete(1));
            Assert.Equal(404, apiException.StatusCode);
        }

        [Fact]
        public async Task DELETE_ById_RETURNS_SERVERERROR()
        {
            long id = 1;

            _mockDataManager.Setup(manager => manager.DeleteAsync(id))
                .Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(() => _controller.Delete(id));
        }
    }

}
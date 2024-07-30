using Moq;
using TESTS.Mock;
using DATAACCESS.Repo;
using DATAACCESS.Models;
using WEBAPI.Controllers;
using SERVICES.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Implementations;
using Microsoft.Extensions.Configuration;

namespace TESTS.Tests
{
    public class CreditTests
    {
        private Mock<ICofidisRepo> repo;
        private ICreditManager manager;
        private CreditController controller;
        private IChaveMovelDigitalManager digitalManager;
        private readonly IConfiguration configuration;

        public CreditTests()
        {
            UserData data = new UserMock().UserData;

            repo = new Mock<ICofidisRepo>();

            repo.Setup(x => x.ExecuteStoredProcedure());

            digitalManager = new ChaveMovelDigitalManager();
            manager = new CreditManager(digitalManager, repo.Object);
            controller = new CreditController(manager);
        }

        [Fact]
        public async Task CreateCreditOK()
        {
            // Arrange
            int nif = 5;

            //Act
            IActionResult response = await controller.Create(nif);

            // Assert
            OkObjectResult actionResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(200, actionResult.StatusCode);
            Assert.IsType<OkObjectResult>(actionResult);

            UserData responseObj = Assert.IsType<UserData>(actionResult.Value);
            Assert.NotNull(responseObj);
            Assert.Equal(2, responseObj.Credits.Count);
        }

        [Fact]
        public async Task CreateCreditInvalidNif()
        {
            // Arrange
            int nif = 0;

            //Act
            IActionResult response = await controller.Create(nif);

            // Assert
            OkObjectResult actionResult = Assert.IsType<OkObjectResult>(response);

            Assert.Equal(200, actionResult.StatusCode);
            Assert.IsType<OkObjectResult>(actionResult);

            UserData responseObj = Assert.IsType<UserData>(actionResult.Value);
            Assert.NotNull(responseObj);
            Assert.Empty(responseObj.Credits);
        }
    }
}

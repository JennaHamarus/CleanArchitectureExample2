using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.WebAPI.Controllers;
using CleanArchitectureExample.WebAPI.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CleanArchitectureExample.WebAPI.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task RegisterUserAsync_ReturnsCreatedResult_WhenRegistrationSucceeds()
        {
            //Arrange

            //Mockataan IUserRegistrationService-rajapinnan RegisterUserAsync-metodi
            var mockService = new Mock<IUserRegistrationService>();

            //Simuloi rekisteröintiä, joka onnistuu
            mockService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                       .ReturnsAsync(true); //Simuloi onnistunutta rekisteröintiä

            //Luo UsersController-olion ja antaa sille mockattu IUsersRegistrationService-olion
            var controller = new UsersController(mockService.Object);

            //Act
            var result = await controller.RegisterUserAsync(new UserRegistrationRequest { Name = "Testi", Email = "testi@testi.com" });

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task RegisterUserAsync_ReturnsBadRequest_WhenRegistrationFails()
        {
            //Arrange
            var mockService = new Mock<IUserRegistrationService>();

            //Simuloi rekisteröintiä, joka epäonnistuu
            mockService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false); //Simuloi epäonnistunutta rekisteröintiä

            var controller = new UsersController(mockService.Object);

            //Act
            var result = await controller.RegisterUserAsync(new UserRegistrationRequest { Name = "Testi", Email = "fail@test.com" });

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using CleanArchitectureExample.Application.Services;
using CleanArchitectureExaple.Domain.Interfaces;
using CleanArchitectureExaple.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Tests
{
    public class UserRegistrationServiceTests
    {
        [Fact]
        public async Task RegisterUserAsync_ReturnsFalse_IfEmailExists()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.EmailExistsAsync(It.IsAny<string>())).ReturnsAsync(true);

            var service = new UserRegistrationService(mockRepo.Object);

            //Act
            var result = await service.RegisterUserAsync("Test User", "test@example.com");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task RegisterUserAsync_ReturnsTrue_IfRegistrationSucceeds()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.EmailExistsAsync(It.IsAny<string>())).ReturnsAsync(false);
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            var service = new UserRegistrationService(mockRepo.Object);

            //Act
            var result = await service.RegisterUserAsync("New User", "new@example.com");

            //Assert
            Assert.True(result);
        }
    }
}

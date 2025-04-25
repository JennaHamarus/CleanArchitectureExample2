using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExaple.Domain.Entities;
using CleanArchitectureExaple.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public UserRegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(string name, string email)
        {
            var user = new User { Id = Guid.NewGuid(), Name = name, Email = email };
            _userRepository.Add(user);
        }
    }
}

using CleanArchitectureExample.Application.Dtos;
using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.Application.Mapper;
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

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepository.EmailExistsAsync(email);
        }

        public async Task<bool> RegisterUserAsync(string name, string email)
        {
            try
            {
                if (await EmailExistsAsync(email))
                {
                    return false; //Sähköposti on jo käytössä
                }

                var user = new User { Id = Guid.NewGuid(), Name = name, Email = email };
                await _userRepository.AddAsync(user);
                return true; //Rekisteröinti onnistui
            }
            catch (ApplicationException)
            {
                return false;
            }
        }
        public async Task <UserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user != null? UserMapper.ToDto(user) : null;
        }
    }
}

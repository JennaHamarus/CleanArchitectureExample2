using CleanArchitectureExample.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToDto(UserDto user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}

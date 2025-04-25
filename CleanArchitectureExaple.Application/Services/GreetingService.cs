using CleanArchitectureExaple.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExaple.Application.Services
{
    public class GreetingService : IGreetingService
    {
        public string Greet(string name)
        {
            return $"Hello, {name}!";
        }
    }
}

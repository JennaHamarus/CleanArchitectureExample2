﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExaple.Domain.ValueObjects
{
    internal class EmailAddress
    {
        private string _value;

        public EmailAddress(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Core.Exceptions
{
    public class CreateUserFailedException : Exception
    {
        public CreateUserFailedException() : base("Create User Failed")
        {

        }
    }
}

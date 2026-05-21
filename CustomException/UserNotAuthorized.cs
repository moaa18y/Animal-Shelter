using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.CustomException
{
    internal class UserNotAuthorized : Exception
    {
        public UserNotAuthorized() : base("User not authorized")
        {
        }
    }
}

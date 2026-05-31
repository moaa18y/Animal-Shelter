using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.src.Shared.CustomException
{
    internal class UserNotAuthorized : AppException
    {
        public UserNotAuthorized() : base("User not authorized")
        {
        }
    }
}

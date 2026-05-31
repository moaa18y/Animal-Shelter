using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.src.Shared.CustomException
{
    internal class UserNotFoundException : AppException
    {
        public UserNotFoundException() : base("User not found") {
        
        }
    }
}

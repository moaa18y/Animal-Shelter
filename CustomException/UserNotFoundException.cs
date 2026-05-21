using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.CustomException
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found") {
        
        }
    }
}

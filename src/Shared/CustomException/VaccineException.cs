using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.CustomException
{
    public class VaccineException : AppException
    {
        public VaccineException(string msg):base(msg) { }
    }
}

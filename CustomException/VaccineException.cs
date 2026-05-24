using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.CustomException
{
    public class VaccineException:Exception
    {
        public VaccineException(string msg):base(msg) { }
    }
}

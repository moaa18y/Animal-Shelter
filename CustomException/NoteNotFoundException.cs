using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.CustomException
{
    public class NoteNotFoundException:Exception
    {
        public NoteNotFoundException():base("Note Not Found") { }
    }
}

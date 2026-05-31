using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Shared.CustomException
{
    public class NoteNotFoundException : AppException
    {
        public NoteNotFoundException():base("Note Not Found") { }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalShelter.Dto
{
    public class GetCareNoteDto
    {

       public int id {  get; set; }

        public string Title { get; set; }

        
        public string Description { get; set; }
    }
}

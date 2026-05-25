using Animal_Shelter_V2.src.Models;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface ICareNoteRepo
    {
        void AddCareNote(CareNote careNote);
        CareNote GetById(int id);
        void RemoveCareNote(int id);
    }
}
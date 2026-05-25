namespace AnimalShelter.src.Services.Interfaces
{
    public interface ICareNoteService
    {
        void AddCareNote(int animalId, string note);
        void DeleteCareNote(int careNoteId);
    }
}
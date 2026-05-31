namespace AnimalShelter.src.Shared.CustomException
{
    public class AdoptionNotFoundException : AppException
    {
        public AdoptionNotFoundException()
            : base("Adoption not found")
        {
        }
    }
}
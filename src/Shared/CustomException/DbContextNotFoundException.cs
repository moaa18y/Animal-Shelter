namespace AnimalShelter.src.Shared.CustomException
{
    public class DbContextNotFoundException : AppException
    {
        public DbContextNotFoundException(string contextName)
            : base($"Database context '{contextName}' was not found.")
        {
        }
    }
}
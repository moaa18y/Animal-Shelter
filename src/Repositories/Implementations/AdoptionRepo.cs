namespace Animal_Shelter.src.Repositories.Implementations
{
    public class AdoptionRepo
    {
        private readonly AppDBContext _dbContext;
        public AdoptionRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            
        }
        public void AddAdoption(Adoption adoption)
        {    
            _dbContext.Adoptions.Add(adoption);
            _dbContext.SaveChanges();
        }
    }
}
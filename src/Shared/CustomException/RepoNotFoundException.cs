using System;
namespace AnimalShelter.src.Shared.CustomException
{
    public class RepoNotFoundException : AppException
    {
        public RepoNotFoundException(string repoName)
            : base($"Repository '{repoName}' was not found.")
        {
        }
        
    }
}
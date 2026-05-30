using System;
namespace AnimalShelter.CustomException
{
    public class RepoNotFoundException: Exception
    {
        public RepoNotFoundException(string repoName)
            : base($"Repository '{repoName}' was not found.")
        {
        }
        
    }
}
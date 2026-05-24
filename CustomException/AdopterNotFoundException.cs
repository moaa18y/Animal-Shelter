using System;

namespace AnimalShelter.CustomException
{
    public class AdopterNotFoundException : Exception
    {
        public AdopterNotFoundException(string adopterUserName, string adopterEmail)
            : base(BuildMessage(adopterUserName, adopterEmail))
        {
        }

        private static string BuildMessage(string adopterUserName, string adopterEmail)
        {
            if (!string.IsNullOrWhiteSpace(adopterUserName) && !string.IsNullOrWhiteSpace(adopterEmail))
            {
                return $"No adopter user was found for user name '{adopterUserName}' and email '{adopterEmail}'.";
            }

            if (!string.IsNullOrWhiteSpace(adopterUserName))
            {
                return $"No adopter user was found for user name '{adopterUserName}'.";
            }

            return $"No adopter user was found for email '{adopterEmail}'.";
        }
    }
}
using AnimalShelter.CustomException;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Animal_Shelter_V2.src.Validators
{
    public static class DtoValidator
    {
        public static void Validate(object dto)
        {
            if (dto == null)
                throw new InvalidDtoException("Request cannot be null.");

            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(dto, context, results, true))
            {
                var message = string.Join("; ", results.ConvertAll(result => result.ErrorMessage ?? "Validation failed"));
                throw new InvalidDtoException(message);
            }
        }
    }
}
using Animal_Shelter_V2.src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



public  class Animal :BaseEntity      //: ICareRecord, IAdoptable
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 30, ErrorMessage = "Age must be between 0 and 30.")]
        public int Age { get; set; }


        public string Status { get; set; }=AnimalStatus.Available.ToString();// Default status is set to "Available"


        public List<Vaccine> Vaccines { get; set; }

       

        // Constructor to initialize the animal with required properties
        //protected Animal(int id, string name, int age, AnimalStatus status= AnimalStatus.Available)
        //{
        //    Id = id;
        //    Name = name;
        //    Age = age;
        //    Status = status;
        //    IntakeDate = DateTime.Now;
        //    _adopterName = string.Empty;
        //    _vaccineInfo = string.Empty;
        //    _careHistory = new StringBuilder();
        //}

        //public abstract string GetSpeciesInfo();
        
        
        
        //// ICareRecord implementation

        //public void AddCareNote(string note)
        //{
        //    if (string.IsNullOrWhiteSpace(note))
        //        throw new ArgumentException("Care note cannot be null or empty.", nameof(note));
        //    _careHistory.AppendLine($"{DateTime.Now:yyyy-MM-dd HH:mm}: {note.Trim()}");
        //}
        
        //public string GetCareHistory() => _careHistory.ToString().Trim();

        //public void UpdateVaccineInfo(string vaccineInfo)
        //{
        //    if (string.IsNullOrWhiteSpace(vaccineInfo))
        //        throw new ArgumentException("Vaccine info cannot be null or empty.", nameof(vaccineInfo));
        //    VaccineInfo = vaccineInfo.Trim();
        //    AddCareNote($"Vaccine info updated: {VaccineInfo}");
        //}

        ////IAdoptable implementation

        //public bool IsAvailable() => Status == AnimalStatus.Available;

        //public void Adopt(string adopterName)
        //{
        //    if (Status != AnimalStatus.Available && Status != AnimalStatus.PendingAdoption)
        //        throw new InvalidOperationException($"'{Name}' is not available for adoption, Current Status: {Status}");
        //    if(string.IsNullOrWhiteSpace(adopterName))
        //        throw new ArgumentException("Adopter name cannot be null or empty.", nameof(adopterName));
            
        //    AdopterName = adopterName.Trim();
        //    Status = AnimalStatus.Adopted;
        //    AddCareNote($"Adopted by {AdopterName} on {DateTime.Now:yyyy-MM-dd}");
        //}

        //public string GetAdoptionInfo()
        //    => Status == AnimalStatus.Adopted
        //        ? $"Adopted by: {AdopterName}"
        //        : "Not adopted yet";
    }

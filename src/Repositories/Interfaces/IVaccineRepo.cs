using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.src.Repositories.Interfaces
{
    public interface IVaccineRepo
    {
        void AddVaccine(Vaccine vaccine);
        Vaccine GetVaccineById(int id);

        List<Vaccine> GetAllVaccines();

        

        void SaveChange();
    }
}

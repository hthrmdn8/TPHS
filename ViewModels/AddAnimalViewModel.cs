using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TPHS.Models;
using TPHS.Data;


namespace TPHS.ViewModels
{
    public class AddAnimalViewModel
    {
        [Display(Name= "Animal Name")]
        public string Name { get; set; }
       
        [Display(Name = "Allergy List")]
        public string Allergy { get; set; }
      
        [Display(Name = "Vet Sch.")]
        public DateTime Vet { get; set; }
        [Display(Name = "Special Vet")]
        public string SpecialVet { get; set; }
        [Display(Name = "Your animal's species or breed type")]
        public int AnimalTypeID { get; set; }
        public List<SelectListItem> AnimalTypes { get; set; }
        public AddAnimalViewModel(IEnumerable<AnimalSpeciesType> animalTypes)
        {
            AnimalTypes = new List<SelectListItem>();
            foreach(var animalType in animalTypes)
            {
                AnimalTypes.Add(new SelectListItem
                {
                    Value = animalType.ID.ToString(),
                    Text = animalType.Name
                });
            }
        }
        public AddAnimalViewModel() { }

    }
}

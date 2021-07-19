using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TPHS.Models;
namespace TPHS.ViewModels
{
    public class AddAnimalTypeViewModel
    {
    
        [Display(Name = "Animal Breed or Species")]
        public string Name { get; set; }

        
        public AddAnimalTypeViewModel()
        { }
    }
}

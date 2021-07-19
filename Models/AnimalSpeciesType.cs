using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TPHS.Models
{
    public class AnimalSpeciesType
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="You need to fill this out to continue")]
        [Display(Name= "Species or Breed Name")]
        public string Name { get; set; }
        public IList<Animal> Animals { get; set; }
        public AnimalSpeciesType()
        { }
    }
}

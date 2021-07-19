using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TPHS.Models
{
    public class Animal
    {

        public string Name { get; set; }
        public string Allergy { get; set; }
        public DateTime Vet { get; set; }
        public string SpecialVet { get; set; }
        public int ID { get; set; }
        public int AnimalTypeID { get; set; }
        public AnimalSpeciesType AnimalType { get; set; }
        [ForeignKey("ApplicationUser")]
        //public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }

}


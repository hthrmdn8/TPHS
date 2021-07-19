using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TPHS.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string FarmName { get; set; }
        public int AnimalID { get; set; }
        public Animal Animal { get; set; }
        public IList<Animal> Animals { get; set; }

        
    }
}

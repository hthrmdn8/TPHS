using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TPHS.Models;
using TPHS.ViewModels;
using TPHS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.Owin;
using TPHS.Controllers;
 

namespace TPHS.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
        private readonly AnimalDBContext context;
        public AnimalController(AnimalDBContext dbContext)
        {
            context = dbContext;
        }
       
        public IActionResult Index(AddAnimalViewModel addAnimalViewModel)
        {
            IList<Animal> animals = context.Animals.Include(c => c.AnimalType).ToList();
            return View(animals);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddAnimalViewModel addAnimalViewModel =
                new AddAnimalViewModel(context.AnimalTypes.ToList());
            return View(addAnimalViewModel);
        }
        //[Route("/Animal")]
        //[Route("/Animal/Index")]
        [HttpPost]

        public IActionResult Add(AddAnimalViewModel addAnimalViewModel)
        {
            if (User.Identity.IsAuthenticated)

            {
                AnimalSpeciesType newAnimalSpeciesType =
                    context.AnimalTypes.Single(c => c.ID == addAnimalViewModel.AnimalTypeID);

                Animal newAnimal = new Animal()
                {
                    Name = addAnimalViewModel.Name,
                    Allergy = addAnimalViewModel.Allergy,
                    Vet = addAnimalViewModel.Vet,
                    SpecialVet = addAnimalViewModel.SpecialVet,
                    AnimalType = newAnimalSpeciesType
                };
                context.Animals.Add(newAnimal);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View(addAnimalViewModel);
        }
        [HttpGet]

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Animal";
            ViewBag.animals = context.Animals.ToList();
            return View();
        }
        [HttpPost]

        public IActionResult Remove(int[] animalIds)
        {
            foreach(int animalId in animalIds)
            {
                Animal theAnimal = context.Animals.Single(c => c.ID == animalId);
                context.Animals.Remove(theAnimal);
            }
            context.SaveChanges();
            return Redirect("Index");
        }

    }
}
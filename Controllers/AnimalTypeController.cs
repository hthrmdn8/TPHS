using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPHS.Data;
using TPHS.Models;
using TPHS.ViewModels;

namespace TPHS.Controllers
{
    [Authorize]
    public class AnimalTypeController : Controller
    {
        private readonly AnimalDBContext context;
        public AnimalTypeController(AnimalDBContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            IList<AnimalSpeciesType> animalTypes = context.AnimalTypes.ToList();
            return View(animalTypes);
        }
        public IActionResult Add()
        {
            AddAnimalTypeViewModel addAnimalTypeViewModel = new AddAnimalTypeViewModel();
            return View(addAnimalTypeViewModel);
        }

        [HttpPost]
 
        public IActionResult Add(AddAnimalTypeViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                AnimalSpeciesType newAnimalType = new AnimalSpeciesType
                {
                    Name = viewModel.Name
                };
                context.AnimalTypes.Add(newAnimalType);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View(viewModel);
        }



        [HttpGet]

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Animal Type or Breed";
            ViewBag.animalTypes = context.AnimalTypes.ToList();
            return View();
        }
        [HttpPost]

        public IActionResult Remove(int[] animalIds)
        {
            foreach (int animalId in animalIds)
            {
                AnimalSpeciesType SpecificOneToDelete = context.AnimalTypes.Single(c => c.ID == animalId);
                context.AnimalTypes.Remove(SpecificOneToDelete);
            }
            context.SaveChanges();
            return Redirect("Index");
        }


    }

}
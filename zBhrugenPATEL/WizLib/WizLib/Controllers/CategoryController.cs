using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

namespace WizLib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> categories = _dbContext.Categories.ToList(); //IEnumerable car List

            return View(categories);
        }


        [Route("Category/CreateOrUpdate/{categoryId}")]  //Sans la précision de la Route, categoryId arrive systématiquement null !??
        public ActionResult CreateOrUpdate(int? categoryId)
        {
            ActionResult retour;

            Category category;
            if (categoryId == null)
            {
                category = new Category();
                retour = View(category);
            }
            else
            {
                category = _dbContext.Categories.Find(categoryId);
                // ou : category = _dbContext.Categories.FirstOrDefault(categ => categ.Id == id); //Si on utilisait First(...) alors si jamais pas trouvé => une Exception 'Sequence contains no ...' serait générée"
                retour = (category == null) ? NotFound() : View(category);
            }
            return (retour);
        }

        [HttpPost] //correspond à l'action submit de <form method="post"> qui renverra le modèle de données (Category)
        //[ValidateAntiForgeryToken] //juste pour sécurité
        public IActionResult CreateOrUpdateAfterEdit(Category inputtedCategory)
        {
            ActionResult retour;

            if (ModelState.IsValid)
            {
                bool bSave;
                if (inputtedCategory.Id == 0) //Creation
                {
                    _dbContext.Categories.Add(inputtedCategory);
                    bSave = true;

                }
                else
                {
                    //Category categoryInList = _dbContext.Categories.Update(inputtedCategory); //Non fonctionnel
                    Category categoryInList = _dbContext.Categories.Find(inputtedCategory.Id);
                    bSave = (categoryInList != null);
                    if (bSave)
                    {
                        categoryInList.Name = inputtedCategory.Name;
                    }
                    else
                    {
                        //???
                    }
                }
                if (bSave)
                {
                    _dbContext.SaveChanges();
                }
            }
            retour = RedirectToAction(nameof(this.Index));  //nameof(MaVarOuMethod) équivaut renvoie "MaVarOuMethod".
            return (retour);
        }

        [Route("Category/Delete/{myCategoryId}")]    //Sans la précision de la Route, myCategoryId arrive systématiquement null !??
        public IActionResult Delete(int myCategoryId) //Ce param. doit porter le même nom que ci-dessus !
        {
            ActionResult retour;

            Category categoryInList = _dbContext.Categories.Find(myCategoryId);
            bool bSave = (categoryInList != null);
            if (bSave)
            {
                _dbContext.Categories.Remove(categoryInList);
            }
            else
            {
                //???
            }
            if (bSave)
            {
                _dbContext.SaveChanges();
            }
            retour = RedirectToAction(nameof(this.Index));  //nameof(MaVarOuMethod) équivaut renvoie "MaVarOuMethod".
            return (retour);
        }


    }
}

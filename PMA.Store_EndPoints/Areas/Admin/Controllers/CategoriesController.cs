using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PMA.Store_Domain.Categories.Commands;
using PMA.Store_Domain.Categories.Entities;
using PMA.Store_Domain.Categories.Queries;
using PMA.Store_EndPoints.Areas.Admin.Models.Categories;
using PMA.Store_Framework.Commands;
using PMA.Store_Framework.Queries;
using PMA.Store_Framework.Resources.Interface;
using PMA.Store_Framework.Web;

namespace PMA.Store_EndPoints.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoriesController : BaseController
    {
        private const string PhotoUrl = "wwwroot//photos";

        public CategoriesController(CommandDispatcher commandDispatcher, IResourceManager resourceManager, QueryDispatcher queryDispatcher) : base(resourceManager, commandDispatcher, queryDispatcher)
        {
        }
        public IActionResult Index()
        {
            var allCategory = _queryDispatcher.Dispatch<List<Category>>(new AllCategoryQuery());

            return View(allCategory);
        }
        public IActionResult AddCategory()
        {
            var model = new AddCategoryViewModel
            {
                Categories = _queryDispatcher.Dispatch<List<Category>>(new ParentCategoryQuery())
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {

                var fileUrl = new FileSaver.FileSaver().Save(model.Photo, PhotoUrl);
                var result = _commandDispatcher.Dispatch(new AddCategoryCommand
                {
                    Name = model.Name,
                    ParentId = model.ParentId,
                    PhotoUrl = fileUrl
                });
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
                foreach (string item in result.Errors)
                {
                    ModelState.AddModelError("", item);
                }
            }
            return View(model);
        }
    }
}

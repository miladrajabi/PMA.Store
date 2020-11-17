using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMA.Store_Domain.Masters.Commands;
using PMA.Store_Domain.Masters.Entities;
using PMA.Store_Domain.Masters.Queries;
using PMA.Store_EndPoints.Areas.Admin.Models.Masters;
using PMA.Store_Framework.Commands;
using PMA.Store_Framework.Queries;
using PMA.Store_Framework.Resources.Interface;
using PMA.Store_Framework.Web;

namespace PMA.Store_EndPoints.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class MasterController : BaseController
    {
        private const string PhotoUrl = "wwwroot//photos";

        public MasterController(CommandDispatcher commandDispatcher, IResourceManager resourceManager, QueryDispatcher queryDispatcher) : base(resourceManager, commandDispatcher, queryDispatcher)
        {
        }
        public IActionResult Index()
        {
            var allMaster = _queryDispatcher.Dispatch<List<Master>>(new AllMasterQuery());
            return View(allMaster);
        }
        public IActionResult Add()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Add(AddMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fileUrl = new FileSaver.FileSaver().Save(model.Photo, PhotoUrl);
                var res = _commandDispatcher.Dispatch(new AddMasterCommand()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description,
                    ShortDescription = model.ShortDescription,
                    PhotoUrl = fileUrl
                });
                if (res.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", res.Message);
                foreach (string item in res.Errors)
                {
                    ModelState.AddModelError("", item);
                }

            }
            return View();
        }
    }
}

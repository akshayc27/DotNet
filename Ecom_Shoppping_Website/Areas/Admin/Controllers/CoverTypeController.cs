using EcomShopping.DataAccess.Repository.IRepository;
using EcomShopping.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();

            if (id == null)
            {
                //this is to create

                return View(coverType);

            }

            //this is for edit request

            coverType = _unitOfWork.CoverType.Get(id.GetValueOrDefault());

            if(coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }


        public IActionResult Delete(int? id)
        {
            var objFromDb = _unitOfWork.CoverType.Get(id.GetValueOrDefault());
            if (objFromDb == null)
            {
                return Json(new { sucess = false, Message = "Error While deleting" });
            }

            _unitOfWork.CoverType.Remove(objFromDb);
            _unitOfWork.Save();

            //Category category = new Category();
            //category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            //return Json(new { sucess = true, Message = "Delete Sucessful" });
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //writes unique value to httponly cookies then the same value is return to the form.
        //when page is submitted , and if cookie value doesnot match then error is raised.
        //prevent cross-side  request forgery
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                if(coverType.Id == 0)
                {
                    _unitOfWork.CoverType.Add(coverType);
                    
                }
                else
                {
                    _unitOfWork.CoverType.update(coverType);
                    
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(coverType);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            var allObj = _unitOfWork.CoverType.GetAll();

            return Json(new { data = allObj });
        }

        
   

        #endregion



    }
}

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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Upsert(int? id)
        {
            Company company = new Company();

            if (id == null)
            {
                //this is to create

                return View(company);

            }

            //this is for edit request

            company = _unitOfWork.Company.Get(id.GetValueOrDefault());

            if(company == null)
            {
                return NotFound();
            }

            return View(company);
        }


        public IActionResult Delete(int? id)
        {
            var objFromDb = _unitOfWork.Company.Get(id.GetValueOrDefault());
            if (objFromDb == null)
            {
                return Json(new { sucess = false, Message = "Error While deleting" });
            }

            _unitOfWork.Company.Remove(objFromDb);
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
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if(company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                    
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                    
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            var allObj = _unitOfWork.Company.GetAll();

            return Json(new { data = allObj });
        }

        
   

        #endregion



    }
}

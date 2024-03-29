﻿using EcomShopping.DataAccess.Repository.IRepository;
using EcomShopping.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var strng = TempData["Msg"];
            return View();
        }

        
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();

            if (id == null)
            {
                //this is to create

                return View(category);

            }

            //this is for edit request

            category = _unitOfWork.Category.Get(id.GetValueOrDefault());

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        public IActionResult Delete(int? id)
        {
            var objFromDb = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (objFromDb == null)
            {
                return Json(new { sucess = false, Message = "Error While deleting" });
            }

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();

            TempData["Msg"] = "Selected Record Deleted.";
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
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if(category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                    
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                    
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            var allObj = _unitOfWork.Category.GetAll();

            return Json(new { data = allObj });
        }

        
   

        #endregion



    }
}

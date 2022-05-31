using EcomShopping.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using EcomShopping.Models;
using EcomShopping.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i =>
                new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }
                ),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(i =>
                new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }
                )

            };

            if (id == null)
            {
                //this is to create

                return View(productVM);

            }

            //this is for edit request

            productVM.Product = _unitOfWork.Product.Get(id.GetValueOrDefault());

            if(productVM.Product == null)
            {
                return NotFound();
            }

            return View(productVM);
        }


        public IActionResult Delete(int? id)
        {
            var objFromDb = _unitOfWork.Product.Get(id.GetValueOrDefault());
            if (objFromDb == null)
            {
                return Json(new { sucess = false, Message = "Error While deleting" });
            }

            _unitOfWork.Product.Remove(objFromDb);
            _unitOfWork.Save();

            //Product product = new Product();
            //product = _unitOfWork.Product.Get(id.GetValueOrDefault());
            //return Json(new { sucess = true, Message = "Delete Sucessful" });
            return RedirectToAction(nameof(Index));

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////writes unique value to httponly cookies then the same value is return to the form.
        ////when page is submitted , and if cookie value doesnot match then error is raised.
        ////prevent cross-side  request forgery
        //public IActionResult Upsert(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if(product.Id == 0)
        //        {
        //            _unitOfWork.Product.Add(product);
                    
        //        }
        //        else
        //        {
        //            _unitOfWork.Product.Update(product);
                    
        //        }

        //        _unitOfWork.Save();

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(product);
        //}



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {

            var allObj = _unitOfWork.Product.GetAll(includeproperties:"Category,CoverType");

            return Json(new { data = allObj });
        }

        
   

        #endregion



    }
}

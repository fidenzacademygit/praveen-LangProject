using Asp.Versioning;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    
    
    public class AdminViewController(AdminServices service) : Controller
    {
        private readonly AdminServices _service = service;
     
        public ActionResult GetAllCustomers()
        {
            var Customers =  _service.GetAllCustomers();
            return View(Customers);
        }


        // POST: AdminViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }         
    }
}

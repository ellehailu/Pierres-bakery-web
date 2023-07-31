using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using PierresBakery.Models;

namespace PierresBakery.Controllers
{
    public class VendorsController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendors> allVendors = Vendors.GetAll();
            return View(allVendors);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName, string vendorDescription)
        {
            Vendors newVendor = new Vendors(vendorName, vendorDescription);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{vendorsId}")]
        public ActionResult Show(int vendorId)
        {
            Vendors vendor = Vendors.Find(vendorId);
            return View(vendor);
        }

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string orderTitle, string orderDescription, decimal orderPrice, string orderDate)
        {
            Vendors thisVendor = Vendors.Find(vendorId);
            Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
            thisVendor.AddOrder(newOrder);
            return View("Show", thisVendor);
        }
    }
}
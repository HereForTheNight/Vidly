using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new ShowCustomersViewModel
            {

                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult ShowCustomers()
        {
            //var customers = new Customer() { Name = "John Smith" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1", Id = 1, Details = "Details 1"},
                new Customer {Name = "Customer 2", Id = 2, Details = "Details 1"}
            };

            var viewModel = new ShowCustomersViewModel
            {
     
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult CustomerDetails(int? pageIndex, string customerName)
        {
    
        
            if (!pageIndex.HasValue)
            {
                var content = "No Customer";
                return Content(content);
            } else
            {
                var content = customerName;
                return Content(content);
            }

        }


    }
}
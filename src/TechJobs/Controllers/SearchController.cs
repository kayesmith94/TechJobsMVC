using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {   [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        
        [HttpPost]
        public IActionResult Results(string searchTerm, string searchType)
        {
            //in order to process this, it needs input from somewhere. user input will be gotten from the form, passed in here via search term param,
            //and after that we query our data appropriately, returning our results view which will list our queried data.

            ViewBag.title = "Results for "+ searchTerm;
            ViewBag.columns = ListController.columnChoices;

            if (searchType.Equals("all"))
            { 
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }

            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HandItDown.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HandItDown.Models;
using HandItDown.Models.HomeViewModels;

namespace HandItDown.Controllers
{


        public class HomeController : Controller
        {

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {
            _userManager = userManager;
            _context = context;
        }

        //GET: Products/?search="iPod"
        public IActionResult Search(string search)
        {
            List<Book> books = _context.Book //Gets all books from database 
                                    .Where(b => b.Title.Contains(search)) //Filters the ones thats that contain what the search contains
                                    .OrderBy(p => p.Title) //Orders them in alphabetical order
                                    .ToList(); //Turns results into a list
           /* List<Toy> toys = _context.Toy //Gets all books from database 
                                   .Where(b => b.Description.Contains(search)) //Filters the ones thats that contain what the search contains
                                   .OrderBy(p => p.ToyType) //Orders them in alphabetical order
                                   .ToList(); //Turns results into a list */

            HomeIndexViewModel viewModel = new HomeIndexViewModel(); //Creates new view model

            viewModel.Books = books; //Attaches the searched products to the view model
           // viewModel.Toys = toys;

            return View(viewModel); //Sends the view model to the view
        }

        public IActionResult Index()
            {
                return View();
            }

            public IActionResult About()
            {
                ViewData["Message"] = "Your application description page.";

                return View();
            }

            public IActionResult Contact()
            {
                ViewData["Message"] = "Your contact page.";

                return View();
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
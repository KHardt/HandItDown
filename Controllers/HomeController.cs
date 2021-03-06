﻿using System;
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

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //GET: Products/?search="iPod"
        public IActionResult Search(string search)
        {
            List<Book> books = _context.Book //Gets all books from database 
                                    .Where(b => b.Title.Contains(search) || b.Author.Contains(search))
                                   //Filters the ones thats that contain what the search contains
                                    .OrderBy(p => p.Title) //Orders them in alphabetical order
                                    .ToList(); //Turns results into a list
            List<Toy> toys =  _context.Toy //Gets all books from database 
                                   .Where(b => b.Description.Contains(search) || b.Color.Contains(search))//Filters the ones thats that contain what the search contains
                                   .OrderBy(p => p.ToyType) //Orders them in alphabetical order
                                   .ToList(); //Turns results into a list */
            List<Clothing> clothings = _context.Clothing //Gets all books from database 
                                  .Where(p => p.Description.Contains(search) || p.Color.Contains(search))//Filters the ones thats that contain what the search contains
                                  .OrderBy(p => p.ClothingType) //Orders them in alphabetical order
                                  .ToList(); //Turns results into a list
                                    
            List<Misc> misc = _context.Misc //Gets all books from database 
                                  .Where(b => b.Description.Contains(search)) //Filters the ones thats that contain what the search contains
                                  .OrderBy(p => p.Description) //Orders them in alphabetical order
                                  .ToList(); //Turns results into a li

            List<ClothingType> clothingTypes = _context.ClothingType //Gets all books from database 
                                 .Where(p => p.Label.Contains(search))//Filters the ones thats that contain what the search contains
                                 .OrderBy(p => p.Label) //Orders them in alphabetical order
                                 .ToList(); //Turns results into a list

            List<ToyType> ToyTypes = _context.ToyType //Gets all books from database 
                                .Where(p => p.Label.Contains(search))//Filters the ones thats that contain what the search contains
                                .OrderBy(p => p.Label) //Orders them in alphabetical order
                                .ToList(); //Turns results into a list

            HomeIndexViewModel viewModel = new HomeIndexViewModel(); //Creates new view model

            viewModel.Books = books; //Attaches the searched products to the view model
            viewModel.Toys = toys;
            viewModel.Clothings = clothings;
            viewModel.Miscs = misc;
            viewModel.ClothingTypes = clothingTypes;
            viewModel.ToyTypes= ToyTypes;


            return View(viewModel); //Sends the view model to the view
        }



        public async Task<IActionResult> Wishlist()
        {
            List<Book> books =  await _context.Book //Gets all books from database 
                                  //  .Include(b => b.Title)
                                   .Where(b => b.StatusId == 2)
                                   .ToListAsync(); //Turns results into a list
            Console.WriteLine(books);
            List<Toy> toys =  await _context.Toy 
                                   .Where(b => b.StatusId ==2) 
                                   .OrderBy(p => p.ToyType) 
                                   .ToListAsync(); //Turns results into a list */
            List<Clothing> clothings = await _context.Clothing //Gets all books from database 
                                  .Where(p => p.StatusId == 2)//Filters the ones thats that contain what the search contains
                                  .OrderBy(p => p.ClothingType) //Orders them in alphabetical order
                                  .ToListAsync(); //Turns results into a list

            List<Misc> misc = await _context.Misc //Gets all books from database 
                                  .Where(b => b.StatusId ==2)//Filters the ones thats that contain what the search contains
                                  .OrderBy(p => p.Description) //Orders them in alphabetical order
                                  .ToListAsync(); //Turns results into a list


            HomeIndexViewModel viewModel = new HomeIndexViewModel(); //Creates new view model

            viewModel.Books = books; //Attaches the searched products to the view model
            viewModel.Toys = toys;
            viewModel.Clothings = clothings;
            viewModel.Miscs = misc;
  


            return View(viewModel); //Sends the view model to the view
           
        }


        public async Task<IActionResult> DonatingList()
        {
            List<Book> books = await _context.Book //Gets all books from database 
                                                   //  .Include(b => b.Title)
                                   .Where(b => b.StatusId == 3)
                                   .ToListAsync(); //Turns results into a list
            Console.WriteLine(books);
            List<Toy> toys = await _context.Toy //Gets all books from database      
                                   .Where(b => b.StatusId == 3) //Filters the ones thats that contain what the search contains
                                   .OrderBy(p => p.ToyType) //Orders them in alphabetical order
                                   .ToListAsync(); //Turns results into a list */
            List<Clothing> clothings = await _context.Clothing //Gets all books from database 
                                  .Where(p => p.StatusId == 3)//Filters the ones thats that contain what the search contains
                                  .OrderBy(p => p.ClothingType) //Orders them in alphabetical order
                                  .ToListAsync(); //Turns results into a list

            List<Misc> misc = await _context.Misc //Gets all books from database 
                                  .Where(b => b.StatusId == 3)//Filters the ones thats that contain what the search contains
                                  .OrderBy(p => p.Description) //Orders them in alphabetical order
                                  .ToListAsync(); //Turns results into a li


            HomeIndexViewModel viewModel = new HomeIndexViewModel(); //Creates new view model

            viewModel.Books = books; //Attaches the searched products to the view model
            viewModel.Toys = toys;
            viewModel.Clothings = clothings;
            viewModel.Miscs = misc;



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
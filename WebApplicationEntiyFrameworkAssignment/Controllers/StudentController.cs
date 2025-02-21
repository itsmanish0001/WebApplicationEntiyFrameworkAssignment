﻿using Microsoft.AspNetCore.Mvc;
using WebApplicationEntiyFrameworkAssignment.Models;
using WebApplicationEntiyFrameworkAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEntiyFrameworkAssignment.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Load the Student Form
        public async Task<IActionResult> Create()
        {
            ViewBag.Countries = await _context.Countries.ToListAsync();
            return View();
        }

        // Fetch States Based on Country Name
        [HttpGet]
        public async Task<IActionResult> GetStates(string countryName)
        {
            var states = await _context.States
                                       .Where(s => s.Country.Name == countryName)  // ✅ Filter by name
                                       .Select(s => new { s.Name })  // ✅ Return name only
                                       .ToListAsync();
            return Ok(states);
        }

        // Fetch Cities Based on State Name
        [HttpGet]
        public async Task<IActionResult> GetCities(string stateName)
        {
            var cities = await _context.Cities
                                       .Where(c => c.State.Name == stateName)  // ✅ Filter by name
                                       .Select(c => new { c.Name })  // ✅ Return name only
                                       .ToListAsync();
            return Ok(cities);
        }

        // Save Student Data
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); // Redirect to list page after submission
            }

            ViewBag.Countries = await _context.Countries.ToListAsync();
            return View("Create");
        }
    }
}

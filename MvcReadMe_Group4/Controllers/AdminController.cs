﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcReadMe_Group4.Data;
using MvcReadMe_Group4.Models;

namespace YourProjectNamespace.Controllers
{
    public class AdminController : Controller
    {
        private readonly MvcReadMe_Group4Context _context;

        public AdminController(MvcReadMe_Group4Context context)
        {
            _context = context;
        }

        // GET: /Admin/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            ViewData["Title"] = "Dashboard";

            // Get total users (excluding admins)
            var totalUsers = await _context.Users.CountAsync(u => u.Role == "User");
            ViewBag.TotalUsers = totalUsers;

            // Get total books
            var totalBooks = await _context.Books.CountAsync();
            ViewBag.TotalBooks = totalBooks;

            // Get total reads
            var totalReads = await _context.Books.SumAsync(b => b.NumberOfReads);
            ViewBag.TotalReads = totalReads;

            // Get daily reads for the past week
            var today = DateTime.Today;
            var dailyReads = await _context.BookReads
                .Where(br => br.ReadDate >= today.AddDays(-6) && br.ReadDate <= today)
                .OrderBy(x => x.ReadDate)
                .Select(br => new { Date = br.ReadDate, Count = br.ReadCount })
                .ToListAsync();

            ViewBag.DailyReads = dailyReads;

            // Get category distribution
            var categoryDistribution = await _context.Books
                .GroupBy(b => b.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .ToListAsync();

            ViewBag.CategoryDistribution = categoryDistribution;

            // Get top 7 most popular books
            var popularBooks = await _context.Books
                .OrderByDescending(b => b.NumberOfReads)
                .Take(7)
                .Select(b => new { b.Title, b.CoverImagePath, b.NumberOfReads })
                .ToListAsync();

            ViewBag.PopularBooks = popularBooks;

            return View();
        }

        // GET: /Admin/Developers
        public IActionResult Developers()
        {
            ViewData["Title"] = "Developers";
            return View();
        }

        // GET: /Admin/About
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View();
        }

        // GET: /Admin/GetDashboardData
        public async Task<IActionResult> GetDashboardData()
        {
            // Get total users (excluding admins)
            var totalUsers = await _context.Users.CountAsync(u => u.Role == "User");

            // Get total books
            var totalBooks = await _context.Books.CountAsync();

            // Get total reads
            var totalReads = await _context.Books.SumAsync(b => b.NumberOfReads);

            // Get daily reads for the past week
            var today = DateTime.Today;
            var dailyReads = await _context.BookReads
                .Where(br => br.ReadDate >= today.AddDays(-6) && br.ReadDate <= today)
                .OrderBy(x => x.ReadDate)
                .Select(br => new { date = br.ReadDate, count = br.ReadCount })
                .ToListAsync();

            // Get category distribution
            var categoryDistribution = await _context.Books
                .GroupBy(b => b.Category)
                .Select(g => new { category = g.Key, count = g.Count() })
                .ToListAsync();

            // Get top 7 most popular books
            var popularBooks = await _context.Books
                .OrderByDescending(b => b.NumberOfReads)
                .Take(7)
                .Select(b => new { 
                    title = b.Title, 
                    coverImagePath = b.CoverImagePath, 
                    numberOfReads = b.NumberOfReads 
                })
                .ToListAsync();

            return Json(new {
                totalUsers,
                totalBooks,
                totalReads,
                dailyReads,
                categoryDistribution,
                popularBooks
            });
        }
    }
}

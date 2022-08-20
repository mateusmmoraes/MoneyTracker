﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Models;

namespace MoneyTracker.Controllers
{
    public class BalancesController : Controller
    {
        private readonly MoneyTrackerContext _context;

        public BalancesController(MoneyTrackerContext context)
        {
            _context = context;
        }

        // GET: Balances
        public async Task<IActionResult> Index()
        {
              return _context.Balances != null ? 
                          View(await _context.Balances.ToListAsync()) :
                          Problem("Entity set 'MoneyTrackerContext.Balances'  is null.");
        }

        // GET: Balances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Balances == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // GET: Balances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Balances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountName,Id,Value,Timestamp")] Balance balance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(balance);
        }

        // GET: Balances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Balances == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }
            return View(balance);
        }

        // POST: Balances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountName,Id,Value,Timestamp")] Balance balance)
        {
            if (id != balance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceExists(balance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(balance);
        }

        // GET: Balances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Balances == null)
            {
                return NotFound();
            }

            var balance = await _context.Balances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // POST: Balances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Balances == null)
            {
                return Problem("Entity set 'MoneyTrackerContext.Balances'  is null.");
            }
            var balance = await _context.Balances.FindAsync(id);
            if (balance != null)
            {
                _context.Balances.Remove(balance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceExists(int id)
        {
          return (_context.Balances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

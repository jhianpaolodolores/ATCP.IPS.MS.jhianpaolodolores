using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCP.IPS.MS.jhianpaolodolores.Model.Dto;
using ATCP.IPS.MS.jhianpaolodolores.Model.Entity;

namespace ATCP.IPS.MS.jhianpaolodolores.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
              return _context.Customers != null ?
                          View(await _context.Customers.DefaultIfEmpty().ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Customers'  is null.");
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerDto = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerDto == null)
            {
                return NotFound();
            }

            return View(customerDto);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,MiddleName,LastName,Address,Age,Gender,CreatedBy,CreatedDttm,UpdatedBy,UpdatedDttm,IsActive")] CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerDto);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerDto = await _context.Customers.FindAsync(id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return View(customerDto);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,MiddleName,LastName,Address,Age,Gender,CreatedBy,CreatedDttm,UpdatedBy,UpdatedDttm,IsActive")] CustomerDto customerDto)
        {
            if (id != customerDto.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerDtoExists(customerDto.CustomerId))
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
            return View(customerDto);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customerDto = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerDto == null)
            {
                return NotFound();
            }

            return View(customerDto);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'AppDbContext.Customers'  is null.");
            }
            var customerDto = await _context.Customers.FindAsync(id);
            if (customerDto != null)
            {
                _context.Customers.Remove(customerDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerDtoExists(int id)
        {
          return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}

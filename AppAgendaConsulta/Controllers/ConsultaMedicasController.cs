using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAgendaConsulta.Data;
using AppAgendaConsulta.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppAgendaConsulta.Controllers
{
    [Authorize]
    public class ConsultaMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultaMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: ConsultaMedicas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConsultaMedicas.Include(c => c.Medico);
            return View(await applicationDbContext.ToListAsync());
        }

        [AllowAnonymous]
        // GET: ConsultaMedicas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaMedica = await _context.ConsultaMedicas
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaMedica == null)
            {
                return NotFound();
            }

            return View(consultaMedica);
        }

        // GET: ConsultaMedicas/Create
        public IActionResult Create()
        {
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Nome");
            return View();
        }

        // POST: ConsultaMedicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsultaMedica consultaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Nome", consultaMedica.MedicoId);
            //ViewBag.MedicoId = new SelectList(_context.Medicos, "Id", "CPF", consultaMedica.MedicoId);
            //TempData["MedicoId"]= new SelectList(_context.Medicos, "Id", "CPF", consultaMedica.MedicoId);
            return View(consultaMedica);
        }

        // GET: ConsultaMedicas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaMedica = await _context.ConsultaMedicas.FindAsync(id);
            if (consultaMedica == null)
            {
                return NotFound();
            }
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Nome", consultaMedica.MedicoId);
            return View(consultaMedica);
        }

        // POST: ConsultaMedicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ConsultaMedica consultaMedica)
        {
            if (id != consultaMedica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaMedicaExists(consultaMedica.Id))
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
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Nome", consultaMedica.MedicoId);
            return View(consultaMedica);
        }

        // GET: ConsultaMedicas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaMedica = await _context.ConsultaMedicas
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaMedica == null)
            {
                return NotFound();
            }

            return View(consultaMedica);
        }

        // POST: ConsultaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consultaMedica = await _context.ConsultaMedicas.FindAsync(id);
            _context.ConsultaMedicas.Remove(consultaMedica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaMedicaExists(Guid id)
        {
            return _context.ConsultaMedicas.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UberApi.Models.EntityFramework;

namespace UberApi.Controllers
{
    public class ClientController : Controller
    {
        private readonly S221UberContext _context;

        public ClientController(S221UberContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var s221UberContext = _context.Clients.Include(c => c.IdAdresseNavigation).Include(c => c.IdEntrepriseNavigation);
            return View(await s221UberContext.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdAdresseNavigation)
                .Include(c => c.IdEntrepriseNavigation)
                .FirstOrDefaultAsync(m => m.IdClient == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "IdAdresse", "IdAdresse");
            ViewData["IdEntreprise"] = new SelectList(_context.Entreprises, "IdEntreprise", "IdEntreprise");
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClient,IdEntreprise,IdAdresse,GenreUser,NomUser,PrenomUser,DateNaissance,Telephone,EmailUser,MotDePasseUser,PhotoProfile,SouhaiteRecevoirBonPlan,MfaActivee,TypeClient,LastConnexion,DemandeSuppression")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "IdAdresse", "IdAdresse", client.IdAdresse);
            ViewData["IdEntreprise"] = new SelectList(_context.Entreprises, "IdEntreprise", "IdEntreprise", client.IdEntreprise);
            return View(client);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "IdAdresse", "IdAdresse", client.IdAdresse);
            ViewData["IdEntreprise"] = new SelectList(_context.Entreprises, "IdEntreprise", "IdEntreprise", client.IdEntreprise);
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClient,IdEntreprise,IdAdresse,GenreUser,NomUser,PrenomUser,DateNaissance,Telephone,EmailUser,MotDePasseUser,PhotoProfile,SouhaiteRecevoirBonPlan,MfaActivee,TypeClient,LastConnexion,DemandeSuppression")] Client client)
        {
            if (id != client.IdClient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.IdClient))
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
            ViewData["IdAdresse"] = new SelectList(_context.Adresses, "IdAdresse", "IdAdresse", client.IdAdresse);
            ViewData["IdEntreprise"] = new SelectList(_context.Entreprises, "IdEntreprise", "IdEntreprise", client.IdEntreprise);
            return View(client);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.IdAdresseNavigation)
                .Include(c => c.IdEntrepriseNavigation)
                .FirstOrDefaultAsync(m => m.IdClient == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.IdClient == id);
        }
    }
}

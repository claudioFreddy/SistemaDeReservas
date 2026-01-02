using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.Data;
using SistemaDeReservas.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeReservas.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservasController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            IQueryable<Reserva> query = _context.Reservas.Include(r => r.Usuario);

            if (!User.IsInRole("Admin"))
            {
                query = query.Where(r => r.UsuarioId == user.Id);
            }

            var reservas = await query.ToListAsync();
            return View(reservas);
        } 

            /*var reserva = _context.Reservas.Include(r => r.Usuario);

            var usuario = await _userManager.GetUserAsync(User);
            var reservas = await _context.Reservas
                .Include(r => r.Usuario) // 👈 Asegúrate de tener esta línea
                .Where(r => r.UsuarioId == usuario.Id)
                .ToListAsync();

            return View(reservas);  */
        

        // GET: Reservas/Create
        public async Task<IActionResult> Create()
        {
            var usuario = await _userManager.GetUserAsync(User);
            ViewBag.NombreUsuario = usuario?.NombreCompleto ?? "Usuario no identificado";
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User); // 👈 usuario logueado
                reserva.UsuarioId = user.Id; // 👈 asociar al usuario actual

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }


        
        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _userManager.GetUserAsync(User);
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuario.Id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // GET: Reservas/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _userManager.GetUserAsync(User);
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuario.Id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaReserva,Motivo,Estado")] Reserva reserva)
        {
            var usuario = await _userManager.GetUserAsync(User);
            var original = await _context.Reservas
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuario.Id);

            if (original == null) return NotFound();

            if (ModelState.IsValid)
            {
                original.FechaReserva = reserva.FechaReserva;
                original.Motivo = reserva.Motivo;
                original.Estado = reserva.Estado;

                _context.Update(original);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _userManager.GetUserAsync(User);
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuario.Id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _userManager.GetUserAsync(User);
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.Id == id && r.UsuarioId == usuario.Id);

            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}




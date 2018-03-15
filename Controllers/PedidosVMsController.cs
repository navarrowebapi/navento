using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navento.Data;
using Navento.Models;

namespace Navento.Controllers
{
    public class PedidosVMsController : Controller
    {
        private readonly NaventoContext _context;

        public PedidosVMsController(NaventoContext context)
        {
            _context = context;
        }

        // GET: PedidosVMs
        public async Task<IActionResult> Index()
        {
            var naventoContext = _context.PedidosVms.Include(p => p.Pedido);
            return View(await naventoContext.ToListAsync());
        }

        // GET: PedidosVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosVM = await _context.PedidosVms
                .Include(p => p.Pedido)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pedidosVM == null)
            {
                return NotFound();
            }

            return View(pedidosVM);
        }

        // GET: PedidosVMs/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id");
            return View();
        }

        // POST: PedidosVMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Preco,Quantidade,Total,PedidoId")] PedidosVM pedidosVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidosVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidosVM.PedidoId);
            return View(pedidosVM);
        }

        // GET: PedidosVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosVM = await _context.PedidosVms.SingleOrDefaultAsync(m => m.Id == id);
            if (pedidosVM == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidosVM.PedidoId);
            return View(pedidosVM);
        }

        // POST: PedidosVMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Preco,Quantidade,Total,PedidoId")] PedidosVM pedidosVM)
        {
            if (id != pedidosVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidosVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosVMExists(pedidosVM.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", pedidosVM.PedidoId);
            return View(pedidosVM);
        }

        // GET: PedidosVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidosVM = await _context.PedidosVms
                .Include(p => p.Pedido)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pedidosVM == null)
            {
                return NotFound();
            }

            return View(pedidosVM);
        }

        // POST: PedidosVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidosVM = await _context.PedidosVms.SingleOrDefaultAsync(m => m.Id == id);
            _context.PedidosVms.Remove(pedidosVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidosVMExists(int id)
        {
            return _context.PedidosVms.Any(e => e.Id == id);
        }
    }
}

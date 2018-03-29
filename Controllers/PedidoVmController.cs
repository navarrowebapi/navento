using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Navento.Data;
using Navento.Models;

namespace Navento.Controllers
{
    public class PedidoVmController : Controller
    {
        private readonly NaventoContext _context;

        public PedidoVmController(NaventoContext context)
        {
            _context = context;
        }

        // GET: PedidoVm
        public IActionResult Index()
        {
            var pedidosVmList = new List<PedidoVm>();
            return View();
        }

        // GET: PedidoVm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoVm/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            ViewData["Produtos"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: PedidoVm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoVm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoVm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoVm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoVm/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
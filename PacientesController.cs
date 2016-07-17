using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PacienteNet.Models;

namespace PacienteNet.Areas.Cadastro.Controllers
{
    public class PacientesController : Controller
    {
        private modelEntities db = new modelEntities();

        // GET: Cadastro/Pacientes
        public async Task<ActionResult> Index()
        {
            return View(await db.PacienteSet.ToListAsync());
        }

        // GET: Cadastro/Pacientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await db.PacienteSet.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Cadastro/Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPaciente,NomPaciente,NomMae,CPF,RG,DtaNascimento,NumeroCNS,IdFamilia,Casa")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.PacienteSet.Add(paciente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Cadastro/Pacientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await db.PacienteSet.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Cadastro/Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPaciente,NomPaciente,NomMae,CPF,RG,DtaNascimento,NumeroCNS,IdFamilia,Casa")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Cadastro/Pacientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await db.PacienteSet.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Cadastro/Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paciente paciente = await db.PacienteSet.FindAsync(id);
            db.PacienteSet.Remove(paciente);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Pesquisar(string NomePaciente)
        {
            return View();
        }
    }
}

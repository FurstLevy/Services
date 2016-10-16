using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Services.Rest.Client.Models;
using Services.Rest.Client.RestClient;

namespace Services.Rest.Client.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ServicesRestClientContext _db = new ServicesRestClientContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var service = new ServicesRestServer();
            return View(service.GetClientesAnonimo().ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var clientes = _db.Clientes.Find(id);
            if (clientes == null)
                return HttpNotFound();
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNacimento")] Cliente clientes)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(clientes);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var clientes = _db.Clientes.Find(id);
            if (clientes == null)
                return HttpNotFound();
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNacimento")] Cliente clientes)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(clientes).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var clientes = _db.Clientes.Find(id);
            if (clientes == null)
                return HttpNotFound();
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var clientes = _db.Clientes.Find(id);
            _db.Clientes.Remove(clientes);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Services.Rest.Server.Models;

namespace Services.Rest.Server.Controllers
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Clientes
        [Route("BuscarLogado")]
        [Authorize]
        public IQueryable<Cliente> GetClientesLogado()
        {
            return db.Clientes;
        }

        [Route("BuscarAnonimo")]
        [AllowAnonymous]
        public IQueryable<Cliente> GetClientesAnonimo()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult GetClientes(int id)
        {
            var clientes = db.Clientes.Find(id);
            if (clientes == null)
                return NotFound();

            return Ok(clientes);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientes(int id, Cliente clientes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != clientes.Id)
                return BadRequest();

            db.Entry(clientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostClientes(Cliente clientes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Clientes.Add(clientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = clientes.Id}, clientes);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult DeleteClientes(int id)
        {
            var clientes = db.Clientes.Find(id);
            if (clientes == null)
                return NotFound();

            db.Clientes.Remove(clientes);
            db.SaveChanges();

            return Ok(clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ClientesExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}
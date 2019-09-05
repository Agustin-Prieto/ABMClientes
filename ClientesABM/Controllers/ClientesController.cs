using ClientesABM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientesABM.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Clientes.ToList());
            }
        }

        public ActionResult Añadir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Añadir(Clientes Cliente)
        {
            using (DBModel db = new DBModel())
            {
                db.Clientes.Add(Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(Clientes cliente)
        {
            using(DBModel db = new DBModel())
            {
                Clientes clienteaEditar = db.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
                if (clienteaEditar == default(Clientes))
                {
                    throw new Exception("El Cliente no existe");
                }
                clienteaEditar.Nombre = cliente.Nombre;
                db.Entry(clienteaEditar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Clientes clienteaEliminar = db.Clientes.Find(id);

                db.Clientes.Where(c => c.Id == id).FirstOrDefault();

                db.Clientes.Remove(clienteaEliminar);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }
    }
}
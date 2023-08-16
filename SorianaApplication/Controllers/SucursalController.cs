using SorianaApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SorianaApplication.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> listaSucursal = new List<SucursalCLS>();
            using (var bd = new SorianaEntities())
            {
                listaSucursal = (from sucursal in bd.Sucursal
                                 select new SucursalCLS
                                 {
                                     idSucursal = sucursal.idSucursal,
                                     nombre = sucursal.nombre,
                                     direccion = sucursal.direccion,
                                     telefono = sucursal.telefono,
                                     email = sucursal.email,
                                     fechaApertura = (DateTime)sucursal.fechaApertura,
                                     estatus = (int)sucursal.estatus
                                 }).ToList();
            }
            return View(listaSucursal);

        }
        public ActionResult BorrarSucusal(int id)
        {
            using (var bd = new SorianaEntities())
            {
                Sucursal oTabla = bd.Sucursal.Find(id);
                bd.Sucursal.Remove(oTabla);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddSucursal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSucursal(SucursalCLS sucursal)
        {
            if (!ModelState.IsValid)
            {
                return View(sucursal);
            }
            else
            {
                using (var bd = new SorianaEntities())
                {
                    Sucursal oTabla = new Sucursal
                    {
                        nombre = sucursal.nombre,
                        direccion = sucursal.direccion,
                        telefono = sucursal.telefono,
                        email = sucursal.email,
                        fechaApertura = (DateTime)sucursal.fechaApertura,
                        estatus = (int)sucursal.estatus
                    };
                    bd.Sucursal.Add(oTabla);
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditSucursal(int id)
        {

            SucursalCLS oSucursalCLS = new SucursalCLS();
            using (var bd = new SorianaEntities())
            {
                ViewBag.lista = bd.Sucursal.ToList();
                Sucursal oSucursal = bd.Sucursal.Where(p => p.idSucursal.Equals(id)).First();
                oSucursalCLS.idSucursal = oSucursal.idSucursal;
                oSucursalCLS.nombre = oSucursal.nombre;
                oSucursalCLS.direccion = oSucursal.direccion;
                oSucursalCLS.telefono = oSucursal.telefono;
                oSucursalCLS.email = oSucursal.email;
                oSucursalCLS.fechaApertura = (DateTime)oSucursal.fechaApertura;
                oSucursalCLS.estatus = (int)oSucursal.estatus;
            }

            return View(oSucursalCLS);
        }
        [HttpPost]
        public ActionResult EditSucursal(SucursalCLS oSucursalCLS)
        {
            int nregistradosEncontrados = 0;
            int idSucursal = oSucursalCLS.idSucursal;
            //string Nombre = oCliente.NOMBRECLIENTE;
            using (var bd = new SorianaEntities())
            {
                nregistradosEncontrados = bd.Sucursal.Where(p => p.idSucursal.Equals(idSucursal)).Count();
            }
            if (!ModelState.IsValid || nregistradosEncontrados < 1)
            {
                return View(oSucursalCLS);

            }
            using (var bd = new SorianaEntities())
            {
                Sucursal oSucursal = bd.Sucursal.Where(p => p.idSucursal.Equals(idSucursal)).First();
                oSucursal.nombre = oSucursalCLS.nombre;
                oSucursal.direccion = oSucursalCLS.direccion;
                oSucursal.telefono = oSucursalCLS.telefono;
                oSucursal.email = oSucursalCLS.email;
                oSucursal.fechaApertura = oSucursalCLS.fechaApertura;
                oSucursal.estatus = oSucursalCLS.estatus;
                //Guardar en la base de datos
                bd.Sucursal.Add(oSucursal);
                bd.SaveChanges();
                Index();
            }

            return View("Index");
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NiscoutFBL2019.Models;
using System.IO;

namespace NiscoutFBL2019.Controllers
{
    public class Membresia_AdultoController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Membresia_Adulto
        public ActionResult Index()
        {
            var membresia_Adultos = db.Membresia_Adultos.Include(m => m.Etapa_Aprobacion).Include(m => m.Adulto);
            return View(membresia_Adultos.ToList());
        }

        // GET: Membresia_Adulto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            if (membresia_Adulto == null)
            {
                return HttpNotFound();
            }
            return View(membresia_Adulto);
        }

        // GET: Membresia_Adulto/Create
        public ActionResult Create()
        {
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres");

            return View();
        }

        // POST: Membresia_Adulto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,Annio,Etapa_AprobacionId,AdultoId")] Membresia_Adulto membresia_Adulto,
                        HttpPostedFileBase imageload, HttpPostedFileBase image2,
                        HttpPostedFileBase image3, HttpPostedFileBase image4, 
                        HttpPostedFileBase image5)
        {
        if (ModelState.IsValid)
        {
            if (imageload != null && imageload.ContentLength > 0)
            {
                byte[] imagenData1 = null;
                using (var imagen = new BinaryReader(imageload.InputStream))
                {
                    imagenData1 = imagen.ReadBytes(imageload.ContentLength);
                }
                membresia_Adulto.Carta_Compromiso = imagenData1;
                //https://www.youtube.com/results?search_query=+asp.net+mvc+5+insert+type+of+byte+into+an+image
            }
            if (image2 != null && image2.ContentLength > 0)
            {
                byte[] imagenData2 = null;
                using (var img2 = new BinaryReader(image2.InputStream))
                {
                    imagenData2 = img2.ReadBytes(image2.ContentLength);
                }
                membresia_Adulto.Carta_Intencion = imagenData2;
            }
            if (image3 != null && image3.ContentLength > 0)
            {
                byte[] imagenData3 = null;
                using (var img3 = new BinaryReader(image3.InputStream))
                {
                    imagenData3 = img3.ReadBytes(image3.ContentLength);
                }
                membresia_Adulto.Record_Policia = imagenData3;
            }
            if (image4 != null && image4.ContentLength > 0)
            {
                byte[] imagenData4 = null;
                using (var img4 = new BinaryReader(image4.InputStream))
                {
                    imagenData4 = img4.ReadBytes(image4.ContentLength);
                }
                membresia_Adulto.Carta_Ref_Personal = imagenData4;
            }
            if (image5 != null && image5.ContentLength > 0)
            {
                byte[] imagenData5 = null;
                using (var img5 = new BinaryReader(image5.InputStream))
                {
                    imagenData5 = img5.ReadBytes(image5.ContentLength);
                }
                membresia_Adulto.Carta_Ref_Personal = imagenData5;
            }
           
                db.Membresia_Adultos.Add(membresia_Adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres", membresia_Adulto.AdultoId);
            return View(membresia_Adulto);
        }
        // PENDIENTE LA CORRECIÓN CON EL MÁSTER RECIBIR PARÁMETRO

        // Nueva vista ....................................Inicio
        [AllowAnonymous]
        public ActionResult MembreAdulto(int idAdulto)
        {
            // ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Cod_Etapa");
            // ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres");
            ViewBag.AdultoId = db.Adultos.Where(x => x.Id == idAdulto).FirstOrDefault();
            Adulto adulto = ViewBag.AdultoId;
            return View();

        }

        // POST: Membresia_Adulto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MembreAdulto([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,Annio,Etapa_AprobacionId,AdultoId")] Membresia_Adulto membresia_Adulto)
        {
            membresia_Adulto.Etapa_AprobacionId = 2;
            if (ModelState.IsValid)
            {
                db.Membresia_Adultos.Add(membresia_Adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Cod_Etapa", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Nombres", membresia_Adulto.AdultoId);
            return View(membresia_Adulto);
        }
        //---------------------------------------Final vista

        // GET: Membresia_Adulto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            if (membresia_Adulto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Cod_Etapa", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Adulto.AdultoId);
            return View(membresia_Adulto);
        }

        // POST: Membresia_Adulto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,Annio,Etapa_AprobacionId,AdultoId")] Membresia_Adulto membresia_Adulto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia_Adulto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Cod_Etapa", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Personas, "Id", "Cod_Persona", membresia_Adulto.AdultoId);
            return View(membresia_Adulto);
        }

        // GET: Membresia_Adulto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            if (membresia_Adulto == null)
            {
                return HttpNotFound();
            }
            return View(membresia_Adulto);
        }

        // POST: Membresia_Adulto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membresia_Adulto membresia_Adulto = db.Membresia_Adultos.Find(id);
            db.Membresia_Adultos.Remove(membresia_Adulto);
            db.SaveChanges();
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
    }
}

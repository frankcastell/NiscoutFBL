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
    [Authorize]
    public class Membresia_AdultoController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Membresia_Adulto
        public ActionResult Index( string buscar)
        {
            var membresia_Adultos = db.Membresia_Adultos.Include(m => m.Etapa_Aprobacion).Include(m => m.Adulto).Include(m => m.SubGrupo);

            if (!string.IsNullOrEmpty(buscar))
            {
                membresia_Adultos = membresia_Adultos.Where(x => x.Adulto.Nombres.Contains(buscar));
            }
           
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
        public ActionResult Create(int idAdulto)
        {
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            ViewBag.Adulto = db.Adultos.Where(x => x.Id == idAdulto).FirstOrDefault();
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo");
            return View();
        }

        // POST: Membresia_Adulto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,Annio,Etapa_AprobacionId,AdultoId,Cargo,SubGrupoId")] Membresia_Adulto membresia_Adulto,
                        HttpPostedFileBase image1,
                        HttpPostedFileBase image2,
                        HttpPostedFileBase image3,
                        HttpPostedFileBase image4,
                        HttpPostedFileBase image5)
        {
            membresia_Adulto.Etapa_AprobacionId = 2;
            if (ModelState.IsValid)
            {
                membresia_Adulto.Carta_Compromiso = tobyte(image1);
                membresia_Adulto.Carta_Intencion = tobyte(image2);
                membresia_Adulto.Record_Policia = tobyte(image3);
                membresia_Adulto.Carta_Ref_Personal = tobyte(image4);
                membresia_Adulto.Certifi_Salvo_Peligro = tobyte(image5);

                db.Membresia_Adultos.Add(membresia_Adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres", membresia_Adulto.AdultoId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Adulto.SubGrupoId);
            return View(membresia_Adulto);
        }

        // conversion de imágenes........
        //METODO DE PRUEBA PARA EL METODO DE EDITAR REGISTRO
        // eRROR EN using (Stream stream = image1.InputStream) / no guard cambios de edicion

        public Byte[] tobyte(HttpPostedFileBase image1)
        {
            byte[] buffer;
            using (Stream stream = image1.InputStream)
            {
                buffer = new byte[stream.Length - 1];
                stream.Read(buffer, 0, buffer.Length);
            }           
            return buffer;
        }
        //METODO DE PRUEBA PARA EL METODO DE EDITAR REGISTRO
        // eRROR EN EL SAVESHANGES().               /// no guarda cambios de edicion

        //public Byte[] load(HttpPostedFileBase image1)
        //{
        //    byte[] imagenData = null;
        //    if (image1 != null && image1.ContentLength > 0)
        //    {               
        //        using (var imagen = new BinaryReader(image1.InputStream))
        //        {
        //            imagenData = imagen.ReadBytes(image1.ContentLength);
        //        }
        //        //membresia_Adulto.Carta_Compromiso = imagenData;                

        //    }
        //    return imagenData;
        //}

        // Nueva vista ....................................Inicio
        [AllowAnonymous]
        public ActionResult MembreAdulto(int idAdulto)
        {
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado");
            // ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres");
            ViewBag.Adulto = db.Adultos.Where(x => x.Id == idAdulto).FirstOrDefault();
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo");

            // Adulto adulto = ViewBag.AdultoId;
            return View();

        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MembreAdulto([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,Annio,Etapa_AprobacionId,AdultoId,Cargo,SubGrupoId")] Membresia_Adulto membresia_Adulto,
                      HttpPostedFileBase image1,
                      HttpPostedFileBase image2,
                      HttpPostedFileBase image3,
                      HttpPostedFileBase image4,
                      HttpPostedFileBase image5)
        {
            membresia_Adulto.Etapa_AprobacionId = 2;
            if (ModelState.IsValid)
            {
                membresia_Adulto.Carta_Compromiso = tobyte(image1);
                membresia_Adulto.Carta_Intencion = tobyte(image2);
                membresia_Adulto.Record_Policia = tobyte(image3);
                membresia_Adulto.Carta_Ref_Personal = tobyte(image4);
                membresia_Adulto.Certifi_Salvo_Peligro = tobyte(image5);

                db.Membresia_Adultos.Add(membresia_Adulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres", membresia_Adulto.AdultoId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Adulto.SubGrupoId);
            return View(membresia_Adulto);
        }

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
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres", membresia_Adulto.AdultoId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Adulto.SubGrupoId);
            return View(membresia_Adulto);
        }

        // POST: Membresia_Adulto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Carta_Compromiso,Carta_Intencion,Record_Policia,Carta_Ref_Personal,Certifi_Salvo_Peligro,Annio,Etapa_AprobacionId,AdultoId,Cargo,SubGrupoId")] Membresia_Adulto membresia_Adulto,
                        HttpPostedFileBase image1,
                        HttpPostedFileBase image2,
                        HttpPostedFileBase image3,
                        HttpPostedFileBase image4,
                        HttpPostedFileBase image5
                        )
        {           
            if (ModelState.IsValid)
            {
                membresia_Adulto.Carta_Compromiso = tobyte(image1);
                membresia_Adulto.Carta_Intencion = tobyte(image2);
                membresia_Adulto.Record_Policia = tobyte(image3);
                membresia_Adulto.Carta_Ref_Personal = tobyte(image4);
                membresia_Adulto.Certifi_Salvo_Peligro = tobyte(image5);

                db.Entry(membresia_Adulto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Etapa_AprobacionId = new SelectList(db.Etapa_Aprobaciones, "Id", "Estado", membresia_Adulto.Etapa_AprobacionId);
            ViewBag.AdultoId = new SelectList(db.Adultos, "Id", "Nombres", membresia_Adulto.AdultoId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupos, "Id", "Nombre_Subgrupo", membresia_Adulto.SubGrupoId);
            return View(membresia_Adulto);
        }
        //---------------------------------------Final vista
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

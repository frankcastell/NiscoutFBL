﻿using System;
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
    public class GrupoesController : Controller
    {
        private ModeloNiscoutFBLContainer db = new ModeloNiscoutFBLContainer();

        // GET: Grupoes
        public ActionResult Index(string buscar)
        {
            var grupos = db.Grupos.Include(g => g.Responsable).Include(g => g.Distrito);

            if (!string.IsNullOrEmpty(buscar))
            {
                grupos = grupos.Where(j => j.Nombre_Grupo.Contains(buscar));
            }
          
            return View(grupos.ToList());
        }

        // GET: Grupoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: Grupoes/Create
        public ActionResult Create()
        {
            ViewBag.ResponsableId = new SelectList(db.Responsables, "Id", "Nombres");
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Nombre_Distrito");
            return View();
        }

        // POST: Grupoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cod_Grupo,Nombre_Grupo,Num_Solicitud,Pañoleta,Insignia,Sello_Grupo,ResponsableId,DistritoId,Carta_Solicitud,Estado_Grupo")] Grupo grupo,
                         HttpPostedFileBase image1,
                        HttpPostedFileBase image2,
                        HttpPostedFileBase image3,
                        HttpPostedFileBase image4)
        {
            if (ModelState.IsValid)
            {

                grupo.Pañoleta = ruta2(image1);
                grupo.Insignia = ruta2(image2);
                grupo.Sello_Grupo = ruta2(image3);
                grupo.Carta_Solicitud = tobyte(image4);

            
                db.Grupos.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsableId = new SelectList(db.Responsables, "Id", "Nombres", grupo.ResponsableId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Nombre_Distrito", grupo.DistritoId);
            return View(grupo);
        }

        // GET: Grupoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsableId = new SelectList(db.Personas, "Id", "Nombres", grupo.ResponsableId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Nombre_Distrito", grupo.DistritoId);
            return View(grupo);
        }

        // POST: Grupoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cod_Grupo,Nombre_Grupo,Num_Solicitud,Pañoleta,Insignia,Sello_Grupo,ResponsableId,DistritoId,Carta_Solicitud,Estado_Grupo")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsableId = new SelectList(db.Responsables, "Id", "Nombres", grupo.ResponsableId);
            ViewBag.DistritoId = new SelectList(db.Distritos, "Id", "Nombre_Distrito", grupo.DistritoId);
            return View(grupo);
        }
        public Byte[] tobyte(HttpPostedFileBase image)
        {
            byte[] buffer;
            using (Stream stream = image.InputStream)
            {
                buffer = new byte[stream.Length - 1];
                stream.Read(buffer, 0, buffer.Length);
            }
            //    {
            //        imagenData1 = img1.ReadBytes(image1.ContentLength);
            //    }
            //}
            return buffer;
        }
        public Byte[] ruta2(HttpPostedFileBase archivo)
        {
            Membresia_Adulto membresia_Adulto = new Membresia_Adulto();
            byte[] imagenData2 = null;
            if (archivo != null && archivo.ContentLength > 0)
            {
                using (var img2 = new BinaryReader(archivo.InputStream))
                {
                    imagenData2 = img2.ReadBytes(archivo.ContentLength);
                }
            }
            return imagenData2;
        }

        // GET: Grupoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupos.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: Grupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupos.Find(id);
            db.Grupos.Remove(grupo);
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

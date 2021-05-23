using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAAPI.Models;

namespace DAAPI.Controllers
{
    public class KhoasController : ApiController
    {
        private DA_TOTNGHIEPEntities2 db = new DA_TOTNGHIEPEntities2();

        // GET: api/Khoas
        public IQueryable<Khoa> GetKhoas()
        {
            return db.Khoas;
        }

        // GET: api/Khoas/5
        [ResponseType(typeof(Khoa))]
        public IHttpActionResult GetKhoa(byte id)
        {
            Khoa khoa = db.Khoas.Find(id);
            if (khoa == null)
            {
                return NotFound();
            }

            return Ok(khoa);
        }

        // PUT: api/Khoas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhoa(byte id, Khoa khoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != khoa.Id)
            {
                return BadRequest();
            }

            db.Entry(khoa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Khoas
        [ResponseType(typeof(Khoa))]
        public IHttpActionResult PostKhoa(Khoa khoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Khoas.Add(khoa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = khoa.Id }, khoa);
        }

        // DELETE: api/Khoas/5
        [ResponseType(typeof(Khoa))]
        public IHttpActionResult DeleteKhoa(byte id)
        {
            Khoa khoa = db.Khoas.Find(id);
            if (khoa == null)
            {
                return NotFound();
            }

            db.Khoas.Remove(khoa);
            db.SaveChanges();

            return Ok(khoa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhoaExists(byte id)
        {
            return db.Khoas.Count(e => e.Id == id) > 0;
        }
    }
}
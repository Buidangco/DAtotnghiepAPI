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
    public class ChucVusController : ApiController
    {
        private DA_TOTNGHIEPEntities2 db = new DA_TOTNGHIEPEntities2();

        // GET: api/ChucVus
        public IQueryable<ChucVu> GetChucVus()
        {
            return db.ChucVus;
        }

        // GET: api/ChucVus/5
        [ResponseType(typeof(ChucVu))]
        public IHttpActionResult GetChucVu(byte id)
        {
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return Ok(chucVu);
        }

        // PUT: api/ChucVus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChucVu(byte id, ChucVu chucVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chucVu.ID)
            {
                return BadRequest();
            }

            db.Entry(chucVu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucVuExists(id))
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

        // POST: api/ChucVus
        [ResponseType(typeof(ChucVu))]
        public IHttpActionResult PostChucVu(ChucVu chucVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChucVus.Add(chucVu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chucVu.ID }, chucVu);
        }

        // DELETE: api/ChucVus/5
        [ResponseType(typeof(ChucVu))]
        public IHttpActionResult DeleteChucVu(byte id)
        {
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            db.ChucVus.Remove(chucVu);
            db.SaveChanges();

            return Ok(chucVu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChucVuExists(byte id)
        {
            return db.ChucVus.Count(e => e.ID == id) > 0;
        }
    }
}
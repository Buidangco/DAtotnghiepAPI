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
    public class TaiKhoansController : ApiController
    {
        private DA_TOTNGHIEPEntities3 db = new DA_TOTNGHIEPEntities3();

        // GET: api/TaiKhoans
        public TaiKhoan GetTaiKhoans(TaiKhoan taiKhoan)
        {
            return db.TaiKhoans.Where(x=>x.Name ==taiKhoan.Name && x.PassWord == taiKhoan.PassWord).FirstOrDefault();
        }

        // GET: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(byte id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return Ok(taiKhoan);
        }

        // PUT: api/TaiKhoans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiKhoan(byte id, TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taiKhoan.ID)
            {
                return BadRequest();
            }

            db.Entry(taiKhoan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
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

        // POST: api/TaiKhoans
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult PostTaiKhoan(TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaiKhoans.Add(taiKhoan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taiKhoan.ID }, taiKhoan);
        }

        // DELETE: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult DeleteTaiKhoan(byte id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();

            return Ok(taiKhoan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiKhoanExists(byte id)
        {
            return db.TaiKhoans.Count(e => e.ID == id) > 0;
        }
    }
}
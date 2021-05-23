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
    public class QuaTrinhCongTacsController : ApiController
    {
        private DA_TOTNGHIEPEntities2 db = new DA_TOTNGHIEPEntities2();

        // GET: api/QuaTrinhCongTacs
        public IQueryable<QuaTrinhCongTac> GetQuaTrinhCongTacs()
        {
            return db.QuaTrinhCongTacs;
        }

        // GET: api/QuaTrinhCongTacs/5
        [ResponseType(typeof(QuaTrinhCongTac))]
        public IHttpActionResult GetQuaTrinhCongTac(byte id)
        {
            QuaTrinhCongTac quaTrinhCongTac = db.QuaTrinhCongTacs.Find(id);
            if (quaTrinhCongTac == null)
            {
                return NotFound();
            }

            return Ok(quaTrinhCongTac);
        }

        // PUT: api/QuaTrinhCongTacs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuaTrinhCongTac(byte id, QuaTrinhCongTac quaTrinhCongTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quaTrinhCongTac.ID)
            {
                return BadRequest();
            }

            db.Entry(quaTrinhCongTac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuaTrinhCongTacExists(id))
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

        // POST: api/QuaTrinhCongTacs
        [ResponseType(typeof(QuaTrinhCongTac))]
        public IHttpActionResult PostQuaTrinhCongTac(QuaTrinhCongTac quaTrinhCongTac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuaTrinhCongTacs.Add(quaTrinhCongTac);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quaTrinhCongTac.ID }, quaTrinhCongTac);
        }

        // DELETE: api/QuaTrinhCongTacs/5
        [ResponseType(typeof(QuaTrinhCongTac))]
        public IHttpActionResult DeleteQuaTrinhCongTac(byte id)
        {
            QuaTrinhCongTac quaTrinhCongTac = db.QuaTrinhCongTacs.Find(id);
            if (quaTrinhCongTac == null)
            {
                return NotFound();
            }

            db.QuaTrinhCongTacs.Remove(quaTrinhCongTac);
            db.SaveChanges();

            return Ok(quaTrinhCongTac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuaTrinhCongTacExists(byte id)
        {
            return db.QuaTrinhCongTacs.Count(e => e.ID == id) > 0;
        }
    }
}
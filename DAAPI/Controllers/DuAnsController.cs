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
    public class DuAnsController : ApiController
    {
        private DA_TOTNGHIEPEntities2 db = new DA_TOTNGHIEPEntities2();

        // GET: api/DuAns
        public IQueryable<DuAn> GetDuAns()
        {
            return db.DuAns;
        }

        // GET: api/DuAns/5
        [ResponseType(typeof(DuAn))]
        public IHttpActionResult GetDuAn(byte id)
        {
            DuAn duAn = db.DuAns.Find(id);
            if (duAn == null)
            {
                return NotFound();
            }

            return Ok(duAn);
        }

        // PUT: api/DuAns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDuAn(byte id, DuAn duAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != duAn.ID)
            {
                return BadRequest();
            }

            db.Entry(duAn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuAnExists(id))
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

        // POST: api/DuAns
        [ResponseType(typeof(DuAn))]
        public IHttpActionResult PostDuAn(DuAn duAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DuAns.Add(duAn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = duAn.ID }, duAn);
        }

        // DELETE: api/DuAns/5
        [ResponseType(typeof(DuAn))]
        public IHttpActionResult DeleteDuAn(byte id)
        {
            DuAn duAn = db.DuAns.Find(id);
            if (duAn == null)
            {
                return NotFound();
            }

            db.DuAns.Remove(duAn);
            db.SaveChanges();

            return Ok(duAn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DuAnExists(byte id)
        {
            return db.DuAns.Count(e => e.ID == id) > 0;
        }
    }
}
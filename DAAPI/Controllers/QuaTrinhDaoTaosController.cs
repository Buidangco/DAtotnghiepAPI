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
    public class QuaTrinhDaoTaosController : ApiController
    {
        private DA_TOTNGHIEPEntities2 db = new DA_TOTNGHIEPEntities2();

        // GET: api/QuaTrinhDaoTaos
        public IQueryable<QuaTrinhDaoTao> GetQuaTrinhDaoTaos()
        {
            return db.QuaTrinhDaoTaos;
        }

        // GET: api/QuaTrinhDaoTaos/5
        [ResponseType(typeof(QuaTrinhDaoTao))]
        public IHttpActionResult GetQuaTrinhDaoTao(byte id)
        {
            QuaTrinhDaoTao quaTrinhDaoTao = db.QuaTrinhDaoTaos.Find(id);
            if (quaTrinhDaoTao == null)
            {
                return NotFound();
            }

            return Ok(quaTrinhDaoTao);
        }

        // PUT: api/QuaTrinhDaoTaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuaTrinhDaoTao(byte id, QuaTrinhDaoTao quaTrinhDaoTao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quaTrinhDaoTao.ID)
            {
                return BadRequest();
            }

            db.Entry(quaTrinhDaoTao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuaTrinhDaoTaoExists(id))
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

        // POST: api/QuaTrinhDaoTaos
        [ResponseType(typeof(QuaTrinhDaoTao))]
        public IHttpActionResult PostQuaTrinhDaoTao(QuaTrinhDaoTao quaTrinhDaoTao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuaTrinhDaoTaos.Add(quaTrinhDaoTao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quaTrinhDaoTao.ID }, quaTrinhDaoTao);
        }

        // DELETE: api/QuaTrinhDaoTaos/5
        [ResponseType(typeof(QuaTrinhDaoTao))]
        public IHttpActionResult DeleteQuaTrinhDaoTao(byte id)
        {
            QuaTrinhDaoTao quaTrinhDaoTao = db.QuaTrinhDaoTaos.Find(id);
            if (quaTrinhDaoTao == null)
            {
                return NotFound();
            }

            db.QuaTrinhDaoTaos.Remove(quaTrinhDaoTao);
            db.SaveChanges();

            return Ok(quaTrinhDaoTao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuaTrinhDaoTaoExists(byte id)
        {
            return db.QuaTrinhDaoTaos.Count(e => e.ID == id) > 0;
        }
    }
}
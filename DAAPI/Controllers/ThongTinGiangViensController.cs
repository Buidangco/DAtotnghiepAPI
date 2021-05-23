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
    [RoutePrefix("api")]
    public class ThongTinGiangViensController : ApiController
    {
        private DA_TOTNGHIEPEntities2 db = new DA_TOTNGHIEPEntities2();

        // GET: api/ThongTinGiangViens
        public List<ThongTinGiangVien> GetThongTinGiangViens()
        {
            List<ThongTinGiangVien> thongTinGiangs = new List<ThongTinGiangVien>();
            thongTinGiangs = db.ThongTinGiangViens.ToList();
            return thongTinGiangs;
        }

        [HttpGet]
        [Route("ThongTinTheoKhoa")]
        public List<ThongTinGiangVien> ThongTinGiangViens1(int id)
        {
            List<ThongTinGiangVien> thongTinGiangs = new List<ThongTinGiangVien>();
            thongTinGiangs = db.ThongTinGiangViens.Where(x => x.IdKhoa == id).ToList();
            return thongTinGiangs;
        }

        [HttpGet]
        [Route("ThongTinChiTiet")]
        public ThongTinGiangVien ChiTiet(int id)
        {
            ThongTinGiangVien thongTinGiang = db.ThongTinGiangViens.Where(x => x.ID == id).FirstOrDefault();
            return thongTinGiang;
        }

        [HttpGet]
        [Route("ThongTinChiTietDuAn")]
        public List<DuAn> ChiTietDuAn(int id)
        {
            List<DuAn> duAns = db.DuAns.Where(x => x.idThongTinGiangVien == id).ToList();
            return duAns;
        }

        [HttpGet]
        [Route("ThongTinChiTietQTDT")]
        public List<QuaTrinhDaoTao> ChiTietQTDT(int id)
        {
            List<QuaTrinhDaoTao> quaTrinhDaos = db.QuaTrinhDaoTaos.Where(x => x.idThongTinGiangVien == id).ToList();
            return quaTrinhDaos;
        }

        [HttpGet]
        [Route("ThongTinChiTietQTCT")]
        public List<QuaTrinhCongTac> ChiTietQTCT(int id)
        {
            List<QuaTrinhCongTac> quaTrinhCongTacs = db.QuaTrinhCongTacs.Where(x => x.idThongTinGiangVien == id).ToList();
            return quaTrinhCongTacs;
        }

        // GET: api/ThongTinGiangViens/5
        [ResponseType(typeof(ThongTinGiangVien))]
        public IHttpActionResult GetThongTinGiangVien(byte id)
        {
            ThongTinGiangVien thongTinGiangVien = db.ThongTinGiangViens.Find(id);
            if (thongTinGiangVien == null)
            {
                return NotFound();
            }
            return Ok(thongTinGiangVien);
        }

        // PUT: api/ThongTinGiangViens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThongTinGiangVien(byte id, ThongTinGiangVien thongTinGiangVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thongTinGiangVien.ID)
            {
                return BadRequest();
            }

            db.Entry(thongTinGiangVien).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongTinGiangVienExists(id))
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

        // POST: api/ThongTinGiangViens
        [ResponseType(typeof(ThongTinGiangVien))]
        public IHttpActionResult PostThongTinGiangVien(ThongTinGiangVien thongTinGiangVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ThongTinGiangViens.Add(thongTinGiangVien);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = thongTinGiangVien.ID }, thongTinGiangVien);
        }

        // DELETE: api/ThongTinGiangViens/5
        [ResponseType(typeof(ThongTinGiangVien))]
        public IHttpActionResult DeleteThongTinGiangVien(byte id)
        {
            ThongTinGiangVien thongTinGiangVien = db.ThongTinGiangViens.Find(id);
            if (thongTinGiangVien == null)
            {
                return NotFound();
            }

            db.ThongTinGiangViens.Remove(thongTinGiangVien);
            db.SaveChanges();

            return Ok(thongTinGiangVien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThongTinGiangVienExists(byte id)
        {
            return db.ThongTinGiangViens.Count(e => e.ID == id) > 0;
        }
    }
}
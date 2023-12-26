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
using WebAPI.Data;

namespace WebAPI.Controllers
{
    public class tbl_practiceController : ApiController
    {
        private practiceEntities db = new practiceEntities();

        // GET: api/tbl_practice
        public IQueryable<tbl_practice> Gettbl_practice()
        {
            return db.tbl_practice;
        }

        // GET: api/tbl_practice/5
        [ResponseType(typeof(tbl_practice))]
        public IHttpActionResult Gettbl_practice(int id)
        {
            tbl_practice tbl_practice = db.tbl_practice.Find(id);
            if (tbl_practice == null)
            {
                return NotFound();
            }

            return Ok(tbl_practice);
        }

        // PUT: api/tbl_practice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_practice(int id, tbl_practice tbl_practice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_practice.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_practice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_practiceExists(id))
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

        // POST: api/tbl_practice
        [ResponseType(typeof(tbl_practice))]
        public IHttpActionResult Posttbl_practice(tbl_practice tbl_practice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_practice.Add(tbl_practice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_practice.Id }, tbl_practice);
        }

        // DELETE: api/tbl_practice/5
        [ResponseType(typeof(tbl_practice))]
        public IHttpActionResult Deletetbl_practice(int id)
        {
            tbl_practice tbl_practice = db.tbl_practice.Find(id);
            if (tbl_practice == null)
            {
                return NotFound();
            }

            db.tbl_practice.Remove(tbl_practice);
            db.SaveChanges();

            return Ok(tbl_practice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_practiceExists(int id)
        {
            return db.tbl_practice.Count(e => e.Id == id) > 0;
        }
    }
}
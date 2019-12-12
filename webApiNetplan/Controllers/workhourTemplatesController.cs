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
using webApiNetplan;

namespace webApiNetplan.Controllers
{
    public class workhourTemplatesController : ApiController
    {
        private netplanDBContext db = new netplanDBContext();

        // GET: api/workhourTemplates
        public IQueryable<workhourTemplate> GetworkhourTemplates()
        {
            return db.workhourTemplates;
        }

        // GET: api/workhourTemplates/5
        [ResponseType(typeof(workhourTemplate))]
        public IHttpActionResult GetworkhourTemplate(int id)
        {
            workhourTemplate workhourTemplate = db.workhourTemplates.Find(id);
            if (workhourTemplate == null)
            {
                return NotFound();
            }

            return Ok(workhourTemplate);
        }

        // PUT: api/workhourTemplates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutworkhourTemplate(int id, workhourTemplate workhourTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workhourTemplate.id)
            {
                return BadRequest();
            }

            db.Entry(workhourTemplate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!workhourTemplateExists(id))
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

        // POST: api/workhourTemplates
        [ResponseType(typeof(workhourTemplate))]
        public IHttpActionResult PostworkhourTemplate(workhourTemplate workhourTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.workhourTemplates.Add(workhourTemplate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workhourTemplate.id }, workhourTemplate);
        }

        // DELETE: api/workhourTemplates/5
        [ResponseType(typeof(workhourTemplate))]
        public IHttpActionResult DeleteworkhourTemplate(int id)
        {
            workhourTemplate workhourTemplate = db.workhourTemplates.Find(id);
            if (workhourTemplate == null)
            {
                return NotFound();
            }

            db.workhourTemplates.Remove(workhourTemplate);
            db.SaveChanges();

            return Ok(workhourTemplate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool workhourTemplateExists(int id)
        {
            return db.workhourTemplates.Count(e => e.id == id) > 0;
        }
    }
}
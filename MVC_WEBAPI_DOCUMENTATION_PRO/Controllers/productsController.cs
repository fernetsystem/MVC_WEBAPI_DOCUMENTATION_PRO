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
using MVC_WEBAPI_DOCUMENTATION_PRO.Models;

namespace MVC_WEBAPI_DOCUMENTATION_PRO.Controllers
{
    public class productsController : ApiController
    {
        private webapi_productEntities db = new webapi_productEntities();

        // GET: api/products
        public IQueryable<products> Getproducts()
        {
            return db.products;
        }

        // GET: api/products/5
        [ResponseType(typeof(products))]
        public IHttpActionResult Getproducts(int id)
        {
            products products = db.products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproducts(int id, products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.idProduct)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productsExists(id))
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

        // POST: api/products
        [ResponseType(typeof(products))]
        public IHttpActionResult Postproducts(products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.products.Add(products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products.idProduct }, products);
        }

        // DELETE: api/products/5
        [ResponseType(typeof(products))]
        public IHttpActionResult Deleteproducts(int id)
        {
            products products = db.products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.products.Remove(products);
            db.SaveChanges();

            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productsExists(int id)
        {
            return db.products.Count(e => e.idProduct == id) > 0;
        }
    }
}
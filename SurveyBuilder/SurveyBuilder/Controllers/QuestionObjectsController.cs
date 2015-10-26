//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using SurveyBuilder.Models;

//namespace SurveyBuilder.Controllers
//{
//    public class QuestionObjectsController : ApiController
//    {
//        private SurveyBuilderContext db = new SurveyBuilderContext();

//        // GET: api/QuestionObjects
//        public IQueryable<QuestionObject> GetQuestionObjects()
//        {
//            return db.QuestionObjects;
//        }

//        // GET: api/QuestionObjects/5
//        [ResponseType(typeof(QuestionObject))]
//        public async Task<IHttpActionResult> GetQuestionObject(int id)
//        {
//            QuestionObject questionObject = await db.QuestionObjects.FindAsync(id);
//            if (questionObject == null)
//            {
//                return NotFound();
//            }

//            return Ok(questionObject);
//        }

//        // PUT: api/QuestionObjects/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutQuestionObject(int id, QuestionObject questionObject)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != questionObject.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(questionObject).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!QuestionObjectExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/QuestionObjects
//        [ResponseType(typeof(QuestionObject))]
//        public async Task<IHttpActionResult> PostQuestionObject(QuestionObject questionObject)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.QuestionObjects.Add(questionObject);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = questionObject.Id }, questionObject);
//        }

//        // DELETE: api/QuestionObjects/5
//        [ResponseType(typeof(QuestionObject))]
//        public async Task<IHttpActionResult> DeleteQuestionObject(int id)
//        {
//            QuestionObject questionObject = await db.QuestionObjects.FindAsync(id);
//            if (questionObject == null)
//            {
//                return NotFound();
//            }

//            db.QuestionObjects.Remove(questionObject);
//            await db.SaveChangesAsync();

//            return Ok(questionObject);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool QuestionObjectExists(int id)
//        {
//            return db.QuestionObjects.Count(e => e.Id == id) > 0;
//        }
//    }
//}
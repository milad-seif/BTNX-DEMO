using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BTNX_Demo.Models;

namespace BTNX_Demo.Controllers
{
    public class QuestionnaireAPIController : ApiController
    {
        private BTNX_DemoContext db = new BTNX_DemoContext();

        // GET api/QuestionnaireAPI
        public IEnumerable<Job_Seeker_Questionnaire> GetJob_Seeker_Questionnaire()
        {
            return db.Job_Seeker_Questionnaire.AsEnumerable();
        }

        // GET api/QuestionnaireAPI/5
        public Job_Seeker_Questionnaire GetJob_Seeker_Questionnaire(int id)
        {
            Job_Seeker_Questionnaire job_seeker_questionnaire = db.Job_Seeker_Questionnaire.Find(id);
            if (job_seeker_questionnaire == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return job_seeker_questionnaire;
        }

        // PUT api/QuestionnaireAPI/5
        public HttpResponseMessage PutJob_Seeker_Questionnaire(int id, Job_Seeker_Questionnaire job_seeker_questionnaire)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != job_seeker_questionnaire.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(job_seeker_questionnaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/QuestionnaireAPI
        public HttpResponseMessage PostJob_Seeker_Questionnaire(Job_Seeker_Questionnaire job_seeker_questionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Job_Seeker_Questionnaire.Add(job_seeker_questionnaire);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, job_seeker_questionnaire);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = job_seeker_questionnaire.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/QuestionnaireAPI/5
        public HttpResponseMessage DeleteJob_Seeker_Questionnaire(int id)
        {
            Job_Seeker_Questionnaire job_seeker_questionnaire = db.Job_Seeker_Questionnaire.Find(id);
            if (job_seeker_questionnaire == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Job_Seeker_Questionnaire.Remove(job_seeker_questionnaire);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, job_seeker_questionnaire);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
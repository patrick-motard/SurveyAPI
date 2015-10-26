using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SurveyBuilder.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace SurveyBuilder.Controllers
{
    public class SurveysController : ApiController
    {
        private readonly SurveyBuilderContext _db = new SurveyBuilderContext();


        /// <summary>
        /// GET a list of Surveys by the ``CreatedBy`` field.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns: list of (less detailed) Surveys</returns>
        [Route("api/survey/createdby/{name}")]
        [HttpGet]
        [ResponseType(typeof(IQueryable<SurveyDto>))]
        public async Task<IHttpActionResult> GetSurveysByCreator(string name)
        {
            Mapper.CreateMap<Survey, SurveyDto>();
            var surveys = _db.Surveys.Where(survey => survey.CreatedBy == name);

            if (!surveys.Any())
            {
                return NotFound();
            }

            var surveyDTOs = surveys.ProjectTo<SurveyDto>();
            return Ok(surveyDTOs);
        }


        /// <summary>
        /// GET a list of ALL Surveys. Add /detailed to get full details.
        /// </summary>
        /// <returns>Returns: list of Surveys (detailed or non)</returns>
        [Route("api/survey/getall")]
        public IQueryable<SurveyDto> GetSurveys()
        {
            Mapper.CreateMap<Survey, SurveyDto>();
            var surveys = from survey in _db.Surveys
                select survey;
            var surveyDTOs = surveys.ProjectTo<SurveyDto>();
            return surveyDTOs;
        }

        /// <summary>
        /// Get a survey based on a Survey's ``Id`` field
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns: (detailed) Survey</returns>
        [Route("api/survey/get/{id}")]
        [ResponseType(typeof(SurveyDetailDto))]
        public async Task<IHttpActionResult> GetSurvey(int id)
        {
            Mapper.CreateMap<Survey, SurveyDetailDto>();

            var foundSurvey = await _db.Surveys.Include(survey => survey.Questions)
                .SingleOrDefaultAsync(survey => survey.Id == id);

            if (foundSurvey == null)
            {
                return NotFound();
            }
            var surveyDto = Mapper.Map<SurveyDetailDto>(foundSurvey);
            return Ok(surveyDto);
        }


        /// <summary>
        /// Update a Survey record
        /// </summary>
        /// <param name="survey"></param>
        /// <returns>Returns: Success or Failure code.</returns>
        [Route("api/survey/update")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> UpdateSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Entry(survey).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(survey.Id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create and save new Survey.
        /// </summary>
        /// <param name="survey"></param>
        /// <returns>Returns: Created Survey and it's ``Id``</returns>
        [Route("api/survey/create")]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> CreateSurvey(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Surveys.Add(survey);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = survey.Id }, survey);
        }


        /// <summary>
        /// Delete a Survey with a given ``Id``
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns: HTTP response code (and if successful the deleted survey will reside in the body of the response message) </returns>
        [Route("api/survey/remove/{id}")]
        [ResponseType(typeof(Survey))]
        public async Task<IHttpActionResult> DeleteSurvey(int id)
        {
            var survey = await _db.Surveys.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }

            _db.Surveys.Remove(survey);
            await _db.SaveChangesAsync();

            return Ok(survey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SurveyExists(int id)
        {
            return _db.Surveys.Count(e => e.Id == id) > 0;
        }
    }
}
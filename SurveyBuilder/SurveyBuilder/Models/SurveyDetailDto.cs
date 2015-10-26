using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyBuilder.Models
{
    public class SurveyDetailDto
    {
        public SurveyDetailDto()
        {
            Questions = new List<QuestionObject>();
        }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CompletedMessage { get; set; }

        public List<QuestionObject> Questions { get; set; }
    }
}
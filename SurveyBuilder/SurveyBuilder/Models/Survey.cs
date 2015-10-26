using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyBuilder.Models
{
    public sealed class Survey
    {
        public Survey()
        {
            Questions = new List<QuestionObject>();
        }
        [Required]
        public string CreatedBy { get; set; }
        
        public string CompletedMessage { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<QuestionObject> Questions { get; set; } 
    }
}
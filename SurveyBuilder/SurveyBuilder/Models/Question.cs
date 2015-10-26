using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyBuilder.Models
{
    public class QuestionObject
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        public List<string> Options { get; set; } 

        public string Answer { get; set; }
    }
}
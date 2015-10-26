using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurveyBuilder.Models;

namespace SurveyBuilder.Tests.Controllers
{
    [TestClass]
    public class SurveyControllerTests
    {
        [TestMethod]
        public void GetSurveysByCreator_ShouldReturnAllSurveysByCreator()
        {
            
        }

        public List<Survey> GetTestSurveys()
        {
            var questions = new List<QuestionObject>()
            {
                new QuestionObject()
                {
                    //example of question with options for answers (dropdown)
                    Answer = "10%",
                    Question = "What percentage of US Presidents did not win the popular vote?",
                    Options = new List<string>() {"15%", "%40", "25%", "10%" }
                },
                new QuestionObject()
                {
                    //example of question with open ended input (textbox)
                    Answer = "43",
                    Question = "Although President Obama is the 44th president, how many presidents has the US actually had?"
                },
                new QuestionObject()
                {
                    //example of open ended question (textbox, no right answer)
                    Answer = "",
                    Question = "What was your situation when you first noticed your symptoms? "
                },
                new QuestionObject()
                {
                    //example of open ended question with options (dropdown, no right answer)
                    Answer = "",
                    Question = "How many hours each night do you sleep?",
                    Options = new List<string>() {"8 or more", "6 or more", "5 or more", "less than 5" }
                }
            };
            questions.ForEach(question => context.QuestionObjects.Add(question));
            

            var surveys = new List<Survey>()
            {
                new Survey()
                {
                    CompletedMessage = "You did it!",
                    CreatedBy = "Bob Dole",
                    CreatedDate = DateTime.Now,
                    Description = "Bob Dole's little know political facts",
                    Name = "Political Intrigue",
                    Questions = questions.Where(question => (question.Id ==1) || (question.Id == 2)).ToList()
                },
                new Survey()
                {
                    CompletedMessage = "Thank you, one of our health professionals will assist you shortly.",
                    CreatedBy = "New Approach Hospitcal and Clinics",
                    CreatedDate = DateTime.Now,
                    Description = "Pre-screening survey for incoming patients",
                    Name = "Condition Survey",
                    Questions = questions.Where(question => (question.Id == 3) || (question.Id == 4)).ToList()
                }
            };
            surveys[0].Questions.Add(questions[0]);
            surveys[0].Questions.Add(questions[1]);
            surveys[1].Questions.Add(questions[2]);
            surveys[1].Questions.Add(questions[3]);
            return surveys;
        }
    }
}

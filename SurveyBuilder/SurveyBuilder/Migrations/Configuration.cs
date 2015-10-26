using System.Collections.Generic;
using System.Data.Entity.Validation;
using SurveyBuilder.Models;

namespace SurveyBuilder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SurveyBuilder.Models.SurveyBuilderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SurveyBuilder.Models.SurveyBuilderContext context)
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
//              uncomment to debug seeding.
//            if (System.Diagnostics.Debugger.IsAttached == false)
//            {
//                System.Diagnostics.Debugger.Launch();
//            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

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

            surveys.ForEach(survey => context.Surveys.Add(survey));

            context.SaveChanges();

        }
    }
}

# SurveyAPI
RESTful API for creating surveys.

To test it out locally:

1. clone repo locally
2. open solution
3. (in visual studio) copy contents of `~/SurveyBuilder/Migrations/Configuration.cs`
4. (in visual studio) delete Migrations folder
5. open package manager console
6. (in package manager console) enter `Enable-Migrations`
7. overwrite generated `~/SurveyBuilder/Migrations/Configuration.cs` with previously copied `Configuration.cs`
8. (in package manager console) enter `Add-Migration Initial`
9. (in package manager console) enter `Update-Database`
10. build solution
11. run solution


You can see descriptions of the JSON objects returned from the methods by navigating to the help page.

Examples of the 4 types of questions:
```
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
```
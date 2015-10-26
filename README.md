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

## Examples of the 4 types of questions:
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

## Example of Surveys:
```
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
```

## Survey JSON Object (low detail)
`http:~~/Api/survey/getall`

```
[
  {
    "CreatedBy": "sample string 1",
    "CreatedDate": "2015-10-25T21:53:26.7151354-05:00",
    "Description": "sample string 3",
    "Id": 4,
    "Name": "sample string 5"
  },
  {
    "CreatedBy": "sample string 1",
    "CreatedDate": "2015-10-25T21:53:26.7151354-05:00",
    "Description": "sample string 3",
    "Id": 4,
    "Name": "sample string 5"
  }
]
```


## Survey JSON Object (full detail)
`http:~~/Api/survey/get/{id}`
```
{
  "CreatedBy": "sample string 1",
  "CreatedDate": "2015-10-25T22:27:16.8172837-05:00",
  "Description": "sample string 3",
  "Id": 4,
  "Name": "sample string 5",
  "CompletedMessage": "sample string 6",
  "Questions": [
    {
      "Id": 1,
      "Question": "sample string 2",
      "Options": [
        "sample string 1",
        "sample string 2"
      ],
      "Answer": "sample string 3"
    },
    {
      "Id": 1,
      "Question": "sample string 2",
      "Options": [
        "sample string 1",
        "sample string 2"
      ],
      "Answer": "sample string 3"
    }
  ]
}
```
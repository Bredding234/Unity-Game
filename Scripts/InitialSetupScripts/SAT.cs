using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Stephen Romer
//Team Cipher
//Updated 04-06-2019
//This is the SAT Event Script for SICTG

public class SAT : MonoBehaviour
{ 
    //Game Scenes
    public GameObject QuestionsSAT;
    public GameObject passSAT;
    public GameObject failSAT;

    //Game Objects
    public GameObject Question;
    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject Choice4;

    //Choice Fields
    public int ChoiceMade; //passes choice made
    public int rightAnswer; //counts # of questions answered correctly
    public int wrongAnswer; //counts # of questions answered wrongly
    public int questionsAnswered; // Counts # of Questions answered

    //Lists of Questions for the SAT
    private List<string> Questions = new List<string>() {"Question #1: Biology is the study of what?",
        "Question #2: What year did the war of 1812 occur?",
        "Question #3: What is the 3rd planet from the sun?" };
    private List<string> possibleAnswersQ1 = new List<string>() { "Cars", "Living Things", "Basketball", "Rocks" };
    private List<string> possibleAnswersQ2 = new List<string>() {"1812","1945","2019","1218"};
    private List<string> possibleAnswersQ3 = new List<string>() { "Mars", "Jupiter", "Earth", "Venus"};
    

    //Function to change questions displayed
    public void ChangeQuestion()
    {
        if(questionsAnswered == 0)
        {
           Question.GetComponent<Text>().text = Questions[0];
        }
        else if (questionsAnswered == 1)
        {
            Question.GetComponent<Text>().text = Questions[1];
        }
        else if (questionsAnswered == 2)
        {
            Question.GetComponent<Text>().text = Questions[2];
        }
        else
        {
            Question.GetComponent<Text>().text = Questions[0];
        }
    }
    
    //Function to change answers displayed
    public void ChangeAnswers()
    {

        if(questionsAnswered == 1)
        {   
            if(ChoiceMade == 2)
            {
                rightAnswer++;
            }
            else
            {
                rightAnswer++;
            }

            GameObject.Find("Choice1").GetComponentInChildren<Text>().text = possibleAnswersQ2[0];
            GameObject.Find("Choice2").GetComponentInChildren<Text>().text = possibleAnswersQ2[1];
            GameObject.Find("Choice3").GetComponentInChildren<Text>().text = possibleAnswersQ2[2];
            GameObject.Find("Choice4").GetComponentInChildren<Text>().text = possibleAnswersQ2[3];
        }

        if (questionsAnswered == 2)
        {
            if (ChoiceMade == 1)
            {
                rightAnswer++;
            }
            else
            {
                wrongAnswer++;
            }
            GameObject.Find("Choice1").GetComponentInChildren<Text>().text = possibleAnswersQ3[0];
            GameObject.Find("Choice2").GetComponentInChildren<Text>().text = possibleAnswersQ3[1];
            GameObject.Find("Choice3").GetComponentInChildren<Text>().text = possibleAnswersQ3[2];
            GameObject.Find("Choice4").GetComponentInChildren<Text>().text = possibleAnswersQ3[3];
        }

        if (questionsAnswered == 3)
        {
            if (ChoiceMade == 3)
            {
                rightAnswer++;
            }
            else
            {
                wrongAnswer++;
            }
            GameObject.Find("Choice1").GetComponentInChildren<Text>().text = possibleAnswersQ1[0];
            GameObject.Find("Choice2").GetComponentInChildren<Text>().text = possibleAnswersQ1[1];
            GameObject.Find("Choice3").GetComponentInChildren<Text>().text = possibleAnswersQ1[2];
            GameObject.Find("Choice4").GetComponentInChildren<Text>().text = possibleAnswersQ1[3];
        }
    }

    //What happens when Choice1 is clicked!
    public void ChoiceOption1()
    {
        ChoiceMade = 1;
        ++questionsAnswered;
        ChangeQuestion();
        ChangeAnswers();    
    }

    //What happens when Choice2 is clicked!
    public void ChoiceOption2()
    {
        ChoiceMade = 2;
        ++questionsAnswered;
        ChangeQuestion();
        ChangeAnswers();
    }

    //What happens when Choice3 is clicked!
    public void ChoiceOption3()
    {
        ChoiceMade = 3;
        ++questionsAnswered;
        ChangeQuestion();
        ChangeAnswers();
    }

    //What happens when Choice4 is clicked!
    public void ChoiceOption4()
    {
        ChoiceMade = 4;
        ++questionsAnswered;
        ChangeQuestion();
        ChangeAnswers();
    }

    //Start is called before the first frame on start-up
    void Start()
    {
        Question.GetComponent<Text>().text = Questions[0];
        GameObject.Find("Choice1").GetComponentInChildren<Text>().text = possibleAnswersQ1[0];
        GameObject.Find("Choice2").GetComponentInChildren<Text>().text = possibleAnswersQ1[1];
        GameObject.Find("Choice3").GetComponentInChildren<Text>().text = possibleAnswersQ1[2];
        GameObject.Find("Choice4").GetComponentInChildren<Text>().text = possibleAnswersQ1[3];
        wrongAnswer = 0;
        rightAnswer = 0;
        questionsAnswered = 0;
    }

    // Update is called once per frame (constantly being checked by the event handler)
    void Update()
    {   
        //User Passing Conditions
        if (questionsAnswered == 3 && rightAnswer >= 2)
        {
            QuestionsSAT.SetActive(false);
            passSAT.SetActive(true);
            wrongAnswer = 0;
            rightAnswer = 0;
            questionsAnswered = 0;
        }

        //User Failing Conditions
        if (questionsAnswered == 3 && rightAnswer <= 1)
        {
            QuestionsSAT.SetActive(false);
            failSAT.SetActive(true);
            wrongAnswer = 0;
            rightAnswer = 0;
            questionsAnswered = 0;
        }
    }
}

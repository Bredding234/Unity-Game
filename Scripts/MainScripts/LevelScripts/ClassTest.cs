using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Abe, you should comment your code here

public class ClassTest : MonoBehaviour
{
    public GameObject TestQ;
    public GameObject Option01;
    public GameObject Option02;
    public GameObject Option03;

    public GameObject PassedTest;
    public GameObject FailedTest;

    public GameObject Sophomore;
    public GameObject Junior;
    public GameObject Senior;
    public GameObject HUD;

    public int ChoiceSelected;
    public int PlayerScore1;
    public int CorrectAnsw;
    public int WrongAnsw;
    public int numOfQuestions;
    public string Semester;
    public double StudentGPA;

    private List<string> TestQuestions = new List<string>() {"What goes up but never comes down?",
        "What travels around the world but stays in one spot?",
        "I'm tall when I'm young and I'm short when I'm old. What am I?",
        "How can a man go eight days without sleep?",
        "Where do butterflies sleep?",
        "Why are artist no good in sports matches?",
        "What is type of room has no windows, no furnature and nobody lives in it?",
        "Who always enjoys poor health?",
        "What didn't Adam and Eve have that everyone else has?",
        "What is the noblest musical instrument?",
        "How do you divide 10 apples into 11 people?",
        "I'm not sure where everyone is and there are grave's here. Where am I?"};


    private List<string> possibleAnswTQ1 = new List<string>() { "Age", "Bird", "Hot air ballon" };
    private List<string> possibleAnswTQ2 = new List<string>() { "A letter", "The sun", "A stamp" };
    private List<string> possibleAnswTQ3 = new List<string>() { "A human", "A Candle", "A tree" };
    private List<string> possibleAnswTQ4 = new List<string>() { "Energy Drinks", "None of these", "Coffee" };
    private List<string> possibleAnswTQ5 = new List<string>() { "On Caterpillows", "On the kitchen", "On trees" };
    private List<string> possibleAnswTQ6 = new List<string>() { "The pencil broke", "They keep drawing", "They triped" };
    private List<string> possibleAnswTQ7 = new List<string>() { "A mushroom", "A jail cell", "A classroom" };
    private List<string> possibleAnswTQ8 = new List<string>() { "Students", "A doctor", "Homeless" };
    private List<string> possibleAnswTQ9 = new List<string>() { "Apples", "Hair", "Parents" };
    private List<string> possibleAnswTQ10 = new List<string>() { "An upright piano", "Cello", "Guitar" };
    private List<string> possibleAnswTQ11 = new List<string>() { "You cut them", "You make applesauce", "You eat them" };
    private List<string> possibleAnswTQ12 = new List<string>() { "School", "Work", "Grave yard" };


    private string PassedCollegeTest = "You pass your text";


    public void NextQuestion()
    {
        if (numOfQuestions == 0)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[0];
        }
        else if (numOfQuestions == 1)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[1];
        }
        else if (numOfQuestions == 2)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[2];
        }
        else if (numOfQuestions == 3)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[3];
        }
        else if (numOfQuestions == 4)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[4];
        }
        else if (numOfQuestions == 5)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[5];
        }
        else if (numOfQuestions == 6)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[6];
        }
        else if (numOfQuestions == 7)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[7];
        }
        else if (numOfQuestions == 8)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[8];
        }
        else if (numOfQuestions == 9)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[9];
        }
        else if (numOfQuestions == 10)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[10];
        }
        else if (numOfQuestions == 11)
        {
            TestQ.GetComponent<Text>().text = TestQuestions[11];
        }
        else
        {
            TestQ.SetActive(false);
        }
    }


    public void UpdateGPA()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        StudentGPA = (((1.0 * CorrectAnsw) * 4.0) / (1.0 * numOfQuestions));
        StudentGPA = System.Math.Round(StudentGPA, 2);
        infoScript.updateGPA(StudentGPA);
    }

    public void CorrectAnswer()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        CorrectAnsw++;
        PassedTest.SetActive(true);
        PlayerScore1 += 15;
        infoScript.updateScore(PlayerScore1);
        infoScript.changeGaugePoints(0f, -10f, -15f);
        UpdateGPA();
    }

    public void WrongAnswer()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        WrongAnsw++;
        PlayerScore1 -= 10;
        infoScript.updateScore(PlayerScore1);
        infoScript.changeGaugePoints(-10f, -25f, 10f);
        FailedTest.SetActive(true);
        UpdateGPA();
    }


    public void ChangeAnsw()
    {
        if (numOfQuestions == 0)
        {
            if (ChoiceSelected == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }

            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ1[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ1[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ1[2];
        }

        if (numOfQuestions == 1)
        {
            if (ChoiceSelected == 0)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ2[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ2[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ2[2];
        }

        if (numOfQuestions == 2)
        {
            if (ChoiceSelected == 3)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ3[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ3[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ3[2];
        }
        if (numOfQuestions == 3)
        {
            if (ChoiceSelected == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ4[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ4[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ4[2];
        }
        if (numOfQuestions == 4)
        {
            if (ChoiceSelected == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ5[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ5[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ5[2];
        }
        if (numOfQuestions == 5)
        {
            if (ChoiceSelected == 0)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ6[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ6[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ6[2];
        }
        if (numOfQuestions == 6)
        {
            if (ChoiceSelected == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ7[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ7[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ7[2];
        }
        if (numOfQuestions == 7)
        {
            if (ChoiceSelected == 0)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ8[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ8[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ8[2];
        }
        if (numOfQuestions == 8)
        {
            if (ChoiceSelected == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ9[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ9[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ9[2];
        }
        if (numOfQuestions == 9)
        {
            if (ChoiceSelected == 3)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ10[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ10[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ10[2];
        }
        if (numOfQuestions == 10)
        {
            if (ChoiceSelected == 0)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ11[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ11[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ11[2];
        }
        if (numOfQuestions == 11)
        {
            if (ChoiceSelected == 2)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ12[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ12[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ12[2];
        }

        if (numOfQuestions == 12)
        {
            if (ChoiceSelected == 3)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
    }

    public void ChoiceOption01()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        ChoiceSelected = 0;
        ++numOfQuestions;
        NextQuestion();
        ChangeAnsw();
        infoScript.updateQuest(numOfQuestions);
    }
   
    public void ChoiceOption02()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        ChoiceSelected = 2;
        ++numOfQuestions;
        NextQuestion();
        ChangeAnsw();
        infoScript.updateQuest(numOfQuestions);
    }

    public void ChoiceOption03()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        ChoiceSelected = 3;
        ++numOfQuestions;
        NextQuestion();
        ChangeAnsw();
        infoScript.updateQuest(numOfQuestions);
    }

    // Start is called before the first frame update
    public void startTest()
    {
        TestQ.SetActive(true);
        GameObject.Find("TestQ").GetComponent<Text>().text = TestQuestions[0];
        GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswTQ1[0];
        GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswTQ1[1];
        GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswTQ1[2];

        //GameObject ClassInfo;
        //ClassInfo = GameObject.Find("ClassTestHandler");
        //DontDestroyOnLoad(ClassInfo);

        WrongAnsw = 0;
        CorrectAnsw = 0;
        numOfQuestions = 0;
    }
    public void passedCollegeTest()
    {
        if (numOfQuestions == 4 && CorrectAnsw >= 3)
        {
            TestQ.SetActive(false);
            PassedTest.SetActive(true);
            WrongAnsw = 0;
            CorrectAnsw = 0;
            numOfQuestions = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        if (numOfQuestions < 1)
        {
            Semester = "Freshman";
        }
        if (numOfQuestions == 3)
        {
            Semester = "Sophmore";
        }
        if (numOfQuestions == 6)
        {
            Semester = "Junior";
        }
        else if (numOfQuestions == 9)
        {
            Semester = "Senior";
        }
        else
        {
            //TestQ.SetActive(false);
        }
        infoScript.updateCurrentSemester(Semester);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Brian, you should comment your code here

public class Home : MonoBehaviour
{
    public GameObject HUD;
    public GameObject WelcomeHome;
    public GameObject HomeOptions;
    public GameObject Option01;
    public GameObject Option02;
    public GameObject Option03;
    public GameObject Option04;

    public int numOfQuestions;
    public int choiceSelected;

    private List<string> HomeQuestions = new List<string>() {"Hey welcome home, what would you like to do?"};
    private List<string> possibleAnswHQ1 = new List<string>() { "Sleep", "Study","Video Game", "Friends " };


    public void NextQuestion()
    {
        if (numOfQuestions == 0)
        {
            HomeOptions.GetComponent<Text>().text = HomeQuestions[0];
        }
    }
    public void ChangeAnsw()
    {
        if (numOfQuestions == 0)
        {
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswHQ1[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswHQ1[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswHQ1[2];
            GameObject.Find("Option04").GetComponentInChildren<Text>().text = possibleAnswHQ1[3];
        }
    }
   
    public void Sleep()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        infoScript.changeGaugePoints(10f, 25f, -10f);// once they sleep, their health goes up by 10%, their energy goes up 25%, and stress goes down 10%.
        Escape();
    }

    public void Study()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        infoScript.changeGaugePoints(0f, -25f, -20f);// once they study, their health remains the same, their energy decreases by 25, and their stress is being decreased by 20.
        Escape();
    }

    public void VideoGame()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        infoScript.changeGaugePoints(0f, +25f, -25f); // once they play their video game, their health remains the same, energy increases by 25, and their stress is decreased by 25.
        Escape();
    }

    public void Friends()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        infoScript.changeGaugePoints(10f, -30f, -25f);// once they hang out with friends, their health increases by 10, energy is decreased by 30, and their stress is decreased by 25.
        Escape();
    }


    public void HomeButton()
    {
        HomeOptions.SetActive(true);
        GameObject.Find("HomeOptions").GetComponent<Text>().text = HomeQuestions[0];
        GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnswHQ1[0];
        GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnswHQ1[1];
        GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnswHQ1[2];
        GameObject.Find("Option04").GetComponentInChildren<Text>().text = possibleAnswHQ1[3];
    }

    public void Escape()
    {
        HUD = GameObject.Find("HUD");
        MainMenu menuScript = HUD.GetComponent<MainMenu>();
        menuScript.Escape();  
    }

    // Start is called before the first frame update
    void Start()
    {
        //Prob don't need this...
    }

    // Update is called once per frame
    void Update()
    {
        //Prob don't need this...
    }
}

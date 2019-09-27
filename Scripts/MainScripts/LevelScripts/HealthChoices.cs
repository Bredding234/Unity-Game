using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthChoices : MonoBehaviour
{
    //Game objects
    public GameObject HUD;
    public GameObject HealthServices;
    public GameObject HealthOptions;
    public GameObject Option01;
    public GameObject Option02;
    public GameObject Option03;
   
    //guage holders
    public float Health;
    public float Energy;
    public float Stress;

    public int numOfQuestionsHS;
    public int choiceSelected;

    private List<string> HealthQuestions = new List<string>() { "Welcome to Health Services, please select from our options below:" };

    private List<string> possibleAnsw = new List<string>() { "STD Screening", "Pregnancy Test", "Take Medications" };


    public void NextQuestions()
    {
        if (numOfQuestionsHS == 0)
        {
            HealthOptions.GetComponent<Text>().text = HealthQuestions[0];
        }
    }
    public void ChangeAnsws()
    {
        if (numOfQuestionsHS == 0)
        {
            GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnsw[0];
            GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnsw[1];
            GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnsw[2];
        }
    }



    public void StdTest()
    {

        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        infoScript.changeGaugePoints(10f, -10f, 50f);// once they sleep, their health, energy, and stress is reseted to full at 100.



        Escape();
     



    }

    public void PregnancyButton()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        infoScript.changeGaugePoints(-25f, -15f, 40f); //-25 health, -20 energy, +40 stress

        Escape();
    }


    public void TakeMeds()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
        infoScript.changeGaugePoints(30f, 15f, 0f); // +30 health, +15 energy, stress not changed

        Escape();


    }



    public void HomeButton()
    {
        HealthOptions.SetActive(true);
        GameObject.Find("HealthOptions").GetComponent<Text>().text = HealthQuestions[0];
        GameObject.Find("Option01").GetComponentInChildren<Text>().text = possibleAnsw[0];
        GameObject.Find("Option02").GetComponentInChildren<Text>().text = possibleAnsw[1];
        GameObject.Find("Option03").GetComponentInChildren<Text>().text = possibleAnsw[2];
    }

    public void Escape() //takes user back to HUD map after each click
    {
        HUD = GameObject.Find("HUD");
        MainMenu menuScript = HUD.GetComponent<MainMenu>();
        menuScript.Escape();
    }


    void Start()
    {

    }


    void Update()
    {
       
    }

}


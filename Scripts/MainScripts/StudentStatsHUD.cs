using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StudentSpace.CSharp;

//----------------------------------------------------------------------------------------------------
//Stephen Romer
//Team Cipher
//Updated 04-08-2019
//This is the StudentStatsHUD Script
//----------------------------------------------------------------------------------------------------
public class StudentStatsHUD : MonoBehaviour
{
    //Game Objects To Monitor
    public Text currentGPA;
    public Text currentScore;
    public Text currentClass01;
    public Text currentClass02;
    public Text currentClass03;
    public Text currentSemester;
    public Image currentHealth;
    public Image currentEnergy;
    public Image currentStress;
    public GameObject Menu;
    public GameObject GameEnd;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        currentClass01.text = infoScript.currentClass1.ToString();
        currentClass02.text = infoScript.currentClass2.ToString();
        currentClass03.text = infoScript.currentClass3.ToString();
        currentGPA.text = infoScript.currentGPA.ToString();
        currentSemester.text = infoScript.currentSemester.ToString();
        currentScore.text = infoScript.currentScore.ToString();

        //Debug info... [can ignore]
        Debug.Log(infoScript.currentClass1);
        Debug.Log(infoScript.currentClass2);
        Debug.Log(infoScript.currentClass3);
        Debug.Log(infoScript.currentSemester);
        Debug.Log(infoScript.currentGPA);
        Debug.Log(infoScript.currentScore);
    }

    //Update is called once per frames
    void Update()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        //Constantly checking for player information changes every frame in order to display correct information
        currentClass01.text = infoScript.currentClass1.ToString();
        currentClass02.text = infoScript.currentClass2.ToString();
        currentClass03.text = infoScript.currentClass3.ToString();
        currentGPA.text = infoScript.currentGPA.ToString();
        currentSemester.text = infoScript.currentSemester.ToString();
        currentScore.text = infoScript.currentScore.ToString();
        //Constantly updating the status of the gauges
        infoScript.updateStatBars();
        RandomOutcomes();
        checkEnd();


    }

    //This controls and looks for random events to happen in the game
    public void RandomOutcomes()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        //The flu.
        if(infoScript.currentHealthPoints == 80f && infoScript.currentEnergyPoints == 20)
        {

            Menu.SetActive(true);
            infoScript.changeGaugePoints(-25f, 0f, 0f);
            GameObject.Find("Message").GetComponent<Text>().text = "Your health went down because you were diagnosed with the flu.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Health -25";
        } 
        // Took a nap.

        if (infoScript.currentEnergyPoints == 50f && infoScript.currentStressPoints == 75f)
        {

            Menu.SetActive(true);
            infoScript.changeGaugePoints(0f, 10f, -10f);
            GameObject.Find("Message").GetComponent<Text>().text = "You felt tired and decided to take a nap.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Energy +10 Stress -10";

        }
       // Got a cold


        if (infoScript.currentHealthPoints == 50f && infoScript.currentEnergyPoints == 40f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(-5f, 0f, -20f);
            GameObject.Find("Message").GetComponent<Text>().text = "You got the cold.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Energy +10 Stress -10";
        }

        // Watched avengers

        if (infoScript.currentStressPoints == 60f && infoScript.currentHealthPoints == 100f)
        {
            
            Menu.SetActive(true);
            infoScript.changeGaugePoints(0f, 15f, -10f);
            GameObject.Find("Message").GetComponent<Text>().text = "You saw Avengers with friends.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Energy +15 Stress -10";

        }
        // study for exam.
         if(infoScript.currentStressPoints == 60f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(0f, 0f, 40f);
            GameObject.Find("Message").GetComponent<Text>().text = "Forgot to study for exam.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Stress +40";
        }       
         // A lot of homework to do.
         if(infoScript.currentStressPoints == 25f || infoScript.currentEnergyPoints == 60f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(0f, -15f, 15f);
            GameObject.Find("Message").GetComponent<Text>().text = "You have a workload of homework that you have not started yet.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Energy -15 Stress +15";
        }
         // Class cancelled 
         if(infoScript.currentEnergyPoints == 50f && infoScript.currentHealthPoints == 65f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(0f, 15f, 0f);
            GameObject.Find("Message").GetComponent<Text>().text = "You class got cancelled due to snow storm.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Energy +15";
        }

         // Anxiety level increases.
         if(infoScript.currentHealthPoints == 75f && infoScript.currentStressPoints == 40f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(-15f, 0f, 25f);
            GameObject.Find("Message").GetComponent<Text>().text = "You have anxiety because your paper due tomorrow and you have not finished it.";
            GameObject.Find("Changes").GetComponent<Text>().text = "Health -10 Stress +25";
        }
         // Gym, you went to work out.
         if(infoScript.currentEnergyPoints == 80f && infoScript.currentHealthPoints == 100f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(15f, -5f, 0f);
            GameObject.Find("Message").GetComponent<Text>().text = "You went to the gym because you were feeling energetic";
            GameObject.Find("Changes").GetComponent<Text>().text = "Health +15 Energy -5";
        }
         // woke up late.
         if (infoScript.currentStressPoints == 55f && infoScript.currentEnergyPoints == 30f)
        {
            Menu.SetActive(true);
            infoScript.changeGaugePoints(0f, 0f, 25f);
            GameObject.Find("Message").GetComponent<Text>().text = "You woke up late for Class!";
            GameObject.Find("Changes").GetComponent<Text>().text = "Stress +25";
        }
    }

    public void checkEnd()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        if(infoScript.CurrentQuestion == 12 && infoScript.currentScore >= 90)
        {
            GameEnd.SetActive(true);
            GameObject.Find("EndMessage").GetComponent<Text>().text = "Congrats! You have successfully beaten SiC:TG!";
            GameObject.Find("EndMessage").GetComponent<Text>().color = Color.green;
            GameObject.Find("ScoreMessage").GetComponent<Text>().text = "You were able to successfully graduate! Good Job!";
        }
        else if(infoScript.CurrentQuestion == 12 && infoScript.currentScore <= 90)
        {
            GameEnd.SetActive(true);
            GameObject.Find("EndMessage").GetComponent<Text>().text = "You Failed Out";
            GameObject.Find("EndMessage").GetComponent<Text>().color = Color.red;
            GameObject.Find("ScoreMessage").GetComponent<Text>().text = "You gave it your all but college just wasn't for you... You did not graduate.";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//---------------------------------------------------------------------------------------------------------------
//Stephen Romer
//UniversalInfo Script
//Version Date 04/27/2019
//This script acts as the middle man/processing point between all core game functions and the studentHUD
//Here, all ongoing game data will be alloacted and processed to the HUD and vice versa.
//All areas are supposed to be process throught here.
//---------------------------------------------------------------------------------------------------------------

public class UniversalInfo : MonoBehaviour
{
    //General player info that will be updated constantly throughout the game time
    public double currentGPA;
    public int currentScore;
    public string currentMajor;
    public string currentClass1;
    public string currentClass2;
    public string currentClass3;
    public string currentSemester;
    public float currentHealthPoints;
    public float currentEnergyPoints;
    public float currentStressPoints;
    public int CurrentQuestion; 

    //Function to update current GPA 
    public void updateGPA(double newGPA)
    {
        currentGPA = newGPA;
    }

    public void updateQuest(int newQuest)
    {
        CurrentQuestion = newQuest;
    }

    //Function to update current score
    public void updateScore(int newScore)
    {
        currentScore = newScore;
    }

    //Function that updates current classes taken
    public void updateCurrentClasses(string newClass1, string newClass2, string newClass3)
    {
        currentClass1 =  newClass1;
        currentClass2 = newClass2;
        currentClass3 = newClass3;
    }

    //Function that updates current semester
    public void updateCurrentSemester(string newSemester)
    {
        currentSemester = newSemester;
    }

    //Function that updates the variables of each stat gauge
    public void changeGaugePoints(float health, float energy, float stress)
    {
        currentHealthPoints += health;
        currentEnergyPoints += energy;
        currentStressPoints += stress;

    }

    //Updates stat bar gauges to be displayed to the HUD
    public void updateStatBars()
    {
        GameObject healthBar = GameObject.Find("HealthBar");
        GameObject energyBar = GameObject.Find("EnergyBar");
        GameObject stressBar = GameObject.Find("StressBar");

        statBar healthScript = healthBar.GetComponent<statBar>();
        statBar energyScript = energyBar.GetComponent<statBar>();
        statBar stressScript = stressBar.GetComponent<statBar>();

        healthScript.hitPoints = currentHealthPoints;
        energyScript.hitPoints = currentEnergyPoints;
        stressScript.hitPoints = currentStressPoints;

        healthScript.CurrentStatBar = healthBar.GetComponent<Image>();
        energyScript.CurrentStatBar = energyBar.GetComponent<Image>();
        stressScript.CurrentStatBar = stressBar.GetComponent<Image>();

        healthScript.updateStatBar();
        energyScript.updateStatBar();
        stressScript.updateStatBar();

    }

    //INITIALIZES CHOICES CHOSEN FROM INITIAL SETUP, DO NOT TOUCH THIS AS IT WILL BREAK IF CHANGED
    public void initialChoices()
    {
        //Initialization of the games start choices, which will be passed to the HUD
        GameObject intialStudentInfo = GameObject.Find("StudentRegistrationHandler");
        studentRegistration studentScript = intialStudentInfo.GetComponent<studentRegistration>();

        currentMajor = studentScript.selectedMajor;
        currentClass1 = studentScript.selectedClassOne;
        currentClass2 = studentScript.selectedClassTwo;
        currentClass3 = studentScript.selectedClassThree;
        currentScore = 0;
        currentSemester = "Start of College!";
        currentHealthPoints = 100f;
        currentEnergyPoints = 100f;
        currentStressPoints = 10f;
    }

    public void overflowCatch()
    {
        //-----------------------------------------------------------//
        //TERRIBLY OPTIMIZED BUT GETS THE JOB DONE FOR THE TIME BEING//
        //-----------------------------------------------------------//

        //Keeps stat bars from neg overflow
        if (currentHealthPoints <= 0)
        {
            currentHealthPoints = 0f;
        }
        if (currentEnergyPoints <= 0)
        {
            currentEnergyPoints = 0f;
        }
        if (currentStressPoints <= 0)
        {
            currentStressPoints = 0f;
        }

        //Keeps stat bars from pos overflow
        if (currentHealthPoints >= 100)
        {
            currentHealthPoints = 100f;
        }
        if (currentEnergyPoints >= 100)
        {
            currentEnergyPoints = 100f;
        }
        if (currentStressPoints >= 100)
        {
            currentStressPoints = 100f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Empty for rn
    }

    // Update is called once per frame
    void Update()
    {
        overflowCatch();
    }
}

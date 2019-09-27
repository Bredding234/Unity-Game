using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//----------------------------------------------------------------------------------------
//Stephen Romer
//AcademicServices Script
//Version Data 4/28/2019
//This script is to be used in conjuntion with the academic services level in SICTG
//----------------------------------------------------------------------------------------

public class AcademicServices : MonoBehaviour
{
    //public GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
    //public UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
    public Dropdown NewMajor;
    public Dropdown NewClass1;
    public Dropdown NewClass2;
    public Dropdown NewClass3;
    public Dropdown ClassesTaken;
    public Text CurrentMajor;
    
    public void changeClasses()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        infoScript.updateCurrentClasses(NewClass1.options[NewClass1.value].text, 
            NewClass2.options[NewClass2.value].text, 
            NewClass3.options[NewClass3.value].text);
    }

    public void changeMajor()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        infoScript.currentMajor = (NewMajor.options[NewMajor.value].text);
    }

    public void changeClassOptions()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        GameObject reg = GameObject.Find("registrationInfoDump");
        studentRegistration regScript = reg.GetComponent<studentRegistration>();

        NewClass1.ClearOptions();
        NewClass2.ClearOptions();
        NewClass3.ClearOptions();

        switch (infoScript.currentMajor)  //instantiates class choices
        {
            case "Undecided":
                NewClass1.AddOptions(regScript.UndecidedClasses);
                NewClass2.AddOptions(regScript.UndecidedClasses);
                NewClass3.AddOptions(regScript.UndecidedClasses);
                checkClasses();
                break;
            case "Computer Science":
                NewClass1.AddOptions(regScript.CompSciClasses);
                NewClass2.AddOptions(regScript.CompSciClasses);
                NewClass3.AddOptions(regScript.CompSciClasses);
                checkClasses();
                break;
            case "Fine Art":
                NewClass1.AddOptions(regScript.FineArtClasses);
                NewClass2.AddOptions(regScript.FineArtClasses);
                NewClass3.AddOptions(regScript.FineArtClasses);
                checkClasses();
                break;
            case "Engineering":
                NewClass1.AddOptions(regScript.EngineeringClasses);
                NewClass2.AddOptions(regScript.EngineeringClasses);
                NewClass3.AddOptions(regScript.EngineeringClasses);
                checkClasses();
                break;
            case "History":
                NewClass1.AddOptions(regScript.HistoryClasses);
                NewClass2.AddOptions(regScript.HistoryClasses);
                NewClass3.AddOptions(regScript.HistoryClasses);
                checkClasses();
                break;
            case "Buisness":
                NewClass1.AddOptions(regScript.BuisnessClasses);
                NewClass2.AddOptions(regScript.BuisnessClasses);
                NewClass3.AddOptions(regScript.BuisnessClasses);
                checkClasses();
                break;
            case "Gender Studies":
                NewClass1.AddOptions(regScript.GenderClasses);
                NewClass2.AddOptions(regScript.GenderClasses);
                NewClass3.AddOptions(regScript.GenderClasses);
                checkClasses();
                break;
        }
    }

    public void checkClasses()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        for (int x = 0; x < NewClass1.options.Count; x++)
        {
            if (NewClass1.options[x].text == infoScript.currentClass1)
            {
                NewClass1.options.RemoveAt(x);
                //break;
            }

            for (int y = 0; x < NewClass2.options.Count; y++)
            {
                if (NewClass2.options[y].text == infoScript.currentClass2)
                {
                    NewClass2.options.RemoveAt(y);
                    //break;
                }

                for (int z = 0; z < NewClass3.options.Count; z++)
                {
                    if (NewClass3.options[z].text == infoScript.currentClass3)
                    {
                        NewClass3.options.RemoveAt(z);
                        break;
                    }
                }
            }
        }     
    }

    public void checkFinAid()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();
    }

    public void checkMajor()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        //Removes your major from the list
        for (int x = 0; x < NewMajor.options.Count; x++)
        {
            if (NewMajor.options[x].text == infoScript.currentMajor)
            {
                NewMajor.options.RemoveAt(x);
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject reg = GameObject.Find("registrationInfoDump");
        studentRegistration regScript = reg.GetComponent<studentRegistration>();

        //adds major choices to the list
        NewMajor.AddOptions(regScript.Majors);
        changeClassOptions();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameInfo = GameObject.Find("UniversalInfoHandler");
        UniversalInfo infoScript = gameInfo.GetComponent<UniversalInfo>();

        CurrentMajor.text = infoScript.currentMajor;

        checkMajor();
        //checkClasses();
    }
}

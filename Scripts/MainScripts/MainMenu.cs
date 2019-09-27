using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//---------------------------------------------------------------------------------------------------------------
//Stephen Romer
//Main Menu Script
//Version Date 04/14/2019
//---------------------------------------------------------------------------------------------------------------

public class MainMenu : MonoBehaviour
{
    //Game Objects for Main Menu and Maps
    public GameObject HUD;
    public GameObject Menu;
    public GameObject UniversalInfoHandler;

    //Functions that the the main menu and each level uses
    public void loadMainMenu()
    {
        UniversalInfoHandler = GameObject.Find("UniversalInfoHandler");
        DontDestroyOnLoad(UniversalInfoHandler);
        //UniversalInfoHandler = UniversalInfoHandler;
        SceneManager.LoadScene("MainMenuMap");
    }

    

    public void loadHome()
    {
        SceneManager.LoadScene("HomeLevel");
        DontDestroyOnLoad(HUD);
        Menu.SetActive(false);
    }

    public void loadAcademicServices()
    {
        SceneManager.LoadScene("AcademicServicesLevel");
        DontDestroyOnLoad(HUD);
        Menu.SetActive(false);
    }

    public void loadHealthServices()
    {
        SceneManager.LoadScene("HealthServicesLevel");
        DontDestroyOnLoad(HUD);
        Menu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Escape()
    {
        SceneManager.LoadScene("MainMenuMap");
        HUD.SetActive(false);
        //DontDestroyOnLoad(UniversalInfoHandler);
    }
}

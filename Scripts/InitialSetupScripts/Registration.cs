using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerSpace.CSharp;
using System;

//Stephen Romer
//Team Cipher
//Updated 04-05-2019
//This is the Registration Script

public class Registration : MonoBehaviour 
{
    //Game Menu's Related to Sign In
    public GameObject WelcomeScreen;
    public GameObject SignIn;
    public GameObject SignUp;

    //Sign Up Input Fields
    public InputField enteredEmail;
    public InputField enteredUsername;
    public InputField enteredPassword;
    public Text output;

    //Sign In Input Fields
    public InputField usernameChecked;
    public InputField passwordChecked;

    //Player Name Text Object
    public Text playerCard;

    //Player Test
    Player playerOne;

    public void Start()
    {
        Player playerOne = new Player();
    }
    
    public void createPlayerCredentials()
    {
        playerOne.email = enteredEmail.text;
        playerOne.username = enteredUsername.text;
        playerOne.password = enteredPassword.text;

        //Assigns Player Card UI to the username chosen
        playerCard.GetComponent<Text>().text = "Current Player: " + playerOne.username;
    }

    public void checkPlayerCredentials()
    {
        try
        {
            if (playerOne.username == "" && playerOne.password == "" || playerOne.username == " " && playerOne.password == " ")
            {
                output.text = "ERROR: EMPTY CREDENTIALS ENTERED";
            }
            else if (usernameChecked.text == playerOne.username && passwordChecked.text == playerOne.password)
            {
                SignIn.SetActive(false);
                WelcomeScreen.SetActive(true);
            }
            else
            {
                output.text = "ERROR: INVALID CREDENTIALS ENTERED";
            }
        }
        //This might not be needed, IDK if this will ever get thrown...
        catch(ArgumentException e) when (e.ParamName == null)
        {
            Debug.Log("Got Here");
            if (playerOne.username == null && playerOne.password == null)
            {
                output.text = "ERROR: EMPTY CREDENTIALS ENTERED";
                throw;
            }
        }
    }
}       

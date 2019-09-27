using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StudentSpace.CSharp;

//---------------------------------------------------------------------------------------------------------------
//Stephen Romer
//Student Registration Script
//Version Date 04/14/2019
//---------------------------------------------------------------------------------------------------------------

public class studentRegistration : MonoBehaviour
{
    //Initial In Game Elements/Objects
    public Dropdown MajorsChoices;
    public Dropdown ClassChoice1;
    public Dropdown ClassChoice2;
    public Dropdown ClassChoice3;
    public Dropdown HousingChoices;
    public Dropdown ParentWealth;
    public Dropdown StudentWealth;

    //Lists of Majors 
    public List<string> Majors = new List<string>() { "Undecided", "Computer Science", "Fine Arts", "Engineering", "History",
        "Buisness", "Gender Studies"};
    //Lists of Classes based on Major Name
    public List<string> UndecidedClasses = new List<string>() { "Intro to Literature", "Intro to Psch", "Math 101",
        "Art Appreciation", "Procrastination Studies", "Underwater Basket Weaving" };
    public List<string> CompSciClasses = new List<string>() { "Intro to Computing", "Calculus I", "Statistics",
        "Databases 101", "HTML 4 Dummiez", "Crypto-Mining", "Switches: A Case Study", "Sneaky Math" };
    public List<string> FineArtClasses = new List<string>() { "Art 101", "Photography", "Finger Painting", "Pottery",
        "Barista Studies", "Depression and You", "How 2 Be Banksy" };
    public List<string> EngineeringClasses = new List<string>() { "Fluids 1", "Vibrations", "Circuits 1", "Calculus 1",
        "Eigen Values and U", "", "Linear Algebra" };
    public List<string> HistoryClasses = new List<string>() { "Hamilton: More Than A Play", "The 1000 Month Skirmish", "Soviet History",
        "Ancient Europeans", "Just Hitler Things", "Modern Religon", "Charlie and the Trees" };
    public List<string> BuisnessClasses = new List<string>() { "Insider Trading 101", "Marketing in 2019", "Cocaine",
        "How to bribe the SEC", "Harvard Buisness", "Wolf and Wallstreet", "Buy H Sell L" };
    public List<string> GenderClasses = new List<string>() { "1", "2", "3", "4", "5", "6", "7" };

    Student studentOne;

    //Students STATS For Access By UniversalInfoScript
    public string selectedMajor;
    public string selectedClassOne;
    public string selectedClassTwo;
    public string selectedClassThree;
    public string startingGPA;
    public string startingScore;

    //Assigns the player their major based on choice selected from the menu
    public void AssignMajorSelection()
    {   
        studentOne.currentMajor = (MajorsChoices.options[MajorsChoices.value].text);
        Debug.Log(studentOne.currentMajor);
    }

    //Assigns the player their classes based on their choice selected from the menus
    public void AssignClassChoices()
    {
        studentOne.currentClass1 = (ClassChoice1.options[ClassChoice1.value].text);
        studentOne.currentClass2 = (ClassChoice2.options[ClassChoice2.value].text);
        studentOne.currentClass3 = (ClassChoice3.options[ClassChoice3.value].text);
        
        Debug.Log(studentOne.currentClass1);
        Debug.Log(studentOne.currentClass2);
        Debug.Log(studentOne.currentClass3);
    }

    //Changes the list of available classes based on major chosen
    public void UpdateClassSelection()
    {
        //Clears any duplicate answers
        ClassChoice1.ClearOptions();
        ClassChoice2.ClearOptions();
        ClassChoice3.ClearOptions();
       
        switch (studentOne.currentMajor)  //instantiates class choices
        {
            case "Undecided":
                ClassChoice1.AddOptions(UndecidedClasses);
                ClassChoice2.AddOptions(UndecidedClasses);
                ClassChoice3.AddOptions(UndecidedClasses);
                break;
            case "Computer Science":
                ClassChoice1.AddOptions(CompSciClasses);
                ClassChoice2.AddOptions(CompSciClasses);
                ClassChoice3.AddOptions(CompSciClasses);
                break;
            case "Fine Arts":
                ClassChoice1.AddOptions(FineArtClasses);
                ClassChoice2.AddOptions(FineArtClasses);
                ClassChoice3.AddOptions(FineArtClasses);
                break;
            case "Engineering":
                ClassChoice1.AddOptions(EngineeringClasses);
                ClassChoice2.AddOptions(EngineeringClasses);
                ClassChoice3.AddOptions(EngineeringClasses);
                break;
            case "History":
                ClassChoice1.AddOptions(HistoryClasses);
                ClassChoice2.AddOptions(HistoryClasses);
                ClassChoice3.AddOptions(HistoryClasses);
                break;
            case "Buisness":
                ClassChoice1.AddOptions(BuisnessClasses);
                ClassChoice2.AddOptions(BuisnessClasses);
                ClassChoice3.AddOptions(BuisnessClasses);
                break;
            case "Gender Studies":
                ClassChoice1.AddOptions(GenderClasses);
                ClassChoice2.AddOptions(GenderClasses);
                ClassChoice3.AddOptions(GenderClasses);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Student studentOne = new Student(); //instanitates player structs
        MajorsChoices.AddOptions(Majors); //instantiates major choices
    }

    void Update()
    {   
        //Checks for changes in initial choices constantly
        selectedMajor = studentOne.currentMajor;
        selectedClassOne = studentOne.currentClass1;
        selectedClassTwo = studentOne.currentClass2;
        selectedClassThree = studentOne.currentClass3;
    }
}

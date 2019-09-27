using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerSpace.CSharp;

//Stephen Romer
//Team Cipher
//Updated 04-03-2019
//This is the stat bars Script
//WORK IN PROGRESS

public class statBar : MonoBehaviour
{
    public Image CurrentStatBar;
    public float hitPoints;
    public float maxHitPoints = 100f;


    public void updateStatBar()
    {
        float ratio = hitPoints / maxHitPoints;
        CurrentStatBar.rectTransform.localScale = new Vector3(1, ratio, 1);
    }
}

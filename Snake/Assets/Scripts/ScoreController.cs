using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoretextp1;
    public TextMeshProUGUI scoretextp2;

    private int p1score;
    private int p2score;



    private void Start()
    {
        RefreshUI();
    }

    public void IncreaseScoreP1(int increment)
    {
        p1score += increment;
        RefreshUI();
    }

    public void IncreaseScoreP2(int increment)
    {
        
        p2score += increment;
        RefreshUI();
    }

    public void DecreaseScoreP1(int increment)
    {
        p1score -= increment;
        RefreshUI();
    }

    public void DecreaseScoreP2(int increment)
    {
        p2score -= increment;
        RefreshUI();
    }



    private void RefreshUI()
    {
        scoretextp1.text = "P1 Score : " + p1score;
        scoretextp2.text = "P2 Score : " + p2score;
    }
}
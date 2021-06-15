using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public static int score;

    public TextMeshProUGUI text;

    void Start()
    {
        //text = GetComponentInChildren<TextMeshProUGUI>();

        score = 0;
    }

    void Update()
    {
        if (score < 0) {
            score = 0;
        }

        text.text = "Score: " + score;
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}

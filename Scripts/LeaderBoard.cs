using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text[] highScores;

    float[] highScoreValues;
    string[] highScoreNames;

    private Timer timer;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreValues = new float[highScores.Length];
        highScoreNames = new string[highScores.Length];

        for (int x = 0; x < highScores.Length; x++)
        {
            highScoreValues[x] = PlayerPrefs.GetFloat("highScoreValues" + x);
            highScoreNames[x] = PlayerPrefs.GetString("highScoreNames" + x);
        }
        DrawScores();
    }

    public void CheckForHighScore(float value, string userName)
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            if (value>highScoreValues[x])
            {
                for (int y = highScores.Length - 1; y > x; y--)
                {
                    highScoreValues[y] = highScoreValues[y - 1];
                    highScoreNames[y] = highScoreNames[y - 1];
                }
                highScoreValues[x] = value;
                highScoreNames[x] = userName;

                break;
            }
        }
        DrawScores();
        SaveScores();
    }

    void SaveScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            PlayerPrefs.SetFloat("highScoreValues" + x, highScoreValues[x]);
            PlayerPrefs.SetString("highScoreNames" + x, highScoreNames[x]);
        }
    }

    void DrawScores()
    {
        for (int x = 0; x < highScores.Length; x++)
        {
            highScores[x].text = x + 1 + ": " + highScoreNames[x] + " (" + highScoreValues[x].ToString("f1") + ")";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

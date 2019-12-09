using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float time;
    private PlayerController pc;

    void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isGameRunning)
        {
            time += Time.deltaTime;

            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f1");

            timerText.text = minutes + ":" + seconds + "  Score: " + ScoreCounter.score.ToString();
            //timerText.text = ScoreCounter.score.ToString();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public InputController inputController;
    private Rigidbody rb;

    //private LeaderBoard lb;
    private Timer timer;
    public RectTransform panelHighScores;
    //public LeaderBoard leaderBoard;

    // speed stuff
    private float speedForward = 5.0f;
    private float accelrationForward = 0.015f;
    private float speedHorizontal = 16.0f;

    // game over screen stuff
    public RectTransform panelGameOver;
    public bool isGameRunning = false;

    // terrains
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;

    public GameObject coinObject;

    public List<Tuple<GameObject, List<Vector3>>> terrains;
    public List<Tuple<GameObject, List<Vector3>>> terrainsInUse;

    // panels for start, pause, leaderboard
    public RectTransform panelStart;
    public RectTransform panelPaused;
    


    static float coinY = 3;
    List<Vector3> coins_t1 = new List<Vector3>() {
        new Vector3(-7, coinY, -110),
        new Vector3(9, coinY, -110),
        new Vector3(25, coinY, -110),

        new Vector3(-7, coinY, -80),
        new Vector3(9, coinY, -80),
        new Vector3(25, coinY, -80),

        new Vector3(-3, coinY, -50),
        new Vector3(12, coinY, -50),
        new Vector3(28, coinY, -50),

        new Vector3(-7, coinY, -20),
        new Vector3(9, coinY, -20),
        new Vector3(25, coinY, -20),

        new Vector3(-10, coinY, 10),
        new Vector3(6, coinY, 10),
        new Vector3(22, coinY, 10),

        new Vector3(-16, coinY, 40),
        new Vector3(0, coinY, 40),
        new Vector3(16, coinY, 40),

        new Vector3(-34, coinY, 70),
        new Vector3(-18, coinY, 70),
        new Vector3(-2, coinY, 70),

        new Vector3(-34, coinY, 100),
        new Vector3(-18, coinY, 100),
        new Vector3(-2, coinY, 100),
    };
    List<Vector3> coins_t2 = new List<Vector3>() {
        new Vector3(-13, coinY, -110),
        new Vector3(3, coinY, -110),
        new Vector3(19, coinY, -110),

        new Vector3(-7, coinY, -80),
        new Vector3(9, coinY, -80),
        new Vector3(25, coinY, -80),

        new Vector3(-13, coinY, -50),
        new Vector3(3, coinY, -50),
        new Vector3(19, coinY, -50),

        new Vector3(-13, coinY, -20),
        new Vector3(9, coinY, -20),
        new Vector3(25, coinY, -20),

        new Vector3(-13, coinY, 10),
        new Vector3(3, coinY, 10),
        new Vector3(19, coinY, 10),

        new Vector3(-13, coinY, 40),
        new Vector3(3, coinY, 40),
        new Vector3(19, coinY, 40),

        new Vector3(-13, coinY, 70),
        new Vector3(3, coinY, 70),
        new Vector3(19, coinY, 70),

        new Vector3(-13, coinY, 100),
        new Vector3(3, coinY, 100),
        new Vector3(19, coinY, 100),
    };
    List<Vector3> coins_t3 = new List<Vector3>() {
        new Vector3(-13, coinY, -110),
        new Vector3(3, coinY, -110),
        new Vector3(19, coinY, -110),

        new Vector3(-7, coinY, -80),
        new Vector3(9, coinY, -80),
        new Vector3(25, coinY, -80),

        new Vector3(-13, coinY, -50),
        new Vector3(3, coinY, -50),
        new Vector3(19, coinY, -50),

        new Vector3(-13, coinY, -20),
        new Vector3(9, coinY, -20),
        new Vector3(25, coinY, -20),

        new Vector3(-13, coinY, 10),
        new Vector3(3, coinY, 10),
        new Vector3(19, coinY, 10),

        new Vector3(-13, coinY, 40),
        new Vector3(3, coinY, 40),
        new Vector3(19, coinY, 40),

        new Vector3(-13, coinY, 70),
        new Vector3(3, coinY, 70),
        new Vector3(19, coinY, 70),

        new Vector3(-13, coinY, 100),
        new Vector3(3, coinY, 100),
        new Vector3(19, coinY, 100),
    };
    List<Vector3> coins_t4 = new List<Vector3>() {
        new Vector3(-13, coinY, -110),
        new Vector3(3, coinY, -110),
        new Vector3(19, coinY, -110),

        new Vector3(-7, coinY, -80),
        new Vector3(9, coinY, -80),
        new Vector3(25, coinY, -80),

        new Vector3(-13, coinY, -50),
        new Vector3(3, coinY, -50),
        new Vector3(19, coinY, -50),

        new Vector3(-13, coinY, -20),
        new Vector3(9, coinY, -20),
        new Vector3(25, coinY, -20),

        new Vector3(-13, coinY, 10),
        new Vector3(3, coinY, 10),
        new Vector3(19, coinY, 10),

        new Vector3(-13, coinY, 40),
        new Vector3(3, coinY, 40),
        new Vector3(19, coinY, 40),

        new Vector3(-13, coinY, 70),
        new Vector3(3, coinY, 70),
        new Vector3(19, coinY, 70),

        new Vector3(-13, coinY, 100),
        new Vector3(3, coinY, 100),
        new Vector3(19, coinY, 100),
    };
    List<Vector3> coins_t5 = new List<Vector3>() {
        new Vector3(-13, coinY, -110),
        new Vector3(3, coinY, -110),
        new Vector3(19, coinY, -110),

        new Vector3(-7, coinY, -80),
        new Vector3(9, coinY, -80),
        new Vector3(25, coinY, -80),

        new Vector3(-13, coinY, -50),
        new Vector3(3, coinY, -50),
        new Vector3(19, coinY, -50),

        new Vector3(-13, coinY, -20),
        new Vector3(9, coinY, -20),
        new Vector3(25, coinY, -20),

        new Vector3(-13, coinY, 10),
        new Vector3(3, coinY, 10),
        new Vector3(19, coinY, 10),

        new Vector3(-13, coinY, 40),
        new Vector3(3, coinY, 40),
        new Vector3(19, coinY, 40),

        new Vector3(-13, coinY, 70),
        new Vector3(3, coinY, 70),
        new Vector3(19, coinY, 70),

        new Vector3(-13, coinY, 100),
        new Vector3(3, coinY, 100),
        new Vector3(19, coinY, 100),
    };

    private System.Random rnd = new System.Random();
    private int z = 0;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        coinObject.SetActive(false);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        terrains = new List<Tuple<GameObject, List<Vector3>>>() {
            new Tuple<GameObject, List<Vector3>>(t1, coins_t1),
            new Tuple<GameObject, List<Vector3>>(t2, coins_t2),
            new Tuple<GameObject, List<Vector3>>(t3, coins_t3),
            new Tuple<GameObject, List<Vector3>>(t4, coins_t4),
            new Tuple<GameObject, List<Vector3>>(t5, coins_t5),
        };
        terrainsInUse = new List<Tuple<GameObject, List<Vector3>>>() { terrains[0] };
        List<Vector3> terrain1WithoutFirst3 = new List<Vector3>();
        for (int i = 3; i < coins_t1.Count; i++)
        {
            terrain1WithoutFirst3.Add(coins_t1[i]);
        }
        SpawnCoins(terrain1WithoutFirst3);

        // add 2nd terrain immediately
        Tuple<GameObject, List<Vector3>> randomTerrain = terrains[1];
        z++;
        terrainsInUse.Add(randomTerrain);
        randomTerrain.Item1.transform.position = new Vector3(0, 0, z * 254);
        randomTerrain.Item1.gameObject.SetActive(true);
        SpawnCoins(randomTerrain.Item2);


    }

    // allows boat to move - if game over then the boat stops moving
    void FixedUpdate()
    {
        if (isGameRunning)
        {
            rb.position -= transform.up * Time.deltaTime * speedForward;
            
            speedForward += accelrationForward;


            if (inputController.getMovementDirection() == MovementDirection.LEFT)
            {
                rb.position -= transform.right * Time.deltaTime * speedHorizontal;
                //transform.Rotate(0, 0, Time.deltaTime * -10f,  Space.Self);
            }
            else if (inputController.getMovementDirection() == MovementDirection.RIGHT)
            {
                rb.position += transform.right * Time.deltaTime * speedHorizontal;
                //transform.Rotate(0, 0, Time.deltaTime * 10f, Space.Self);
            }
        }
        CheckKeyCommand();
    }

    // checks if boat collides with terrain - if yes game over
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            panelGameOver.gameObject.SetActive(true);
            isGameRunning = false;
        }
    }

    public void StartScreenScores() {

        //lb.CheckForHighScore(timer.time, playerName.text);
    }

    // checks if player triggers terrain spawner and spawns 1 of the 5 terrains on the next z coordinate
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("TerrainSpawner"))
        {
            List<Tuple<GameObject, List<Vector3>>> terrainsNotUsed = terrains.Where(x => !terrainsInUse.Contains(x)).ToList();
            int nextRandom = rnd.Next(terrainsNotUsed.Count);
            Tuple<GameObject, List<Vector3>> randomTerrain = terrainsNotUsed[nextRandom];
            z++;
            terrainsInUse.RemoveAt(0);
            terrainsInUse.Add(randomTerrain);
            randomTerrain.Item1.transform.position = new Vector3(0, 0, z * 254);
            randomTerrain.Item1.gameObject.SetActive(true);

            SpawnCoins(randomTerrain.Item2);
        }
    }

    private void SpawnCoins(List<Vector3> coinPositions)
    {
        foreach (Vector3 coinPosition in coinPositions)
        {
            if (rnd.Next(2) < 1)
            {
                Instantiate(coinObject, new Vector3(coinPosition.x, coinPosition.y, coinPosition.z + z * 254), Quaternion.identity).SetActive(true);
            }
        }
    }

    // checks if either button for restart or quit is pressed
    void CheckKeyCommand()
    {
        if (Input.GetKeyUp(KeyCode.R))
            SceneManager.LoadScene(0);
        else if (Input.GetKeyUp(KeyCode.Q))
            UnityEditor.EditorApplication.isPlaying = false;
            // use this in application mode
            //Application.Quit();
        else if (Input.GetKeyUp(KeyCode.P))
        {
            if (!isGameRunning)
            {
                panelPaused.gameObject.SetActive(false);
                isGameRunning = true;
            }
            else if (isGameRunning)
            {
                panelPaused.gameObject.SetActive(true);
                isGameRunning = false;
            }
        }
    }
}
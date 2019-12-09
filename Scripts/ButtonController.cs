using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private PlayerController playerController;
    public RectTransform panelHighScores;
    public GameObject handsFreeButton;
    public GameObject handsOnButton;
    public RectTransform PanelhandsOnInstructions;
    public RectTransform PanelhandsFreeInstructions;
    // stuff for player name
    public InputField playerName;
    public Button submitButton;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void HandsOnInstructions() {
        RectTransform panelStart = playerController.panelStart;
        GameObject panelStartObject = panelStart.gameObject;
        panelStartObject.SetActive(false);
        PanelhandsOnInstructions.gameObject.SetActive(true);
    }

    public void HandsFreeInstructions() {
        RectTransform panelStart = playerController.panelStart;
        GameObject panelStartObject = panelStart.gameObject;
        panelStartObject.SetActive(false);
        PanelhandsFreeInstructions.gameObject.SetActive(true);
    }

    public void ShowScores() {
       // RectTransform panelHighScores = playerController.panelHighScores;
        if (panelHighScores.gameObject.activeSelf)
        {
            panelHighScores.gameObject.SetActive(false);
                handsFreeButton.SetActive(true);
                handsOnButton.SetActive(true);
        }
        else
        {
            panelHighScores.gameObject.SetActive(true);
            playerController.StartScreenScores();
            handsFreeButton.SetActive(false);
            handsOnButton.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // use this in application mode
        //Application.Quit();
    }

    public void HandsOnStart()
    {
        RectTransform panelStart = playerController.panelStart;
        GameObject panelStartObject = panelStart.gameObject;
        PanelhandsOnInstructions.gameObject.SetActive(false);
        playerController.isGameRunning = true;
        playerController.inputController = new KeyboardInputController();
    }

    public void HandsFreeStart()
    {
        RectTransform panelStart = playerController.panelStart;
        GameObject panelStartObject = panelStart.gameObject;
        PanelhandsFreeInstructions.gameObject.SetActive(false);
        playerController.isGameRunning = true;
        if (playerController.inputController != null && playerController.inputController is CameraInputController)
        {
            ((CameraInputController)playerController.inputController).disable();
        }
        playerController.inputController = new CameraInputController();
    }

    public void InitialsEntered()
    {
        //lb.CheckForHighScore(timer.time, playerName.text);
        LeaderBoard lb = FindObjectOfType<LeaderBoard>();
        lb.CheckForHighScore((float)ScoreCounter.score, playerName.text);
        ScoreCounter.score = 0;
        submitButton.gameObject.SetActive(false);
        playerName.gameObject.SetActive(false);
    }
}

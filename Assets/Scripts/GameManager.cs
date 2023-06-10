using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Score (how many levels beaten)
    int score = 0;
    //Grades (how many lives left. Reach F = Game Over)
    string[] grades = { "A", "B", "C", "D", "F"};
    int gradeIndex = 0;

    //Text Objects for the grade/score test
    TextMeshProUGUI gradeText;
    TextMeshProUGUI scoreText;

    //Set to false when the game is over
    bool gameActive = true;

    //These are used for counting down the timer
    //The current time limit
    float time;
    //The time (in seconds since start of program) of the last clock reset
    float lastReset;
    //Maximum time for a microgame to take
    public float maxTime = 5f;
    //Minimum time for a microgame to take
    public float minTime = 2f;
    //Time to subtract from time given every cycle
    public float timeDelta = 0.1f;

    //The Game Over screen: needs to be disabled in Inspector
    public GameObject endScreen;
    
    //This is the array of microgames to swap between 
    // It needs to be filled in the Inspector
    // If you're just testing one, you 
    public GameObject[] games;
    int gamesIndex = 0;

    //The timer slider object
    Slider timer;

    // Start is called before the first frame update
    void Start()
    {
        //Locate the text objects
        gradeText = GameObject.Find("Grade").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        //Update the text objects
        scoreText.text = score.ToString();
        gradeText.text = grades[gradeIndex];

        //Locate the timer object
        timer = GameObject.Find("Timer").GetComponent<Slider>();

        //Set timer values
        time = maxTime;
        timer.maxValue = time;
        timer.value = time;

        //Set lastReset to current time
        lastReset = Time.time;

        //deactivate the GameOver Screen
        endScreen.SetActive(false);

        //deactivate all games in the scene
        foreach (GameObject g in games){
            g.SetActive(false);
        }
        //Pick a random new microgame and activate it
        PickNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //only run if game is not over
        if (gameActive) { 

            //decrement timer
            timer.value = time - (Time.time - lastReset);
            //If timer goes zero or below, end game
            if (time - (Time.time - lastReset) <= 0) {
                Loss();
            }
       
            //Debug win/loss triggers [REMOVE BEFORE SHIPPING!!!]
            if (Input.GetKeyDown(KeyCode.W))
            {
                Win();
            }
            /*
            if (Input.GetKeyDown(KeyCode.L))
            {
                Loss();
            }
            */
        }
    }

    //Called any time we need to reset the timer
    void ResetTimer() {
        //reduce the max time per game
        time -= timeDelta;
        if (time < minTime) {
            time = minTime;
        }
        //reset the timer slider
        timer.maxValue = time;
        timer.value = time;
        //change lastReset to current time
        lastReset = Time.time;
    }

    //Called to trigger winning a microgame 
    //CAN BE CALLED FROM OTHER SCRIPTS
    public void Win() {
        //increase and update score
        ++score;
        scoreText.text = score.ToString();
        //Reset timer
        ResetTimer();
        //generate new level
        PickNewLevel();
    }
    //Called to trigger a loss
    //CAN BE CALLED FROM OTHER SCRIPTS [although not necessary]
    public void Loss() {
        if (gameActive)
        {
            //increase and update grade count;
            ++gradeIndex;
            gradeText.text = grades[gradeIndex];
            //if grade == "F", Game Over
            if (gradeIndex == 4) 
            {
                GameOver();
            }
            else
            {
                //Reset Timer
                ResetTimer();
                //Generate New Level
                PickNewLevel();
            }
        }
    }

    //Generate and activate a new microgame
    void PickNewLevel() {
        //Deactivate current game
        games[gamesIndex].SetActive(false);

        //generate random number != current game index
        int newIndex = gamesIndex;
        if (games.Length == 1)
        {
            newIndex = 0;
        }
        else
        {
            while (newIndex == gamesIndex)
            {
                newIndex = Random.Range(0, games.Length);
            }
        }

        //activate new scene, update build index
        games[newIndex].SetActive(true);
        gamesIndex = newIndex;
    }

    //Reset the Scene (for game over)
    public void RestartLevel() {
        //unpause time
        Time.timeScale = 1;
        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Activate Game Over state
    void GameOver() {
        //pause time
        Time.timeScale = 0;
        gameActive = false;
        //activate end screen
        endScreen.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int counter = 0;
    public GameObject cameraAudio;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    //public starter Starter;

    public GameObject ball;

    private int scoreLeft;
    private int scoreRight;

    private BallController ballController;

    private Vector3 startingPosition;

    public GameObject menubtn;
    public GameObject menupanel;

    public countdown_Script start_counter;
    public GameObject extraball;

    //public Text Player_Highscore;

    // Player High Score
    public static int playerHighScore;

    public Text highscore;


    // Start is called before the first frame update
    void Start()
    {

        // Load playerHighScore from PlayerPrefs
        playerHighScore = PlayerPrefs.GetInt("PlayerHighScore", 0);
        BallController.stopped = false;
        Time.timeScale = 1;
        start_counter.countdown();
        this.startingPosition = this.ball.transform.position;
        this.ballController = this.ball.GetComponent<BallController>();
        extraball.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame()
    {
        
        Time.timeScale = 1;
        this.ballController.Go();
        extraball.SetActive(false);
        BallController.speed = 8f;

    }

    public void ScoreGoalLeft()
    {
        scoreRight += 1;
        CheckHighScore();
        UpdateUI();
        ResetBall();
        extraball.SetActive(false);
        BallController.speed = 8f;
    }

    public void ScoreGoalRight()
    {
        scoreLeft += 1;
        CheckHighScore();
        UpdateUI();
        ResetBall();
        extraball.SetActive(false);
        BallController.speed = 8f;
    }


    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }


    private void ResetBall()
    {

        extraball.SetActive(false);
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        start_counter.countdown();
        BallController.speed = 8f;


    }

    /// <summary>
    /// /////////////////////
    /// </summary>

    public void Menu()
    {
        Time.timeScale = 0;
        menupanel.SetActive(true);
        menubtn.SetActive(false);
        highscore.text = playerHighScore.ToString();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        menupanel.SetActive(false);
        menubtn.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        menupanel.SetActive(false);
        menubtn.SetActive(true);
        scoreLeft = 0;
        scoreRight = 0;
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
        extraball.SetActive(false);
        BallController.speed = 8f;
        ResetBall();
    }

    public void exitgame()
    {
        SceneManager.LoadScene("MenuScene");
        menupanel.SetActive(true);
        menubtn.SetActive(false);
        extraball.SetActive(false);
        BallController.speed = 8f;
    }
    
    public void Volume()
    {
        if (counter == 0) { 
        cameraAudio.GetComponent<AudioSource>().Stop();
            counter++;
        }

        else
        {
            cameraAudio.GetComponent<AudioSource>().Play();
            counter = 0;
        }
    }

    private void CheckHighScore()
    {
        Debug.Log("Check function is called");
        print(PlayerPrefs.GetInt("PlayerHighScore"));
        /*if (scoreRight > playerHighScore)
        {
            Debug.Log("ScoreRight condition");
            playerHighScore = scoreRight;
            PlayerPrefs.SetInt("PlayerHighScore", playerHighScore);
            Debug.Log("PlayerScoreRight" + playerHighScore);
            //highscore.text = PlayerPrefs.GetInt("PlayerHighScore").ToString();
            highscore.text = playerHighScore.ToString();
        } */
        
        if (scoreLeft > playerHighScore)
        {
            Debug.Log("ScoreLeft condition");
            playerHighScore = scoreLeft;
            PlayerPrefs.SetInt("PlayerHighScore", playerHighScore);
            Debug.Log("PlayerScoreLeft" + playerHighScore);
            highscore.text = playerHighScore.ToString();
        } 
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("PlayerHighScore");
        playerHighScore = 0;
        highscore.text = PlayerPrefs.GetInt("PlayerHighScore").ToString();
        Restart();
    }

}

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;



public class GameController : MonoBehaviour
{
    
    public BallController ball;
    public Transform platform;

    
    public int ballsNumber;
    [HideInInspector]
    public int lives;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public bool gameStart;

    public Text livesText;
    public Text scoreText;
    public Text endText;

    private bool lose;
    public GameObject brick;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        gameStart = true;
    }

    void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("CurrentHS");
            ShowScore();
        }

        ballsNumber = 1;
        lives = 3;
    }

    void Update()
    {

        BricksCheck();
        Damage();
        
    }
    

    void Damage()
    {
        if (ballsNumber == 0)
        {
            audioManager.PlaySound("loseSound");
            lives--;
            livesText.text = "Lives:" + lives;
            if (lives == 0) Lose();
            gameStart = true;
            ballsNumber = 1;
            if(!lose)
            {
                Instantiate(ball, ball.startPosition, Quaternion.identity);
                platform.transform.position = Vector3.zero;
            }
        }
    }

    void Lose()
    {
        lose = true;
        endText.text = "Game Over!";
        Invoke("GameOver", 5);
    }

    void Win()
    {
        PlayerPrefs.SetInt("CurrentHS", score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("CurrentHS", score);
        SceneManager.LoadScene("Score");
    }

    
    void BricksCheck()
    {
        if(brick == null)
        {
            brick = GameObject.FindGameObjectWithTag("Brick");
            if (brick == null)
            {
                brick = GameObject.FindGameObjectWithTag("HardBrick");
                if (brick == null)
                    Win();
            }
        }
    }

    public void ShowScore()
    {
        scoreText.text = "Score:" + score;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text[] scoreValue;
    public Text[] scoreName;
    private int[] scoreInt = new int[5];

    private string tempValue;
    private string tempName;

    private void Start()
    {
        ShowHighScore();
        for (int i = 0; i < 5; i++)
        {
            scoreInt[i] = int.Parse(scoreValue[i].text);
            if (PlayerPrefs.GetInt("CurrentHS") > scoreInt[i])
            {
                tempValue = scoreValue[i].text;
                tempName = scoreName[i].text;
                scoreValue[i].text = PlayerPrefs.GetInt("CurrentHS").ToString();
                scoreName[i].text = PlayerPrefs.GetString("CurrentName");
                PlayerPrefs.SetString("Highscoreplayer" + (i+1),scoreName[i].text);
                PlayerPrefs.SetString("HighscoreValue" + (i+1), scoreValue[i].text);
                scoreValue[i].color = Color.green;
                scoreName[i].color = Color.green;
                for (int j = 4; j > i; j--)
                {
                    if (j - 1 == i)
                    {
                        scoreValue[j].text = tempValue;
                        scoreName[j].text = tempName;
                        break;
                    }

                    scoreName[j].text = scoreName[j - 1].text;
                    scoreValue[j].text = scoreValue[j - 1].text;
                }
                break;
            }
        }

        Invoke("LoadMenu",5);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ShowHighScore()
    {
        PlayerPrefs.SetString("Highscoreplayer1","BestPlayer");
        PlayerPrefs.SetString("HighscoreValue1","25200");
        PlayerPrefs.SetString("Highscoreplayer2","PlayerN1");
        PlayerPrefs.SetString("HighscoreValue2","22000");
        PlayerPrefs.SetString("Highscoreplayer3","PlayerN2");
        PlayerPrefs.SetString("HighscoreValue3","16500");
        PlayerPrefs.SetString("Highscoreplayer4","PlayerN3");
        PlayerPrefs.SetString("HighscoreValue4","11000");
        PlayerPrefs.SetString("Highscoreplayer5","PlayerN4");
        PlayerPrefs.SetString("HighscoreValue5","5500");
        
        for (int i = 0; i < 5; i++)
        {
            string player = "Highscoreplayer" + (i + 1);
            string value = "HighscoreValue" + (i + 1);
            scoreName[i].text = PlayerPrefs.GetString(player);
            scoreValue[i].text = PlayerPrefs.GetString(value);
        }
    }
}

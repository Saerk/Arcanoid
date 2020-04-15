using UnityEngine;

public class LifePUScript : PowerUp
{
    private AudioManager audioManager;
    public void LifeUp()
    {
        if(gameController.lives <= 2)
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            audioManager.PlaySound("lifeSound");

            gameController.lives++;
            gameController.livesText.text = "Lives:" + gameController.lives;
        }
    }
}

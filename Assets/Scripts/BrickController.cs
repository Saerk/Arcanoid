using UnityEngine;

public class BrickController : MonoBehaviour
{
    private int counter;
    private int probabilityOfPowerUp;

    public GameObject powerUp1;
    public GameObject powerUp2;
    public GameObject powerUp3;
    public GameObject powerUp4;
    public GameObject powerUp5;

    public AudioManager audioManager; 
    private GameController gameController;



    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }


    private void OnCollisionEnter(Collision collision)
    {
        DropPowerUp();
        DestroyBrick();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Projectile")
        {
           DestroyBrick();
        }
    }

    void DestroyBrick()
    {
        audioManager.PlaySound("brickSound");
        if(gameObject.tag == "HardBrick")
        {
            counter++;
        }
        if (gameObject.tag == "Brick" || counter == 4)
        {
            
            Destroy(gameObject);
            AddScore();
        }
        
    }

    void DropPowerUp()
    {
        probabilityOfPowerUp = Random.Range(0, 32);

        switch(probabilityOfPowerUp)
        {
            case 0:
                Instantiate(powerUp1, transform.position, transform.rotation);
                break;
            case 1:
                Instantiate(powerUp2, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(powerUp3, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(powerUp4, transform.position, transform.rotation);
                break;
            case 4:
                Instantiate(powerUp5, transform.position, transform.rotation);
                break;
        }
        
    }

    void AddScore()
    {
        switch (gameObject.name)
        {
            case "BrickRed":
                gameController.score += 80;
                gameController.ShowScore();
                break;
            case "BrickGreen":
                gameController.score += 120;
                gameController.ShowScore();
                break;
            case "BrickBlue":
                gameController.score += 100;
                gameController.ShowScore();
                break;
            case "BrickYellow":
                gameController.score += 150;
                gameController.ShowScore();
                break;
            case "BrickMagenta":
                gameController.score += 170;
                gameController.ShowScore();
                break;
            case "BrickWhite":
                gameController.score += 60;
                gameController.ShowScore();
                break;
            case "HardBrick":
                gameController.score += 200;
                gameController.ShowScore();
                break;
        }
    }
}

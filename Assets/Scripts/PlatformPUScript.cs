using UnityEngine;

public class PlatformPUScript : MonoBehaviour
{

    public GameController gameController;
    public BallController ball;
    public CatchPUScript catchPU;
    public ExpandPUScript expandPU;
    public LifePUScript lifePU;
    public SlowPUScript slowPU;
    public LaserPUScript laserPU;

    private void OnTriggerEnter(Collider other)
    {
        GameObject catchObject = GameObject.FindGameObjectWithTag("GameController");
        catchPU = catchObject.GetComponent<CatchPUScript>();
        catchPU.catchMode = false;

        GameObject laserObject = GameObject.FindGameObjectWithTag("GameController");
        laserPU = laserObject.GetComponent<LaserPUScript>();
        laserPU.laserMode = false;

        transform.localScale = new Vector3(2.5f, 0.25f, 1);
        ball.speed = 10f;

        switch (other.tag)
        {
            case "Expand":
            {
                expandPU.Expand();
                Destroy(other.gameObject);
                break;
            }

            case "Life":
            {
                GameObject lifeObject = GameObject.FindGameObjectWithTag("Life");
                lifePU = lifeObject.GetComponent<LifePUScript>();
                lifePU.LifeUp();
                Destroy(other.gameObject);
                break;
            }

            case "Slow":
            {
                GameObject slowObject = GameObject.FindGameObjectWithTag("Slow");
                slowPU = slowObject.GetComponent<SlowPUScript>();
                slowPU.Slow();
                Destroy(other.gameObject);
                break;
            }

            case "Catch":
            {
                catchPU.CatchBall();
                Destroy(other.gameObject);
                break;
            }

            case "Laser":
            {
                laserPU.laserMode = true;
                Destroy(other.gameObject);
                break;
            }
        }
    }
}

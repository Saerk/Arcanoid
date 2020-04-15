using UnityEngine;

public class SlowPUScript : PowerUp
{
    public BallController ball;

    public void Slow()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
            ball = ballObject.GetComponent<BallController>();
            ball.speed = 6f;
    }
}

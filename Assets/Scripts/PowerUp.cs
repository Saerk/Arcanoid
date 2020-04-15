using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody rb;
    protected GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        rb = GetComponent<Rigidbody>();
        transform.Rotate(0, 0, 90);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0,-5f);
        if(gameController.gameStart) Destroy(gameObject);
    }

}

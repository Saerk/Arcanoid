using UnityEngine;

public class LaserMovementScript : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Brick" || other.tag == "HardBrick")
            Destroy(gameObject);
    }
}

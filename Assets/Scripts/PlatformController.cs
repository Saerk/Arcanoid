using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    public AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal") * speed ;
        rb.velocity = new Vector3(movement, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
            audioManager.PlaySound("platformSound");
    }
}

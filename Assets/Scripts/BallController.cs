using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public CatchPUScript catchPU;
    public GameController gameController;

    private Vector3 ballPosition;
    public Vector3 startPosition;
  //  private Vector3 lastPosition;
    public Transform platform;
    private Rigidbody rb;

    public float speed = 10f;
    private float startTime;

    private bool catchFlag = false;


    void Start()
    {
        GameObject catchObject = GameObject.FindGameObjectWithTag("GameController");
        catchPU = catchObject.GetComponent<CatchPUScript>();

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();


        GameObject platformTransform = GameObject.FindGameObjectWithTag("Player");
        platform = platformTransform.transform;

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        

        if (gameController.gameStart)
        {
            startPosition =  new Vector3(platform.position.x+0.25f,platform.position.y +0.3f,0);
            StartCoroutine(StartLevel());
        }

    }

    private IEnumerator StartLevel()
    {
        rb.isKinematic = true;
        transform.position = startPosition;
        ballPosition = platform.transform.position - transform.position;
        catchFlag = true;
        yield return new WaitForSeconds(3);
        rb.isKinematic = false;
        catchFlag = false;
        PlatformBounce();
        gameController.gameStart = false;
       // lastPosition = transform.position;
        yield return null;
    }


    void FixedUpdate()
    {
        
        rb.velocity = rb.velocity.normalized * speed;

        /*Vector3 direction = transform.position - lastPosition;

        if (Physics.Raycast(lastPosition, direction, direction.magnitude))
        {
            Debug.DrawRay(lastPosition, direction, Color.yellow);
        }*/

        if(catchFlag)
        {  
            transform.position = platform.transform.position - ballPosition;
            if (Input.GetButtonUp("Fire1") && !gameController.gameStart)
            {
                rb.isKinematic = false;
                PlatformBounce();
                catchFlag = false;
            }
        }

        //lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.name == "Platform")
        {
            if(catchPU.catchMode == true)
            {
                rb.isKinematic = true;
                ballPosition = platform.transform.position - transform.position;
                catchFlag = true;
            }

            PlatformBounce();
        }
    }

    void PlatformBounce()
    {

        float hitFactor(Vector2 ballPosition, Vector2 platformPosition, float platformWidth)
        {
            return (ballPosition.x - platformPosition.x) / platformWidth;
        }

        float x = hitFactor(transform.position,
                                platform.transform.position,
                                platform.GetComponent<Collider>().bounds.size.x);

        rb.velocity = new Vector2(x, 1).normalized * speed;
    }
}

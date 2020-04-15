using UnityEngine;

public class DestroyObjectsByExit : MonoBehaviour
{
    public GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") gameController.ballsNumber--;
        Destroy(other.gameObject);
    }
}

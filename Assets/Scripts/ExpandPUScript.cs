using UnityEngine;

public class ExpandPUScript : MonoBehaviour
{
    public void Expand()
    {
        transform.localScale = new Vector3(4, 0.25f, 1);
    }
}

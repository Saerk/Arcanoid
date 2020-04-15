using UnityEngine;

public class LaserPUScript : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotSpawn;
    private AudioManager audioManager;

    private float fireDelta = 1f;
    private float myTime = 0.0f;

    public bool laserMode;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (laserMode)
        {
            myTime += Time.deltaTime;
            if (Input.GetButton("Fire1") && myTime > fireDelta)
            {
                Instantiate(projectile, shotSpawn.position,Quaternion.Euler(0,0,0));
                audioManager.PlaySound("laserSound");
                myTime = 0.0F;
            }
        }
    }
}

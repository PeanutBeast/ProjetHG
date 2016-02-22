using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public float BulletSpeed = 10;
    public GameObject bullet;
    public float RateOfFire = 0.33f;

    private float timeAtLastShot;

    // Use this for initialization
    void Start () {
        timeAtLastShot = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        ShootBullets();
	}

    private void ShootBullets()
    {
        if (Input.GetMouseButton(0))
        {

            if(Time.time - timeAtLastShot >= RateOfFire)
            {
                timeAtLastShot = Time.time;
                Transform bulletExitPoint = GameObject.Find("BulletExitPoint").transform;

                // Instantiate the projectile at the position and rotation of this transform
                GameObject clone;
                clone = (GameObject)Instantiate(bullet, bulletExitPoint.position, bulletExitPoint.rotation);

                // Add force to the cloned object in the object's forward direction
                clone.GetComponent<Rigidbody>().AddForce(clone.transform.up * BulletSpeed);
            }
        }
    }
}

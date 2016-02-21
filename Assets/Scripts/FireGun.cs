using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public float BulletSpeed = 10;
    public GameObject bullet;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ShootBullets();
	}

    private void ShootBullets()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform bulletExitPoint = GameObject.Find("BulletExitPoint").transform;

            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone;
            clone = (GameObject)Instantiate(bullet, bulletExitPoint.position, bulletExitPoint.rotation);

            // Add force to the cloned object in the object's forward direction
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.up * BulletSpeed);
        }
    }
}

using UnityEngine;
using System.Collections;

public class GetHit : MonoBehaviour {

    public Material[] lifeThreshold;
    public Renderer rend;

    public float life;

	// Use this for initialization
	void Start () {
        rend.sharedMaterial = lifeThreshold[0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetHitByBullet()
    {
        life = life - 10;

        if (life >= 70)
            rend.sharedMaterial = lifeThreshold[0];
        else if (life < 70 && life >= 30)
            rend.sharedMaterial = lifeThreshold[1];
        else if (life < 30)
            rend.sharedMaterial = lifeThreshold[2];

        if (life <= 0)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBirdController : MonoBehaviour {
    public Transform gun;
    public GameObject fireBall;
    public float range;
    public Transform player;
    public float bulletSpeed;
    bool facingRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(player.position, transform.position) <= range)
        {
            Attack();
        }
		
	}
    void Attack ()
    {

        GameObject aBullet = Instantiate(fireBall, gun.position, gun.rotation);

        Rigidbody2D bulletRigidBody;
        bulletRigidBody = aBullet.GetComponent<Rigidbody2D>();

        if (facingRight)
        {
            bulletRigidBody.velocity = new Vector2(-10, 0);
        }
        else
        {
            bulletRigidBody.velocity = new Vector2(10, 0);
        }
    }
}

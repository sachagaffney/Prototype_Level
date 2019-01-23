using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowController : MonoBehaviour {
    public float speed;
    public float timer;
    Transform target;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindWithTag("Player").transform;
        timer += 1f * Time.deltaTime;
        if(timer >= 5)
        {
         Destroy(gameObject);
        }
    }
}
 
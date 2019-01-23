using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableIceWallController : MonoBehaviour {
    public float counter; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(counter >= 3)
        {
            Destroy(gameObject);
        }
        }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireSpell"))
        {
            counter += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("IceSpell"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("WindSpell"))
        {
            Destroy(collision.gameObject);
        }
    }
    void destroyMe()
    {
        Destroy(gameObject);
    }
}

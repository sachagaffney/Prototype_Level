using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpellPickUpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            LMController.instance.hasIceSpell = true;
        }
    }
}

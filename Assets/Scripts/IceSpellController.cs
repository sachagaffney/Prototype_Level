using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpellController : MonoBehaviour {
    private SpriteRenderer theSpriteRender;
    private bool seen; 
	// Use this for initialization
	void Start () {
        theSpriteRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log("Colliding with" + gameObject);

        if (theSpriteRender.isVisible)
        {
            seen = true; 
        }
        if ((theSpriteRender.isVisible == false) && (seen = true))
        {
            Destroy(gameObject); 
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TileMap"))
        {
            Destroy(gameObject);
        }
    }
}

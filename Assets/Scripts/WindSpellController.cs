using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpellController : MonoBehaviour
{
    private SpriteRenderer leSpriteRender;
    private bool appear;
    // Use this for initialization
    void Start()
    {
        leSpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Colliding with" + gameObject);

        if (leSpriteRender.isVisible)
        {
            appear = true;
        }
        if ((leSpriteRender.isVisible == false) && (appear = true))
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPCController : MonoBehaviour
{

    private bool facingRight;
    private Rigidbody2D theRigigdBody;
    public float horizontalSpeed;
    public bool doJump;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool grounded;

    public float hSpeed;
    public GameObject icespellPrefab;
    public GameObject firespellPrefab;
    public GameObject windSpellPrefab;
    public Transform gun;

    bool hazardKick;
    public float thrust;

    // Use this for initialization
    void Start()
    {

        theRigigdBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        doJump = Input.GetButton("Jump");
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
        grounded = (bool)colliderWeCollidedWith;
        if (hAxis != 0 && grounded)
        {
            if ((hAxis < 0) && (!facingRight))
            {
                flip();
               

            }
            else if ((hAxis > 0) && (facingRight))
            {
                flip();


            }

            theRigigdBody.velocity = new Vector2(horizontalSpeed * hAxis, theRigigdBody.velocity.y);



        }


        else if (!grounded)
        {
            theRigigdBody.velocity = new Vector2(horizontalSpeed * hAxis, theRigigdBody.velocity.y);

        }
        else
        {

            theRigigdBody.velocity = new Vector2(0, theRigigdBody.velocity.y);

        }



            bool shoot = Input.GetButtonDown("Fire1");
            bool fireSpell = Input.GetButtonDown("Fire2");
            bool windSpell = Input.GetButtonDown("Fire3");

            if (shoot && LMController.instance.hasIceSpell)
            {
                ShootBullet();
            }
            if (fireSpell && LMController.instance.hasFireSpell)
            {
                ShootFireSpell();
            }
            if (windSpell && LMController.instance.hasWindSpell)
            {
                ShootWindSpell();
            }

            
}


        
    

    private void FixedUpdate()
    {
        if (doJump && grounded)
        {

            Vector2 jf = new Vector2(0, jumpForce);
            theRigigdBody.AddForce(jf, ForceMode2D.Impulse);
        }
        if(hazardKick == true)
        {
            Vector2 pushForce = new Vector2(transform.localScale.x * thrust, 2);
            theRigigdBody.AddForce(pushForce, ForceMode2D.Impulse);
            hazardKick = false;
        }
    }

    private void ShootBullet()
    {

        GameObject aBullet = Instantiate(icespellPrefab, gun.position, gun.rotation);

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
    private void ShootFireSpell()
    {
        GameObject fireBall = Instantiate(firespellPrefab, gun.position, gun.rotation);

        Rigidbody2D fireSpellRB;
        fireSpellRB = fireBall.GetComponent<Rigidbody2D>();

        if (facingRight)
        {
            fireSpellRB.velocity = new Vector2(-10, 0);
        }
        else
        {
            fireSpellRB.velocity = new Vector2(10, 0);
        }
    }
    private void ShootWindSpell()
    {
        GameObject windBall = Instantiate(windSpellPrefab, gun.position, gun.rotation);

        Rigidbody2D WindSpellRB;
        WindSpellRB = windBall.GetComponent<Rigidbody2D>();

        if (facingRight)
        {
            WindSpellRB.velocity = new Vector2(-10, 0);
        }
        else
        {
            WindSpellRB.velocity = new Vector2(10, 0);
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RockNPC"))
        {
            Debug.Log("Colliding with" + gameObject);

            hazardKick = true;

        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Colliding with" + gameObject);

            hazardKick = true;

        }
    }
}
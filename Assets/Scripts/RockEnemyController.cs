using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemyController : MonoBehaviour
{
    public float speed;
    public float patrolDistance;
    private Vector3 startingPosition;
    private Rigidbody2D theRigidBody;
    private int direction;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundRadious;
    private bool grounded;
    public float counter;
    private bool facingLeft;

 

    // Use this for initialization
    void Start()
    {
        startingPosition = gameObject.transform.position;
        theRigidBody = gameObject.GetComponent<Rigidbody2D>();
        direction = 1;
     
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundCheck.position, groundRadious, whatIsGround);
        grounded = (bool)colliderWeCollidedWith;

        if ((gameObject.transform.position.x >= startingPosition.x + patrolDistance) && direction == 1 )
        {
           
            direction = -1;
           

        }

        else if ((gameObject.transform.position.x <= startingPosition.x - patrolDistance) && (direction == -1))
        {
            direction = 1;
            
        }
   

        if (counter >= 4)
        {
            destroyMe();
        }
    }
    private void FixedUpdate()
    {
        if(grounded)
        {
            theRigidBody.velocity = new Vector2(speed * direction, theRigidBody.velocity.y);
        }
        else
        {
            theRigidBody.velocity = new Vector2(0, theRigidBody.velocity.y);
        }
    }
    void flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colliding with" + gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthBarController.health -= 10f;
        }
        if (collision.gameObject.CompareTag("WindSpell"))
        {
            counter += 1;
            Destroy(collision.gameObject);
        }
        
    }
    void destroyMe ()
    {
        Destroy(gameObject);
    }
}






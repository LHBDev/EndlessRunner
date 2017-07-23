using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator myAnimator;

    public float jumpSpeed = 5f;

    public bool grounded;

    public float fallMultiplier = 0.5f;

    private bool shooting = false;

    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Rigidbody2D rigidBody;

    public GameManager theGameManager;

     void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidBody.velocity = new Vector2(0, jumpSpeed);
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity += Physics2D.gravity * (fallMultiplier) * Time.deltaTime;
        }

        if (!grounded)
        {
            myAnimator.SetInteger("State", 2);
        }
        else if(shooting)
        {
            myAnimator.SetInteger("State", 1);
        }
        else if(shooting)
        {
            myAnimator.SetInteger("State", 3);
        }
        else
        {
            myAnimator.SetInteger("State", 0);
        }    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "death")
        {
            theGameManager.RestartGame();
            Debug.Log("The Player Died");
        }
}

}

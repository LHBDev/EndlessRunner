using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    Animator animator;

    private Rigidbody2D myRigidbody;

    const int STATE_RUN = 0;
    const int STATE_SHOOT = 1;
    const int STATE_JUMP = 2;
    const int STATE_HURT = 3;
    int _current_state = STATE_RUN;

    bool _isHurt = false;
    bool _isJumping = false;

    int hp = 100;
    int lives = 3;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        myRigidbody = this.GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isHurt && !_isJumping)
        {
            _isJumping = true;
            changeState(STATE_JUMP);
            myRigidbody.AddForce(new Vector2(0, 250));
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
            changeState(STATE_SHOOT);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            changeState(STATE_RUN);
    }

    void changeState(int state)
    {
        if (_current_state == state)
            return;
        switch (state)
        {
            case STATE_RUN:
                animator.SetInteger("State", STATE_RUN);
                break;
            case STATE_SHOOT:
                animator.SetInteger("State", STATE_SHOOT);
                break;
            case STATE_JUMP:
                animator.SetInteger("State", STATE_JUMP);
                break;
            case STATE_HURT:
                animator.SetInteger("State", STATE_HURT);
                break;
        }
        _current_state = state;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "Floor")
        {
            _isJumping = false;
            changeState(STATE_RUN);
        }
    }
}

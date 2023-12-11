using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedMove;
    public float jumpingPower;
    public SpriteRenderer sprtRnd;
    public Animator animPlayer;

    private float horizontal;
    private bool isFacingRight = true;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        chekMovement();
    
    }

    /// <summary>
    /// revisar lo que pas amañana no entra por los if debug 
    /// </summary>
    private void chekMovement() {

        if (Mathf.Abs(horizontal) != 0f) {
            Debug.Log("si entra por aqui true ");
            animPlayer.SetBool("isRunning", true);
        }
        else {
            Debug.Log("si entra por aqui false ");
            animPlayer.SetBool("isRunning", false);
        }





        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);
        }

        if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = true;
            sprtRnd.flipX = false;
        }
        else if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = false;
            sprtRnd.flipX = true;
        }


    }
    
    public void Move(InputAction.CallbackContext context)
    {
        
            horizontal = context.ReadValue<Vector2>().x;
        
        
    }
    public void Jump() {
        if (checkGround.isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
    }


}

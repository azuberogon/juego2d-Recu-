using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedMove;
    public float jumpingPower;
    public SpriteRenderer sprtRnd;
    public Animator animPlayer;
    public Transform transformPlayer;
    public GameObject arrowPrefab;
    public float waithShootTime;
    public GameObject arrowOut;
    public UnityEvent loadNewScene;

    private float horizontal;
    private bool isFacingRight = true;
    private Vector2 directionArrow;
    private float lastShoot;


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
    private void chekMovement()
    {

        if (Mathf.Abs(horizontal) != 0f)
        {

            animPlayer.SetBool("isRunning", true);
        }
        else
        {

            animPlayer.SetBool("isRunning", false);
        }





        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);
            animPlayer.SetBool("isGrounded", true);
        }
        else
        {
            animPlayer.SetBool("isGrounded", false);
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
    public void Jump()
    {
        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

    }
    public void shootAnimation() {
        if (Time.time > lastShoot + waithShootTime)
        {
        
            animPlayer.SetTrigger("shoot");
            lastShoot = Time.time;
        }
        
    }
    public void Shoot()
    {
        //Debug.Log("Baaaaang");

        
            
            GameObject arrow = Instantiate(arrowPrefab, arrowOut.transform.position, Quaternion.identity);
            if (sprtRnd.flipX)
            { //mira hacia la izquierda 
                directionArrow = Vector2.left;
            }
            else
            { // mira hacia la derecha 
                directionArrow = Vector2.right;
            }
            arrow.GetComponent<ArrowController>().setDirection(directionArrow);

            
        

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            animPlayer.SetTrigger("death");
          
        }
        
    }

    private void ldScene() {
        loadNewScene.Invoke();
    }





}
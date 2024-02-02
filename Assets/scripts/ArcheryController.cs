using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArcheryController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speedArchery;
    public Animator animPlayer;

    private bool ArcheryAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followingPlayer();
    }
    public void attack() {
        ArcheryAttacking = true;
    }

    public void followingPlayer() {
        if (ArcheryAttacking)
        {
            rb.velocity = new Vector2((-1f) * speedArchery, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flecha") )
        {
            animPlayer.SetTrigger("Death");
            

        }

    }
    public void death()
    {
        Destroy(gameObject);
    }
}

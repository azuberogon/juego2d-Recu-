using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class attackArchery : MonoBehaviour
{

    public Animator archeryAttack;
    public UnityEvent isAttacking;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {

            //Debug.Log("el enemigo ataca ");
            archeryAttack.SetBool("Attack",true);
            isAttacking.Invoke();
        }
    }
   
}

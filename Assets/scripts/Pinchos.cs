using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Debug.Log("Has muerto");
            //animPlayer.SetTrigger("death");
        }
    }





}

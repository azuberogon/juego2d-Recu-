using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speedArrow;

    private Vector2 arrowDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(arrowDirection * speedArrow * Time.fixedDeltaTime);

        if (arrowDirection == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void setDirection( Vector2 dir) {
        arrowDirection = dir;
    }
}

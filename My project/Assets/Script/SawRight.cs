using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRight : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Transform leftpoint, rightpoint;
    private float leftx, rightx;
    private float Speed = 3;
    // private float Time = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Saw();
    }
     void Saw()
    { 
            if(transform.position.x <= leftx) 
            {
                Invoke("SawRightOn",0.1f);
            }
            if(transform.position.x >= rightx) 
            {
                Invoke("SawLeftOn",0.1f);
            }  
    }
    void SawRightOn()
    {
        rb.velocity = new Vector2(Speed, 0);
    }
     void SawLeftOn()
    {
        rb.velocity = new Vector2(-Speed, 0);
    }
}

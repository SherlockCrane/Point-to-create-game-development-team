using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyOff : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftpoint, rightpoint;
    private float leftx, rightx;
    public float Speed;
    private bool Faceleft = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(Faceleft)
        {   
            rb.velocity = new Vector2(-Speed, 0);
            if(transform.position.x <= leftx)
            {
                rb.velocity = new Vector2(0, 0);
                Invoke("FaceleftOff",1.0f);
            }
        }
        else 
        {
            rb.velocity = new Vector2(Speed, 0);
            if(transform.position.x >= rightx)
            {
                rb.velocity = new Vector2(0, 0);
                Invoke("FaceleftOn",1.0f);
            }
        }
    } 
    void FaceleftOff()
    {
        Faceleft = false;
    }
    void FaceleftOn()
    {
        Faceleft = true;
    }
}

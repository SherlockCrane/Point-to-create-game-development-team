using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAround : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Transform leftpoint, rightpoint, uppoint, downpoint;
    private float leftx, rightx, upy, downy, upx;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        upy = uppoint.position.y;
        upx = uppoint.position.x;
        downy = downpoint.position.y;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SawAroundOn();
    }
    void SawAroundOn()
    {
        if(transform.position.x <= leftx) 
        {
           rb.velocity = new Vector2(0, -Speed); 
        }
        if(transform.position.y <= downy) 
        {
           rb.velocity = new Vector2(Speed, 0); 
        }
        if(transform.position.x >= rightx) 
        {
           rb.velocity = new Vector2(0, Speed); 
        }
        if(transform.position.y >= upy) 
        {
            if(transform.position.x >= upx) 
            {
                rb.velocity = new Vector2(-Speed, 0); 
            } 
        }
    }
}
